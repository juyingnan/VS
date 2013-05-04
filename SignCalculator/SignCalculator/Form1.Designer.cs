namespace SignCalculator
{
    partial class signCalculator
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
            this.fileAddress = new System.Windows.Forms.TextBox();
            this.fileLoadingButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numberInputButton = new System.Windows.Forms.Button();
            this.signOutputLabel1 = new System.Windows.Forms.Label();
            this.outputDetailButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Tip1 = new System.Windows.Forms.Label();
            this.openDetailButton = new System.Windows.Forms.Button();
            this.PriceFormOpenButton = new System.Windows.Forms.Button();
            this.CurrencySelectionBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fileAddress
            // 
            this.fileAddress.Location = new System.Drawing.Point(15, 19);
            this.fileAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileAddress.Name = "fileAddress";
            this.fileAddress.ReadOnly = true;
            this.fileAddress.Size = new System.Drawing.Size(207, 23);
            this.fileAddress.TabIndex = 0;
            // 
            // fileLoadingButton
            // 
            this.fileLoadingButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLoadingButton.Location = new System.Drawing.Point(230, 16);
            this.fileLoadingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileLoadingButton.Name = "fileLoadingButton";
            this.fileLoadingButton.Size = new System.Drawing.Size(87, 29);
            this.fileLoadingButton.TabIndex = 1;
            this.fileLoadingButton.Text = "Load";
            this.fileLoadingButton.UseVisualStyleBackColor = true;
            this.fileLoadingButton.Click += new System.EventHandler(this.fileLoadingButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(149, 51);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 23);
            this.textBox2.TabIndex = 2;
            // 
            // numberInputButton
            // 
            this.numberInputButton.Enabled = false;
            this.numberInputButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberInputButton.Location = new System.Drawing.Point(231, 57);
            this.numberInputButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberInputButton.Name = "numberInputButton";
            this.numberInputButton.Size = new System.Drawing.Size(87, 29);
            this.numberInputButton.TabIndex = 3;
            this.numberInputButton.Text = "Correct";
            this.numberInputButton.UseVisualStyleBackColor = true;
            this.numberInputButton.Click += new System.EventHandler(this.numberInputButton_Click);
            // 
            // signOutputLabel1
            // 
            this.signOutputLabel1.AutoSize = true;
            this.signOutputLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutputLabel1.Location = new System.Drawing.Point(14, 56);
            this.signOutputLabel1.Name = "signOutputLabel1";
            this.signOutputLabel1.Size = new System.Drawing.Size(127, 15);
            this.signOutputLabel1.TabIndex = 4;
            this.signOutputLabel1.Text = "The number of SIGN is";
            // 
            // outputDetailButton
            // 
            this.outputDetailButton.Enabled = false;
            this.outputDetailButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputDetailButton.Location = new System.Drawing.Point(231, 139);
            this.outputDetailButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outputDetailButton.Name = "outputDetailButton";
            this.outputDetailButton.Size = new System.Drawing.Size(87, 29);
            this.outputDetailButton.TabIndex = 6;
            this.outputDetailButton.Text = "Save As...";
            this.outputDetailButton.UseVisualStyleBackColor = true;
            this.outputDetailButton.Click += new System.EventHandler(this.outputDetailButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "\"CSV file|*.csv|all files|*.*\"";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 137);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(207, 148);
            this.checkedListBox1.TabIndex = 7;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.OverwritePrompt = false;
            // 
            // Tip1
            // 
            this.Tip1.AutoSize = true;
            this.Tip1.Location = new System.Drawing.Point(15, 121);
            this.Tip1.Name = "Tip1";
            this.Tip1.Size = new System.Drawing.Size(157, 15);
            this.Tip1.TabIndex = 8;
            this.Tip1.Text = "Please choose output items";
            // 
            // openDetailButton
            // 
            this.openDetailButton.Enabled = false;
            this.openDetailButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openDetailButton.Location = new System.Drawing.Point(232, 98);
            this.openDetailButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openDetailButton.Name = "openDetailButton";
            this.openDetailButton.Size = new System.Drawing.Size(87, 29);
            this.openDetailButton.TabIndex = 9;
            this.openDetailButton.Text = "Output";
            this.openDetailButton.UseVisualStyleBackColor = true;
            this.openDetailButton.Click += new System.EventHandler(this.openDetailButton_Click);
            // 
            // PriceFormOpenButton
            // 
            this.PriceFormOpenButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceFormOpenButton.Location = new System.Drawing.Point(232, 180);
            this.PriceFormOpenButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PriceFormOpenButton.Name = "PriceFormOpenButton";
            this.PriceFormOpenButton.Size = new System.Drawing.Size(87, 29);
            this.PriceFormOpenButton.TabIndex = 10;
            this.PriceFormOpenButton.Text = "Price";
            this.PriceFormOpenButton.UseVisualStyleBackColor = true;
            this.PriceFormOpenButton.Click += new System.EventHandler(this.PriceFormOpenButton_Click);
            // 
            // CurrencySelectionBox
            // 
            this.CurrencySelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrencySelectionBox.FormattingEnabled = true;
            this.CurrencySelectionBox.Items.AddRange(new object[] {
            "RMB",
            "USD",
            "EUR"});
            this.CurrencySelectionBox.Location = new System.Drawing.Point(17, 85);
            this.CurrencySelectionBox.Name = "CurrencySelectionBox";
            this.CurrencySelectionBox.Size = new System.Drawing.Size(121, 23);
            this.CurrencySelectionBox.TabIndex = 11;
            // 
            // signCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 316);
            this.Controls.Add(this.CurrencySelectionBox);
            this.Controls.Add(this.PriceFormOpenButton);
            this.Controls.Add(this.openDetailButton);
            this.Controls.Add(this.Tip1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.outputDetailButton);
            this.Controls.Add(this.signOutputLabel1);
            this.Controls.Add(this.numberInputButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.fileLoadingButton);
            this.Controls.Add(this.fileAddress);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "signCalculator";
            this.Text = "Sign Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileAddress;
        private System.Windows.Forms.Button fileLoadingButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button numberInputButton;
        private System.Windows.Forms.Label signOutputLabel1;
        private System.Windows.Forms.Button outputDetailButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Tip1;
        private System.Windows.Forms.Button openDetailButton;
        private System.Windows.Forms.Button PriceFormOpenButton;
        private System.Windows.Forms.ComboBox CurrencySelectionBox;
    }
}

