namespace Log_Filter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PathTxtBox = new System.Windows.Forms.TextBox();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOriginalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LineLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathTxtBox
            // 
            this.PathTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTxtBox.Location = new System.Drawing.Point(12, 33);
            this.PathTxtBox.Name = "PathTxtBox";
            this.PathTxtBox.Size = new System.Drawing.Size(700, 20);
            this.PathTxtBox.TabIndex = 0;
            this.PathTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTxtBox_KeyDown);
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileBtn.Location = new System.Drawing.Point(718, 31);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(27, 23);
            this.SelectFileBtn.TabIndex = 1;
            this.SelectFileBtn.Text = "...";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadBtn.Location = new System.Drawing.Point(751, 31);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReloadBtn.TabIndex = 2;
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.FormattingEnabled = true;
            this.LogBox.HorizontalScrollbar = true;
            this.LogBox.Location = new System.Drawing.Point(0, 90);
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollAlwaysVisible = true;
            this.LogBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LogBox.Size = new System.Drawing.Size(838, 511);
            this.LogBox.TabIndex = 3;
            this.LogBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogBox_KeyDown);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.FilterTextBox.Location = new System.Drawing.Point(12, 60);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(733, 20);
            this.FilterTextBox.TabIndex = 4;
            this.FilterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterTextBox_KeyDown);
            // 
            // FilterBtn
            // 
            this.FilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterBtn.Location = new System.Drawing.Point(751, 58);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(75, 23);
            this.FilterBtn.TabIndex = 5;
            this.FilterBtn.Text = "Filter";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOriginalFileToolStripMenuItem,
            this.saveFilteredLogToolStripMenuItem,
            this.exportSelectionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.fileToolStripMenuItem.Text = "Utilities";
            // 
            // openOriginalFileToolStripMenuItem
            // 
            this.openOriginalFileToolStripMenuItem.Name = "openOriginalFileToolStripMenuItem";
            this.openOriginalFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openOriginalFileToolStripMenuItem.Text = "Edit Log";
            this.openOriginalFileToolStripMenuItem.Click += new System.EventHandler(this.openOriginalFileToolStripMenuItem_Click);
            // 
            // saveFilteredLogToolStripMenuItem
            // 
            this.saveFilteredLogToolStripMenuItem.Name = "saveFilteredLogToolStripMenuItem";
            this.saveFilteredLogToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveFilteredLogToolStripMenuItem.Text = "Export Filtered Log";
            this.saveFilteredLogToolStripMenuItem.Click += new System.EventHandler(this.saveFilteredLogToolStripMenuItem_Click);
            // 
            // exportSelectionsToolStripMenuItem
            // 
            this.exportSelectionsToolStripMenuItem.Name = "exportSelectionsToolStripMenuItem";
            this.exportSelectionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportSelectionsToolStripMenuItem.Text = "Export Selections";
            this.exportSelectionsToolStripMenuItem.Click += new System.EventHandler(this.exportSelectionsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(838, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LineLabel
            // 
            this.LineLabel.Name = "LineLabel";
            this.LineLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 631);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.SelectFileBtn);
            this.Controls.Add(this.PathTxtBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Log Filter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathTxtBox;
        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOriginalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredLogToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LineLabel;
        private System.Windows.Forms.ToolStripMenuItem exportSelectionsToolStripMenuItem;
    }
}

