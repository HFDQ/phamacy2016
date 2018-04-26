namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormGMPLicense
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
            this.components = new System.ComponentModel.Container();
            this.dateTimePickerOutDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerIssuanceDate = new System.Windows.Forms.DateTimePicker();
            this.gMPLicenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxIssuanceOrg = new System.Windows.Forms.TextBox();
            this.textBoxRegAddress = new System.Windows.Forms.TextBox();
            this.textBoxUnitName = new System.Windows.Forms.TextBox();
            this.textBoxLicenseCode = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCertificationScope = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bugsBoxFocusColorProvider2 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gMPLicenseBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerOutDate
            // 
            this.dateTimePickerOutDate.CausesValidation = false;
            this.dateTimePickerOutDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gMPLicenseBindingSource, "OutDate", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.dateTimePickerOutDate, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.dateTimePickerOutDate, System.Drawing.Color.White);
            this.dateTimePickerOutDate.Location = new System.Drawing.Point(471, 164);
            this.dateTimePickerOutDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerOutDate.Name = "dateTimePickerOutDate";
            this.dateTimePickerOutDate.Size = new System.Drawing.Size(260, 28);
            this.dateTimePickerOutDate.TabIndex = 6;
            this.dateTimePickerOutDate.ValueChanged += new System.EventHandler(this.dateTimePickerOutDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "证书名称";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "发证日期";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 169);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "有效期至";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 129);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "发证机关";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePickerOutDate);
            this.groupBox2.Controls.Add(this.dateTimePickerIssuanceDate);
            this.groupBox2.Controls.Add(this.textBoxIssuanceOrg);
            this.groupBox2.Controls.Add(this.textBoxRegAddress);
            this.groupBox2.Controls.Add(this.textBoxUnitName);
            this.groupBox2.Controls.Add(this.textBoxLicenseCode);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(4, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(743, 206);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // dateTimePickerIssuanceDate
            // 
            this.dateTimePickerIssuanceDate.CausesValidation = false;
            this.dateTimePickerIssuanceDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gMPLicenseBindingSource, "IssuanceDate", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.dateTimePickerIssuanceDate, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.dateTimePickerIssuanceDate, System.Drawing.Color.White);
            this.dateTimePickerIssuanceDate.Location = new System.Drawing.Point(104, 164);
            this.dateTimePickerIssuanceDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerIssuanceDate.Name = "dateTimePickerIssuanceDate";
            this.dateTimePickerIssuanceDate.Size = new System.Drawing.Size(252, 28);
            this.dateTimePickerIssuanceDate.TabIndex = 5;
            this.dateTimePickerIssuanceDate.ValueChanged += new System.EventHandler(this.dateTimePickerIssuanceDate_ValueChanged);
            // 
            // gMPLicenseBindingSource
            // 
            this.gMPLicenseBindingSource.DataSource = typeof(BugsBox.Pharmacy.Models.GMPLicense);
            // 
            // textBoxIssuanceOrg
            // 
            this.textBoxIssuanceOrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "IssuanceOrg", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxIssuanceOrg, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxIssuanceOrg, System.Drawing.Color.White);
            this.textBoxIssuanceOrg.Location = new System.Drawing.Point(104, 124);
            this.textBoxIssuanceOrg.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIssuanceOrg.Name = "textBoxIssuanceOrg";
            this.textBoxIssuanceOrg.Size = new System.Drawing.Size(628, 28);
            this.textBoxIssuanceOrg.TabIndex = 4;
            // 
            // textBoxRegAddress
            // 
            this.textBoxRegAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "RegAddress", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxRegAddress, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxRegAddress, System.Drawing.Color.White);
            this.textBoxRegAddress.Location = new System.Drawing.Point(104, 90);
            this.textBoxRegAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRegAddress.Name = "textBoxRegAddress";
            this.textBoxRegAddress.Size = new System.Drawing.Size(628, 28);
            this.textBoxRegAddress.TabIndex = 3;
            // 
            // textBoxUnitName
            // 
            this.textBoxUnitName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "UnitName", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxUnitName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxUnitName, System.Drawing.Color.White);
            this.textBoxUnitName.Location = new System.Drawing.Point(104, 56);
            this.textBoxUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUnitName.Name = "textBoxUnitName";
            this.textBoxUnitName.Size = new System.Drawing.Size(628, 28);
            this.textBoxUnitName.TabIndex = 2;
            // 
            // textBoxLicenseCode
            // 
            this.textBoxLicenseCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "LicenseCode", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxLicenseCode, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxLicenseCode, System.Drawing.Color.White);
            this.textBoxLicenseCode.Location = new System.Drawing.Point(471, 20);
            this.textBoxLicenseCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLicenseCode.Name = "textBoxLicenseCode";
            this.textBoxLicenseCode.Size = new System.Drawing.Size(260, 28);
            this.textBoxLicenseCode.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "Name", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxName, System.Drawing.Color.White);
            this.textBoxName.Location = new System.Drawing.Point(104, 21);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(253, 28);
            this.textBoxName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "证书号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "企业名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "注册地址";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 436);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 21;
            this.label15.Text = "证书状态";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(447, 428);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 34);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "保存(&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStatus
            // 
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxStatus, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxStatus, System.Drawing.Color.White);
            this.textBoxStatus.Location = new System.Drawing.Point(111, 432);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(208, 28);
            this.textBoxStatus.TabIndex = 22;
            // 
            // buttonClose
            // 
            this.buttonClose.CausesValidation = false;
            this.buttonClose.Location = new System.Drawing.Point(571, 428);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 34);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "关闭(&X)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(751, 406);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "证书信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCertificationScope);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 231);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(743, 171);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GMP证书信息";
            // 
            // textBoxCertificationScope
            // 
            this.textBoxCertificationScope.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gMPLicenseBindingSource, "CertificationScope", true));
            this.bugsBoxFocusColorProvider2.SetFocusBackColor(this.textBoxCertificationScope, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider2.SetFocusForeColor(this.textBoxCertificationScope, System.Drawing.Color.White);
            this.textBoxCertificationScope.Location = new System.Drawing.Point(104, 30);
            this.textBoxCertificationScope.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCertificationScope.MaxLength = 100;
            this.textBoxCertificationScope.Multiline = true;
            this.textBoxCertificationScope.Name = "textBoxCertificationScope";
            this.textBoxCertificationScope.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCertificationScope.Size = new System.Drawing.Size(628, 133);
            this.textBoxCertificationScope.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "认证范围";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 428);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 26;
            this.button1.Text = "清除(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Image_Add;
            this.pictureBox1.Location = new System.Drawing.Point(700, 428);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormGMPLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 478);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGMPLicense";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMP证书";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gMPLicenseBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOutDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssuanceDate;
        private System.Windows.Forms.TextBox textBoxIssuanceOrg;
        private System.Windows.Forms.TextBox textBoxRegAddress;
        private System.Windows.Forms.TextBox textBoxUnitName;
        private System.Windows.Forms.TextBox textBoxLicenseCode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCertificationScope;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource gMPLicenseBindingSource;
    }
}