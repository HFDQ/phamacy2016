namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormGSPLicenseEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGMSPLicenseEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxCertificationScope = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxGMSPLicenseBusinessScopes = new System.Windows.Forms.CheckedListBox();
            this.textBoxQualityHeader = new System.Windows.Forms.TextBox();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.textBoxLegalPerson = new System.Windows.Forms.TextBox();
            this.comboBoxBusinessTypeId = new System.Windows.Forms.ComboBox();
            this.textBoxWarehouseAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerOutDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerIssuanceDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxIssuanceOrg = new System.Windows.Forms.TextBox();
            this.textBoxRegAddress = new System.Windows.Forms.TextBox();
            this.textBoxUnitName = new System.Windows.Forms.TextBox();
            this.textBoxLicenseCode = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.requiredFieldValidator1 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator2 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator3 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator4 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator5 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.bugsBoxFocusColorProvider1 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "证书信息";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxCertificationScope);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(8, 339);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 43);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GMP证书信息";
            // 
            // textBoxCertificationScope
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxCertificationScope, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxCertificationScope, System.Drawing.Color.White);
            this.textBoxCertificationScope.Location = new System.Drawing.Point(65, 14);
            this.textBoxCertificationScope.Name = "textBoxCertificationScope";
            this.textBoxCertificationScope.Size = new System.Drawing.Size(422, 21);
            this.textBoxCertificationScope.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "认证范围";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkedListBoxGMSPLicenseBusinessScopes);
            this.groupBox3.Controls.Add(this.textBoxQualityHeader);
            this.groupBox3.Controls.Add(this.textBoxHeader);
            this.groupBox3.Controls.Add(this.textBoxLegalPerson);
            this.groupBox3.Controls.Add(this.comboBoxBusinessTypeId);
            this.groupBox3.Controls.Add(this.textBoxWarehouseAddress);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(8, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 170);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GSP证书信息";
            // 
            // checkedListBoxGMSPLicenseBusinessScopes
            // 
            this.checkedListBoxGMSPLicenseBusinessScopes.CausesValidation = false;
            this.checkedListBoxGMSPLicenseBusinessScopes.FormattingEnabled = true;
            this.checkedListBoxGMSPLicenseBusinessScopes.HorizontalExtent = 2;
            this.checkedListBoxGMSPLicenseBusinessScopes.HorizontalScrollbar = true;
            this.checkedListBoxGMSPLicenseBusinessScopes.Location = new System.Drawing.Point(67, 90);
            this.checkedListBoxGMSPLicenseBusinessScopes.MultiColumn = true;
            this.checkedListBoxGMSPLicenseBusinessScopes.Name = "checkedListBoxGMSPLicenseBusinessScopes";
            this.checkedListBoxGMSPLicenseBusinessScopes.ScrollAlwaysVisible = true;
            this.checkedListBoxGMSPLicenseBusinessScopes.Size = new System.Drawing.Size(420, 68);
            this.checkedListBoxGMSPLicenseBusinessScopes.TabIndex = 20;
            this.checkedListBoxGMSPLicenseBusinessScopes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxGMSPLicenseBusinessScopes_ItemCheck);
            // 
            // textBoxQualityHeader
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxQualityHeader, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxQualityHeader, System.Drawing.Color.White);
            this.textBoxQualityHeader.Location = new System.Drawing.Point(317, 39);
            this.textBoxQualityHeader.Name = "textBoxQualityHeader";
            this.textBoxQualityHeader.Size = new System.Drawing.Size(170, 21);
            this.textBoxQualityHeader.TabIndex = 19;
            // 
            // textBoxHeader
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxHeader, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxHeader, System.Drawing.Color.White);
            this.textBoxHeader.Location = new System.Drawing.Point(317, 16);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.Size = new System.Drawing.Size(170, 21);
            this.textBoxHeader.TabIndex = 18;
            // 
            // textBoxLegalPerson
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxLegalPerson, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxLegalPerson, System.Drawing.Color.White);
            this.textBoxLegalPerson.Location = new System.Drawing.Point(67, 39);
            this.textBoxLegalPerson.Name = "textBoxLegalPerson";
            this.textBoxLegalPerson.Size = new System.Drawing.Size(170, 21);
            this.textBoxLegalPerson.TabIndex = 16;
            // 
            // comboBoxBusinessTypeId
            // 
            this.comboBoxBusinessTypeId.CausesValidation = false;
            this.comboBoxBusinessTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBoxBusinessTypeId, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBoxBusinessTypeId, System.Drawing.Color.White);
            this.comboBoxBusinessTypeId.FormattingEnabled = true;
            this.comboBoxBusinessTypeId.Location = new System.Drawing.Point(67, 17);
            this.comboBoxBusinessTypeId.Name = "comboBoxBusinessTypeId";
            this.comboBoxBusinessTypeId.Size = new System.Drawing.Size(169, 20);
            this.comboBoxBusinessTypeId.TabIndex = 15;
            // 
            // textBoxWarehouseAddress
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxWarehouseAddress, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxWarehouseAddress, System.Drawing.Color.White);
            this.textBoxWarehouseAddress.Location = new System.Drawing.Point(67, 62);
            this.textBoxWarehouseAddress.Name = "textBoxWarehouseAddress";
            this.textBoxWarehouseAddress.Size = new System.Drawing.Size(420, 21);
            this.textBoxWarehouseAddress.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "经营范围";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "法人";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "经营方式";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "质量负责人";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "仓库地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "企业负责人";
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
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 137);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            // 
            // dateTimePickerOutDate
            // 
            this.dateTimePickerOutDate.CausesValidation = false;
            this.dateTimePickerOutDate.Location = new System.Drawing.Point(314, 109);
            this.dateTimePickerOutDate.Name = "dateTimePickerOutDate";
            this.dateTimePickerOutDate.Size = new System.Drawing.Size(175, 21);
            this.dateTimePickerOutDate.TabIndex = 17;
            this.dateTimePickerOutDate.ValueChanged += new System.EventHandler(this.dateTimePickerOutDate_ValueChanged);
            // 
            // dateTimePickerIssuanceDate
            // 
            this.dateTimePickerIssuanceDate.CausesValidation = false;
            this.dateTimePickerIssuanceDate.Location = new System.Drawing.Point(69, 109);
            this.dateTimePickerIssuanceDate.Name = "dateTimePickerIssuanceDate";
            this.dateTimePickerIssuanceDate.Size = new System.Drawing.Size(169, 21);
            this.dateTimePickerIssuanceDate.TabIndex = 16;
            this.dateTimePickerIssuanceDate.ValueChanged += new System.EventHandler(this.dateTimePickerIssuanceDate_ValueChanged);
            // 
            // textBoxIssuanceOrg
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxIssuanceOrg, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxIssuanceOrg, System.Drawing.Color.White);
            this.textBoxIssuanceOrg.Location = new System.Drawing.Point(69, 83);
            this.textBoxIssuanceOrg.Name = "textBoxIssuanceOrg";
            this.textBoxIssuanceOrg.Size = new System.Drawing.Size(420, 21);
            this.textBoxIssuanceOrg.TabIndex = 15;
            // 
            // textBoxRegAddress
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxRegAddress, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxRegAddress, System.Drawing.Color.White);
            this.textBoxRegAddress.Location = new System.Drawing.Point(69, 60);
            this.textBoxRegAddress.Name = "textBoxRegAddress";
            this.textBoxRegAddress.Size = new System.Drawing.Size(420, 21);
            this.textBoxRegAddress.TabIndex = 14;
            // 
            // textBoxUnitName
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxUnitName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxUnitName, System.Drawing.Color.White);
            this.textBoxUnitName.Location = new System.Drawing.Point(69, 37);
            this.textBoxUnitName.Name = "textBoxUnitName";
            this.textBoxUnitName.Size = new System.Drawing.Size(420, 21);
            this.textBoxUnitName.TabIndex = 13;
            // 
            // textBoxLicenseCode
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxLicenseCode, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxLicenseCode, System.Drawing.Color.White);
            this.textBoxLicenseCode.Location = new System.Drawing.Point(314, 13);
            this.textBoxLicenseCode.Name = "textBoxLicenseCode";
            this.textBoxLicenseCode.Size = new System.Drawing.Size(175, 21);
            this.textBoxLicenseCode.TabIndex = 12;
            // 
            // textBoxName
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxName, System.Drawing.Color.White);
            this.textBoxName.Location = new System.Drawing.Point(69, 14);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(170, 21);
            this.textBoxName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "证书名称";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "发证日期";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(257, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "有效期至";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "发证机关";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "证书号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "企业名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "注册地址";
            // 
            // buttonClose
            // 
            this.buttonClose.CausesValidation = false;
            this.buttonClose.Location = new System.Drawing.Point(439, 413);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭(&X)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(356, 413);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存(&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStatus
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxStatus, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxStatus, System.Drawing.Color.White);
            this.textBoxStatus.Location = new System.Drawing.Point(89, 409);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(170, 21);
            this.textBoxStatus.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 413);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "证书状态";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ControlToValidate = this.textBoxName;
            this.requiredFieldValidator1.ErrorMessage = "请您输入证书名称";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ControlToValidate = this.textBoxLicenseCode;
            this.requiredFieldValidator2.ErrorMessage = "请您输入证书号";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ControlToValidate = this.textBoxUnitName;
            this.requiredFieldValidator3.ErrorMessage = "请您输入企业名称";
            this.requiredFieldValidator3.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator3.Icon")));
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ControlToValidate = this.textBoxRegAddress;
            this.requiredFieldValidator4.ErrorMessage = "请您输入证书地址";
            this.requiredFieldValidator4.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator4.Icon")));
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ControlToValidate = this.textBoxIssuanceOrg;
            this.requiredFieldValidator5.ErrorMessage = "请您输入发证机关";
            this.requiredFieldValidator5.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator5.Icon")));
            // 
            // FormGMSPLicenseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 443);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 470);
            this.MinimizeBox = false;
            this.Name = "FormGMSPLicenseEdit";
            this.Text = "GSP/GMP证书编辑";
            this.Load += new System.EventHandler(this.FormGMSPLicenseEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxLicenseCode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxRegAddress;
        private System.Windows.Forms.TextBox textBoxUnitName;
        private System.Windows.Forms.TextBox textBoxIssuanceOrg;
        private System.Windows.Forms.TextBox textBoxWarehouseAddress;
        private System.Windows.Forms.ComboBox comboBoxBusinessTypeId;
        private System.Windows.Forms.TextBox textBoxLegalPerson;
        private System.Windows.Forms.TextBox textBoxCertificationScope;
        private System.Windows.Forms.TextBox textBoxQualityHeader;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxGMSPLicenseBusinessScopes;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssuanceDate;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator1;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator2;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator3;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator4;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator5;
    }
}