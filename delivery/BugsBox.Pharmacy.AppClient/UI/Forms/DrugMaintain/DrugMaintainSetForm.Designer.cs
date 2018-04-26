namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    partial class DrugMaintainSetForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNormalRemindBeforeDay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNormalName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSpecialRemindBeforeDay = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSpecialName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalRemindBeforeDay)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecialRemindBeforeDay)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNormalRemindBeforeDay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNormalName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "普通养护药品";
            // 
            // txtNormalRemindBeforeDay
            // 
            this.txtNormalRemindBeforeDay.Location = new System.Drawing.Point(397, 35);
            this.txtNormalRemindBeforeDay.Name = "txtNormalRemindBeforeDay";
            this.txtNormalRemindBeforeDay.Size = new System.Drawing.Size(128, 21);
            this.txtNormalRemindBeforeDay.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "提前提醒天数：";
            // 
            // txtNormalName
            // 
            this.txtNormalName.Location = new System.Drawing.Point(117, 35);
            this.txtNormalName.Name = "txtNormalName";
            this.txtNormalName.Size = new System.Drawing.Size(127, 21);
            this.txtNormalName.TabIndex = 6;
            this.txtNormalName.Text = "普通养护药品";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "名称：";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtSpecialRemindBeforeDay);
            this.GroupBox2.Controls.Add(this.label7);
            this.GroupBox2.Controls.Add(this.txtSpecialName);
            this.GroupBox2.Controls.Add(this.label4);
            this.GroupBox2.Location = new System.Drawing.Point(12, 143);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(550, 97);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "重点养护药品";
            // 
            // txtSpecialRemindBeforeDay
            // 
            this.txtSpecialRemindBeforeDay.Location = new System.Drawing.Point(397, 40);
            this.txtSpecialRemindBeforeDay.Name = "txtSpecialRemindBeforeDay";
            this.txtSpecialRemindBeforeDay.Size = new System.Drawing.Size(128, 21);
            this.txtSpecialRemindBeforeDay.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "提前提醒天数：";
            // 
            // txtSpecialName
            // 
            this.txtSpecialName.Location = new System.Drawing.Point(117, 40);
            this.txtSpecialName.Name = "txtSpecialName";
            this.txtSpecialName.Size = new System.Drawing.Size(127, 21);
            this.txtSpecialName.TabIndex = 8;
            this.txtSpecialName.Text = "重点养护药品";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "名称：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Save1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "保存";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // DrugMaintainSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 290);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DrugMaintainSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品养护设置";
            this.Load += new System.EventHandler(this.DrugMaintenanceSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalRemindBeforeDay)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecialRemindBeforeDay)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNormalName;
        private System.Windows.Forms.TextBox txtSpecialName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtNormalRemindBeforeDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtSpecialRemindBeforeDay;
        private System.Windows.Forms.Label label7;

    }
}