using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_Filter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> FilterWords = new List<string>();
        List<string> WatchLogQueue = new List<string>();

        Thread WatchThread;
        bool doWork = true;

        StreamReader streamReader;

        const long logLineLimit = 10000;
        long TotalLinesProcessed = 0;
        object locker = new object();

        
        bool TryFilterLogMsg(string msg)
        {
            TotalLinesProcessed++;

            foreach (var filterword in FilterWords)
            {
                if (msg.IndexOf(filterword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string inputstr = TotalLinesProcessed.ToString("0000000") + "\t |  " + msg;

                    WatchLogQueue.Add(inputstr);
                    if (WatchLogQueue.Count > logLineLimit)
                        WatchLogQueue.RemoveAt(0);

                    return true;
                }
            }
            return false;
        }

        void BulkAddFilteredMsg(List<string> messages)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                lock (locker)
                {
                    LogBox.BeginUpdate();
                    LogBox.Items.AddRange(messages.ToArray());
                    GoToListBottom();
                    LogBox.EndUpdate();
                    WatchLogQueue.Clear();
                }
            }));
        }

        void HandleFileWatch()
        {
            // setup a file watch
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            var wh = new AutoResetEvent(false);
            DirectoryInfo dir = new DirectoryInfo(PathTxtBox.Text).Parent;
            fileSystemWatcher.Path = dir.FullName;
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.Changed += (s, ev) => wh.Set();
            // open a read only stream to tail it.

            var msg = "";
            while (doWork)
            {
                try
                {
                    if (streamReader == null)
                    {
                        doWork = false;
                        break;
                    }

                    if (streamReader.BaseStream.CanRead) // is the file still open?
                    {
                        msg = streamReader.ReadLine(); // note: this was opened when we picked a file. we assume its valid here.
                    }
                    else
                    {
                        doWork = false;
                        break;
                    }
                }
                catch (Exception)
                {
                    msg = "<<<< UNABLE TO PARSE LINE >>>>";
                }

                if (msg != null)
                {
                    LogBox.Invoke(new MethodInvoker(delegate ()
                    {
                        lock (locker)
                        {
                            TryFilterLogMsg(msg);
                        }

                        Application.DoEvents();
                    }));
                }
                else
                {
                    UpdateLineLabel();
                    {
                        // batch update now.
                        if (WatchLogQueue.Count > 0)
                        {
                            this.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                lock (locker)
                                {
                                    LogBox.BeginUpdate();
                                    LogBox.Items.AddRange(WatchLogQueue.ToArray());

                                    if (LogBox.Items.Count > logLineLimit)
                                    {
                                        long reduceby = LogBox.Items.Count - logLineLimit;
                                        for (int i = 0; i < reduceby; i++)
                                        {
                                            LogBox.Items.RemoveAt(0);
                                        }
                                    }

                                    GoToListBottom();
                                    LogBox.EndUpdate();
                                    WatchLogQueue.Clear();
                                }
                            }));
                        }
                    }
                    wh.WaitOne(250);
                }
            }

            fileSystemWatcher.EnableRaisingEvents = false; // shut it down first.
            wh.Close();
            WatchLogQueue.Clear();
        }

        void GoToListBottom()
        {
            int visibleItems = LogBox.ClientSize.Height / LogBox.ItemHeight;
            LogBox.TopIndex = Math.Max(LogBox.Items.Count - visibleItems + 1, 0);
        }

        void UpdateLineLabel()
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
             {
                 LineLabel.Text = "Displaying: " + LogBox.Items.Count.ToString() + " / " + TotalLinesProcessed.ToString();
                 LineLabel.ForeColor = (LogBox.Items.Count == logLineLimit) ? Color.Red : Color.Black;
             }));
        }

        ////////////////////////////////////////////////////////////

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            // just reapply filters from file..
            FilterBtn_Click(sender, e);
        }

        private void StartWatchThread()
        {
            WatchThread = new Thread(HandleFileWatch);
            doWork = true;
            WatchThread.Start();
        }

        private void StopWatchThread()
        {
            if (WatchThread != null && WatchThread.IsAlive)
            {
                doWork = false;
                WatchThread.Join();
            }
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "log";
            dlg.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
            dlg.CheckFileExists = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PathTxtBox.Text = dlg.FileName;
                ReloadBtn_Click(sender, e);
            }
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            LogBox.Items.Clear(); // clear display.
            FilterWords.Clear(); // clear filter words.
            TotalLinesProcessed = 0;

            if (File.Exists(PathTxtBox.Text))
            {
                // stop any old watches...
                StopWatchThread();

                // clear anything pending.
                WatchLogQueue.Clear();

                // generate new filter list.
                FilterWords = new List<string>(FilterTextBox.Text.Split('|'));
                for (int i = 0; i < FilterWords.Count; i++)
                {
                    FilterWords[i] = FilterWords[i].Trim();
                }

                // reopen file.
                if (streamReader != null)
                    streamReader.Close();

                // open new stream for reading and pump it all into the log data to parse.
                streamReader = new StreamReader(new FileStream(PathTxtBox.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, FileOptions.Asynchronous));

                while (!streamReader.EndOfStream)
                {
                    // add data to pending work.
                    TryFilterLogMsg(streamReader.ReadLine());
                }

                // now continue to watch it for new lines.
                StartWatchThread();
            }

           
            // do a single insert for speed here.
            LogBox.BeginUpdate();
            LogBox.Items.AddRange(WatchLogQueue.ToArray());
            WatchLogQueue.Clear();
            GoToListBottom();
            LogBox.EndUpdate();

            UpdateLineLabel();
        }

        private void FilterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterBtn_Click(sender, new EventArgs());
            }
        }

        private void PathTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReloadBtn_Click(sender, new EventArgs());
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            LogBox.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWatchThread();

            if (streamReader != null)
                streamReader.Close();
        }

        private void LogBox_KeyDown(object sender, KeyEventArgs e)
        {
            // COPY all highlighted text
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string temp = "";
                foreach (object item in LogBox.SelectedItems) temp += item.ToString() + "\r\n";
                Clipboard.SetText(temp);
            }
        }

        private void openOriginalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(PathTxtBox.Text))
            {
                System.Diagnostics.Process.Start(PathTxtBox.Text);
            }
        }

        private void saveFilteredLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "log";
            dlg.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string temp = "";
                foreach (object item in LogBox.Items) temp += item.ToString() + "\r\n";
                File.WriteAllText(dlg.FileName, temp);
            }

        }

        private void exportSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "log";
            dlg.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";

            // write data in such a way that we consolidate all of the selected lines into 1 document, but preserve the idea that there are gaps between selections for readability.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dlg.FileName))
                {
                    int lastindex = 0;

                    foreach (int itemIndex in LogBox.SelectedIndices)
                    {

                        object selection = LogBox.Items[itemIndex];

                        if (itemIndex - lastindex > 1)
                        {
                            writer.WriteLine(" ");
                            writer.WriteLine("...");
                            writer.WriteLine(" ");
                        }
                        writer.WriteLine(selection.ToString());
                        lastindex = itemIndex;
                    }
                }
            }
        }
    }
}
