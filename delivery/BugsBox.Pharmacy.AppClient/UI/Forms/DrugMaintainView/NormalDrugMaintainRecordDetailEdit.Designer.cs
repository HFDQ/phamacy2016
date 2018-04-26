namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintainView
{
    partial class NormalDrugMaintainRecordDetailEdit
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
            this.txtDrugInventoryId = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BuSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.txtCheckResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaintainCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheckqualifiedNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckqualifiedNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDrugInventoryId
            // 
            this.txtDrugInventoryId.Location = new System.Drawing.Point(481, 0);
            this.txtDrugInventoryId.Name = "txtDrugInventoryId";
            this.txtDrugInventoryId.Size = new System.Drawing.Size(100, 21);
            this.txtDrugInventoryId.TabIndex = 17;
            this.txtDrugInventoryId.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BuSave,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(573, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BuSave
            // 
            this.BuSave.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Save1;
            this.BuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BuSave.Name = "BuSave";
            this.BuSave.Size = new System.Drawing.Size(52, 22);
            this.BuSave.Text = "保存";
            this.BuSave.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Application_cancel;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "退出";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // txtCheckResult
            // 
            this.txtCheckResult.Location = new System.Drawing.Point(93, 139);
            this.txtCheckResult.MaxLength = 500;
            this.txtCheckResult.Multiline = true;
            this.txtCheckResult.Name = "txtCheckResult";
            this.txtCheckResult.Size = new System.Drawing.Size(449, 150);
            this.txtCheckResult.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "验收结果：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "养护数量：";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(93, 49);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(173, 21);
            this.txtProductName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "药品：";
            // 
            // txtMaintainCount
            // 
            this.txtMaintainCount.Location = new System.Drawing.Point(451, 48);
            this.txtMaintainCount.Name = "txtMaintainCount";
            this.txtMaintainCount.ReadOnly = true;
            this.txtMaintainCount.Size = new System.Drawing.Size(91, 21);
            this.txtMaintainCount.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "验收合格数量：";
            // 
            // txtCheckqualifiedNumber
            // 
            this.txtCheckqualifiedNumber.Location = new System.Drawing.Point(451, 90);
            this.txtCheckqualifiedNumber.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtCheckqualifiedNumber.Name = "txtCheckqualifiedNumber";
            this.txtCheckqualifiedNumber.Size = new System.Drawing.Size(91, 21);
            this.txtCheckqualifiedNumber.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "验收日期：";
            // 
            // txtCheckDate
            // 
            this.txtCheckDate.Location = new System.Drawing.Point(93, 90);
            this.txtCheckDate.Name = "txtCheckDate";
            this.txtCheckDate.Size = new System.Drawing.Size(172, 21);
            this.txtCheckDate.TabIndex = 22;
            // 
            // NormalDrugMaintainRecordDetailEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 319);
            this.Controls.Add(this.txtCheckDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCheckqualifiedNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaintainCount);
            this.Controls.Add(this.txtDrugInventoryId);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtCheckResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label1);
            this.Name = "NormalDrugMaintainRecordDetailEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "普通养护药品记录明细编辑";
            this.Load += new System.EventHandler(this.DrugMaintainRecordDetailEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckqualifiedNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCheckResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BuSave;
        private System.Windows.Forms.TextBox txtDrugInventoryId;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox txtMaintainCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtCheckqualifiedNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtCheckDate;
    }
}