namespace BugsBox.Pharmacy.AppClient
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bugsBoxFocusColorProvider1 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBox1, System.Drawing.Color.Yellow);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBox1, System.Drawing.Color.DarkRed);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBox2, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBox2, System.Drawing.Color.White);
            this.textBox2.Location = new System.Drawing.Point(115, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBox1, System.Drawing.Color.SlateGray);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBox1, System.Drawing.Color.Maroon);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // maskedTextBox1
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.maskedTextBox1, System.Drawing.Color.Yellow);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.maskedTextBox1, System.Drawing.Color.Maroon);
            this.maskedTextBox1.Location = new System.Drawing.Point(162, 27);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 21);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.numericUpDown1, System.Drawing.Color.LightSlateGray);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.numericUpDown1, System.Drawing.Color.WhiteSmoke);
            this.numericUpDown1.Location = new System.Drawing.Point(142, 54);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 5;
            // 
            // textBox3
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBox3, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBox3, System.Drawing.Color.White);
            this.textBox3.Location = new System.Drawing.Point(142, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox3;
    }
}

