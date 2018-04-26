namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormPurchaseUnitBuyerEdit
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
            this.comboBoxPurchaseLimitType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelIDCheckUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxChecked = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIDCheckType = new System.Windows.Forms.TextBox();
            this.labelIDCheckType = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
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
            this.comboBoxSupplyUnitId.Size = new System.Drawing.Size(368, 20);
            this.comboBoxSupplyUnitId.TabIndex = 2;
            this.comboBoxSupplyUnitId.ValueMember = "Id";
            // 
            // labelSupplyUnitId
            // 
            this.labelSupplyUnitId.AutoSize = true;
            this.labelSupplyUnitId.Location = new System.Drawing.Point(12, 22);
            this.labelSupplyUnitId.Name = "labelSupplyUnitId";
            this.labelSupplyUnitId.Size = new System.Drawing.Size(41, 12);
            this.labelSupplyUnitId.TabIndex = 4;
            this.labelSupplyUnitId.Text = "采购商";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxPurchaseLimitType);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.buttonCancel);
            this.groupBox2.Controls.Add(this.buttonOk);
            this.groupBox2.Controls.Add(this.checkBoxEnabled);
            this.groupBox2.Controls.Add(this.dateTimePickerOutDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelSupplyUnitId);
            this.groupBox2.Controls.Add(this.comboBoxSupplyUnitId);
            this.groupBox2.Location = new System.Drawing.Point(5, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 145);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务信息";
            // 
            // comboBoxPurchaseLimitType
            // 
            this.comboBoxPurchaseLimitType.DisplayMember = "Name";
            this.comboBoxPurchaseLimitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.comboBoxPurchaseLimitType, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.comboBoxPurchaseLimitType, System.Drawing.Color.White);
            this.comboBoxPurchaseLimitType.FormattingEnabled = true;
            this.comboBoxPurchaseLimitType.Location = new System.Drawing.Point(270, 43);
            this.comboBoxPurchaseLimitType.Name = "comboBoxPurchaseLimitType";
            this.comboBoxPurchaseLimitType.Size = new System.Drawing.Size(125, 20);
            this.comboBoxPurchaseLimitType.TabIndex = 23;
            this.comboBoxPurchaseLimitType.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "采购时限";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelIDCheckUserName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkBoxChecked);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxIDCheckType);
            this.groupBox3.Controls.Add(this.labelIDCheckType);
            this.groupBox3.Location = new System.Drawing.Point(29, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 70);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "核实信息";
            // 
            // labelIDCheckUserName
            // 
            this.labelIDCheckUserName.AutoSize = true;
            this.labelIDCheckUserName.Location = new System.Drawing.Point(239, 44);
            this.labelIDCheckUserName.Name = "labelIDCheckUserName";
            this.labelIDCheckUserName.Size = new System.Drawing.Size(23, 12);
            this.labelIDCheckUserName.TabIndex = 17;
            this.labelIDCheckUserName.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 46);
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
            this.buttonCancel.Location = new System.Drawing.Point(702, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(702, 76);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Location = new System.Drawing.Point(465, 20);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(48, 16);
            this.checkBoxEnabled.TabIndex = 14;
            this.checkBoxEnabled.Text = "启用";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerOutDate
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.dateTimePickerOutDate, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.dateTimePickerOutDate, System.Drawing.Color.White);
            this.dateTimePickerOutDate.Location = new System.Drawing.Point(74, 40);
            this.dateTimePickerOutDate.Name = "dateTimePickerOutDate";
            this.dateTimePickerOutDate.Size = new System.Drawing.Size(125, 21);
            this.dateTimePickerOutDate.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "过期日期";
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
            this.buttonIDNumber.Location = new System.Drawing.Point(407, 15);
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
            this.textBoxTel.Location = new System.Drawing.Point(544, 42);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(265, 21);
            this.textBoxTel.TabIndex = 16;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(463, 46);
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
            this.textBoxAddress.Size = new System.Drawing.Size(368, 21);
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
            this.comboBoxGender.Location = new System.Drawing.Point(748, 16);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(61, 20);
            this.comboBoxGender.TabIndex = 12;
            this.comboBoxGender.ValueMember = "Id";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(700, 20);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(29, 12);
            this.labelGender.TabIndex = 11;
            this.labelGender.Text = "性别";
            // 
            // dateTimePickerBirthday
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.dateTimePickerBirthday, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.dateTimePickerBirthday, System.Drawing.Color.White);
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(544, 16);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(125, 21);
            this.dateTimePickerBirthday.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "出生日期";
            // 
            // textBoxIDNumber
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxIDNumber, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxIDNumber, System.Drawing.Color.White);
            this.textBoxIDNumber.Location = new System.Drawing.Point(263, 16);
            this.textBoxIDNumber.Name = "textBoxIDNumber";
            this.textBoxIDNumber.Size = new System.Drawing.Size(178, 21);
            this.textBoxIDNumber.TabIndex = 8;
            // 
            // labelIDNumber
            // 
            this.labelIDNumber.AutoSize = true;
            this.labelIDNumber.Location = new System.Drawing.Point(194, 20);
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
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
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
            // FormPurchaseUnitBuyerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 237);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPurchaseUnitBuyerEdit";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户采购人员编辑";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPurchaseLimitType;
    }
}