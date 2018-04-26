namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormSupplyUnitSalesmanEdit
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
            this.comboBoxSupplyUnitId = new System.Windows.Forms.ComboBox();
            this.labelSupplyUnitId = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelIDCheckUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxChecked = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIDCheckType = new System.Windows.Forms.TextBox();
            this.labelIDCheckType = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelAuthorizedDistrictId = new System.Windows.Forms.Label();
            this.comboBoxAuthorizedDistrictId = new System.Windows.Forms.ComboBox();
            this.dateTimePickerOutDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonIDNumber = new System.Windows.Forms.Button();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIDNumber = new System.Windows.Forms.TextBox();
            this.labelIDNumber = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.bugsBoxFocusColorProvider1 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ucBusinessScopeEditor = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucBusinessScopeEditor();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSupplyUnitId
            // 
            this.comboBoxSupplyUnitId.DisplayMember = "Name";
            this.comboBoxSupplyUnitId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBoxSupplyUnitId, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBoxSupplyUnitId, System.Drawing.Color.White);
            this.comboBoxSupplyUnitId.FormattingEnabled = true;
            this.comboBoxSupplyUnitId.Location = new System.Drawing.Point(73, 16);
            this.comboBoxSupplyUnitId.Name = "comboBoxSupplyUnitId";
            this.comboBoxSupplyUnitId.Size = new System.Drawing.Size(200, 20);
            this.comboBoxSupplyUnitId.TabIndex = 2;
            this.comboBoxSupplyUnitId.ValueMember = "Id";
            this.comboBoxSupplyUnitId.SelectedValueChanged += new System.EventHandler(this.comboBoxSupplyUnitId_SelectedValueChanged);
            // 
            // labelSupplyUnitId
            // 
            this.labelSupplyUnitId.AutoSize = true;
            this.labelSupplyUnitId.Location = new System.Drawing.Point(12, 22);
            this.labelSupplyUnitId.Name = "labelSupplyUnitId";
            this.labelSupplyUnitId.Size = new System.Drawing.Size(41, 12);
            this.labelSupplyUnitId.TabIndex = 4;
            this.labelSupplyUnitId.Text = "供货商";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.buttonCancel);
            this.groupBox2.Controls.Add(this.buttonOk);
            this.groupBox2.Controls.Add(this.ucBusinessScopeEditor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.checkBoxEnabled);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.labelAuthorizedDistrictId);
            this.groupBox2.Controls.Add(this.comboBoxAuthorizedDistrictId);
            this.groupBox2.Controls.Add(this.labelSupplyUnitId);
            this.groupBox2.Controls.Add(this.comboBoxSupplyUnitId);
            this.groupBox2.Location = new System.Drawing.Point(5, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 300);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务信息";
            // 
            // textBox1
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBox1, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBox1, System.Drawing.Color.White);
            this.textBox1.Location = new System.Drawing.Point(73, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(736, 21);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "关联商品信息,选中后控制具体品种";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelIDCheckUserName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkBoxChecked);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxIDCheckType);
            this.groupBox3.Controls.Add(this.labelIDCheckType);
            this.groupBox3.Location = new System.Drawing.Point(14, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 70);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "核实信息";
            // 
            // labelIDCheckUserName
            // 
            this.labelIDCheckUserName.AutoSize = true;
            this.labelIDCheckUserName.Location = new System.Drawing.Point(282, 42);
            this.labelIDCheckUserName.Name = "labelIDCheckUserName";
            this.labelIDCheckUserName.Size = new System.Drawing.Size(23, 12);
            this.labelIDCheckUserName.TabIndex = 17;
            this.labelIDCheckUserName.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "核实人员";
            // 
            // checkBoxChecked
            // 
            this.checkBoxChecked.AutoSize = true;
            this.checkBoxChecked.Location = new System.Drawing.Point(82, 44);
            this.checkBoxChecked.Name = "checkBoxChecked";
            this.checkBoxChecked.Size = new System.Drawing.Size(48, 16);
            this.checkBoxChecked.TabIndex = 15;
            this.checkBoxChecked.Text = "通过";
            this.checkBoxChecked.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "核实结果";
            // 
            // textBoxIDCheckType
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxIDCheckType, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxIDCheckType, System.Drawing.Color.White);
            this.textBoxIDCheckType.Location = new System.Drawing.Point(82, 17);
            this.textBoxIDCheckType.Name = "textBoxIDCheckType";
            this.textBoxIDCheckType.Size = new System.Drawing.Size(100, 21);
            this.textBoxIDCheckType.TabIndex = 7;
            // 
            // labelIDCheckType
            // 
            this.labelIDCheckType.AutoSize = true;
            this.labelIDCheckType.Location = new System.Drawing.Point(10, 20);
            this.labelIDCheckType.Name = "labelIDCheckType";
            this.labelIDCheckType.Size = new System.Drawing.Size(53, 12);
            this.labelIDCheckType.TabIndex = 6;
            this.labelIDCheckType.Text = "核实方式";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(734, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(653, 232);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "备注";
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Location = new System.Drawing.Point(734, 20);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(48, 16);
            this.checkBoxEnabled.TabIndex = 14;
            this.checkBoxEnabled.Text = "启用";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "业务范围";
            // 
            // labelAuthorizedDistrictId
            // 
            this.labelAuthorizedDistrictId.AutoSize = true;
            this.labelAuthorizedDistrictId.Location = new System.Drawing.Point(295, 22);
            this.labelAuthorizedDistrictId.Name = "labelAuthorizedDistrictId";
            this.labelAuthorizedDistrictId.Size = new System.Drawing.Size(53, 12);
            this.labelAuthorizedDistrictId.TabIndex = 16;
            this.labelAuthorizedDistrictId.Text = "授权区域";
            // 
            // comboBoxAuthorizedDistrictId
            // 
            this.comboBoxAuthorizedDistrictId.DisplayMember = "Name";
            this.comboBoxAuthorizedDistrictId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBoxAuthorizedDistrictId, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBoxAuthorizedDistrictId, System.Drawing.Color.White);
            this.comboBoxAuthorizedDistrictId.FormattingEnabled = true;
            this.comboBoxAuthorizedDistrictId.Location = new System.Drawing.Point(357, 18);
            this.comboBoxAuthorizedDistrictId.Name = "comboBoxAuthorizedDistrictId";
            this.comboBoxAuthorizedDistrictId.Size = new System.Drawing.Size(144, 20);
            this.comboBoxAuthorizedDistrictId.TabIndex = 15;
            this.comboBoxAuthorizedDistrictId.ValueMember = "Id";
            // 
            // dateTimePickerOutDate
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.dateTimePickerOutDate, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.dateTimePickerOutDate, System.Drawing.Color.White);
            this.dateTimePickerOutDate.Location = new System.Drawing.Point(684, 46);
            this.dateTimePickerOutDate.Name = "dateTimePickerOutDate";
            this.dateTimePickerOutDate.Size = new System.Drawing.Size(125, 21);
            this.dateTimePickerOutDate.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(601, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "委托截止日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonIDNumber);
            this.groupBox1.Controls.Add(this.textBoxTel);
            this.groupBox1.Controls.Add(this.labelTel);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.comboBoxGender);
            this.groupBox1.Controls.Add(this.labelGender);
            this.groupBox1.Controls.Add(this.dateTimePickerOutDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePickerBirthday);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxIDNumber);
            this.groupBox1.Controls.Add(this.labelIDNumber);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(824, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // buttonIDNumber
            // 
            this.buttonIDNumber.Location = new System.Drawing.Point(385, 15);
            this.buttonIDNumber.Name = "buttonIDNumber";
            this.buttonIDNumber.Size = new System.Drawing.Size(34, 23);
            this.buttonIDNumber.TabIndex = 21;
            this.buttonIDNumber.Text = "...";
            this.buttonIDNumber.UseVisualStyleBackColor = true;
            this.buttonIDNumber.Click += new System.EventHandler(this.buttonIDNumber_Click);
            // 
            // textBoxTel
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxTel, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxTel, System.Drawing.Color.White);
            this.textBoxTel.Location = new System.Drawing.Point(495, 42);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(76, 21);
            this.textBoxTel.TabIndex = 16;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(445, 46);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(29, 12);
            this.labelTel.TabIndex = 15;
            this.labelTel.Text = "电话";
            // 
            // textBoxAddress
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxAddress, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxAddress, System.Drawing.Color.White);
            this.textBoxAddress.Location = new System.Drawing.Point(73, 42);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(346, 21);
            this.textBoxAddress.TabIndex = 14;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(11, 46);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(29, 12);
            this.labelAddress.TabIndex = 13;
            this.labelAddress.Text = "地址";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DisplayMember = "Name";
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBoxGender, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBoxGender, System.Drawing.Color.White);
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(495, 16);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(61, 20);
            this.comboBoxGender.TabIndex = 12;
            this.comboBoxGender.ValueMember = "Id";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(447, 20);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(29, 12);
            this.labelGender.TabIndex = 11;
            this.labelGender.Text = "性别";
            // 
            // dateTimePickerBirthday
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.dateTimePickerBirthday, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.dateTimePickerBirthday, System.Drawing.Color.White);
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(684, 17);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(125, 21);
            this.dateTimePickerBirthday.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "委托起始日期";
            // 
            // textBoxIDNumber
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxIDNumber, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxIDNumber, System.Drawing.Color.White);
            this.textBoxIDNumber.Location = new System.Drawing.Point(220, 17);
            this.textBoxIDNumber.Name = "textBoxIDNumber";
            this.textBoxIDNumber.Size = new System.Drawing.Size(178, 21);
            this.textBoxIDNumber.TabIndex = 8;
            // 
            // labelIDNumber
            // 
            this.labelIDNumber.AutoSize = true;
            this.labelIDNumber.Location = new System.Drawing.Point(172, 20);
            this.labelIDNumber.Name = "labelIDNumber";
            this.labelIDNumber.Size = new System.Drawing.Size(41, 12);
            this.labelIDNumber.TabIndex = 7;
            this.labelIDNumber.Text = "身份证";
            // 
            // textBoxName
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxName, System.Drawing.Color.White);
            this.textBoxName.Location = new System.Drawing.Point(73, 17);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(86, 21);
            this.textBoxName.TabIndex = 6;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "企业法人";
            // 
            // textBox2
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBox2, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBox2, System.Drawing.Color.White);
            this.textBox2.Location = new System.Drawing.Point(604, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(97, 21);
            this.textBox2.TabIndex = 16;
            // 
            // ucBusinessScopeEditor
            // 
            this.ucBusinessScopeEditor.BackColor = System.Drawing.Color.Transparent;
            this.ucBusinessScopeEditor.Location = new System.Drawing.Point(73, 47);
            this.ucBusinessScopeEditor.Margin = new System.Windows.Forms.Padding(5);
            this.ucBusinessScopeEditor.Name = "ucBusinessScopeEditor";
            this.ucBusinessScopeEditor.SelectedBusinessScopes = "";
            this.ucBusinessScopeEditor.Size = new System.Drawing.Size(736, 143);
            this.ucBusinessScopeEditor.TabIndex = 18;
            // 
            // FormSupplyUnitSalesmanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSupplyUnitSalesmanEdit";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供货商业务人员编辑";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSupplyUnitId;
        private System.Windows.Forms.Label labelSupplyUnitId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIDNumber;
        private System.Windows.Forms.Label labelIDNumber;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider1;
        private System.Windows.Forms.Button buttonIDNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelIDCheckType;
        private System.Windows.Forms.TextBox textBoxIDCheckType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxChecked;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIDCheckUserName;
        private UserControls.ucBusinessScopeEditor ucBusinessScopeEditor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelAuthorizedDistrictId;
        private System.Windows.Forms.ComboBox comboBoxAuthorizedDistrictId;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
    }
}