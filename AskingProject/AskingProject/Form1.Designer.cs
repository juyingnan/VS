namespace AskingProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AutoNextCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestionsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnswersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.previousQuestionButton = new System.Windows.Forms.ToolStripButton();
            this.qstProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.nextQuestionButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolMenuStrip = new System.Windows.Forms.ToolStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.mainToolMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoNextCheckBox
            // 
            this.AutoNextCheckBox.AutoSize = true;
            this.AutoNextCheckBox.Checked = true;
            this.AutoNextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoNextCheckBox.Enabled = false;
            this.AutoNextCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoNextCheckBox.Location = new System.Drawing.Point(528, 27);
            this.AutoNextCheckBox.Name = "AutoNextCheckBox";
            this.AutoNextCheckBox.Size = new System.Drawing.Size(140, 23);
            this.AutoNextCheckBox.TabIndex = 6;
            this.AutoNextCheckBox.Text = "自动跳至下一题";
            this.AutoNextCheckBox.UseVisualStyleBackColor = true;
            this.AutoNextCheckBox.CheckedChanged += new System.EventHandler(this.AutoNextCheckBox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(668, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openQuestionsFileToolStripMenuItem,
            this.saveAnswersToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openQuestionsFileToolStripMenuItem
            // 
            this.openQuestionsFileToolStripMenuItem.Name = "openQuestionsFileToolStripMenuItem";
            this.openQuestionsFileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openQuestionsFileToolStripMenuItem.Text = "Open Questions File";
            this.openQuestionsFileToolStripMenuItem.Click += new System.EventHandler(this.openQuestionsFileToolStripMenuItem_Click);
            // 
            // saveAnswersToolStripMenuItem
            // 
            this.saveAnswersToolStripMenuItem.Name = "saveAnswersToolStripMenuItem";
            this.saveAnswersToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveAnswersToolStripMenuItem.Text = "Save Answers";
            this.saveAnswersToolStripMenuItem.Click += new System.EventHandler(this.saveAnswersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.BackColor = System.Drawing.SystemColors.Control;
            this.HeadingLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingLabel.Location = new System.Drawing.Point(314, 0);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(350, 25);
            this.HeadingLabel.TabIndex = 12;
            this.HeadingLabel.Text = "请从菜单打开题目文件。";
            this.HeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileButton.Image")));
            this.OpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(23, 22);
            this.OpenFileButton.Text = "打开(&O)";
            // 
            // saveFileButton
            // 
            this.saveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileButton.Image")));
            this.saveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(23, 22);
            this.saveFileButton.Text = "保存(&S)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // previousQuestionButton
            // 
            this.previousQuestionButton.Image = ((System.Drawing.Image)(resources.GetObject("previousQuestionButton.Image")));
            this.previousQuestionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousQuestionButton.Name = "previousQuestionButton";
            this.previousQuestionButton.Size = new System.Drawing.Size(64, 22);
            this.previousQuestionButton.Text = "上一题";
            // 
            // qstProgressBar
            // 
            this.qstProgressBar.Name = "qstProgressBar";
            this.qstProgressBar.Size = new System.Drawing.Size(150, 22);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Image = ((System.Drawing.Image)(resources.GetObject("nextQuestionButton.Image")));
            this.nextQuestionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(64, 22);
            this.nextQuestionButton.Text = "下一题";
            this.nextQuestionButton.Click += new System.EventHandler(this.NextQuestionButton_Click);
            // 
            // mainToolMenuStrip
            // 
            this.mainToolMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainToolMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileButton,
            this.saveFileButton,
            this.toolStripSeparator,
            this.previousQuestionButton,
            this.qstProgressBar,
            this.nextQuestionButton});
            this.mainToolMenuStrip.Location = new System.Drawing.Point(0, 25);
            this.mainToolMenuStrip.Name = "mainToolMenuStrip";
            this.mainToolMenuStrip.Size = new System.Drawing.Size(668, 25);
            this.mainToolMenuStrip.TabIndex = 14;
            this.mainToolMenuStrip.Text = "toolStrip2";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(656, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(656, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(4, 53);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(664, 479);
            this.tabControl.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(668, 544);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.AutoNextCheckBox);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.mainToolMenuStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AskingForm";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainToolMenuStrip.ResumeLayout(false);
            this.mainToolMenuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutoNextCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnswersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQuestionsFileToolStripMenuItem;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStripButton saveFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton previousQuestionButton;
        private System.Windows.Forms.ToolStripProgressBar qstProgressBar;
        private System.Windows.Forms.ToolStripButton nextQuestionButton;
        private System.Windows.Forms.ToolStrip mainToolMenuStrip;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
    }
}

