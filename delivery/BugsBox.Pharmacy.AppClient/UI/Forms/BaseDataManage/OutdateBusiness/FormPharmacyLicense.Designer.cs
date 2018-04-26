namespace BugsBox.Pharmacy.AppClient.UI.Forms.OutdateBusiness
{
    partial class FormPharmacyLicense
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxLicenseType = new System.Windows.Forms.ComboBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.dateTimePickerOutDateTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerOutDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRegAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUnitName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLicenseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colLicenseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssuanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxLicenseType);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.dateTimePickerOutDateTo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePickerOutDateFrom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxRegAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxUnitName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxLicenseCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(1397, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "证书类型";
            // 
            // comboBoxLicenseType
            // 
            this.comboBoxLicenseType.DisplayMember = "Name";
            this.comboBoxLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLicenseType.FormattingEnabled = true;
            this.comboBoxLicenseType.Location = new System.Drawing.Point(98, 24);
            this.comboBoxLicenseType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxLicenseType.Name = "comboBoxLicenseType";
            this.comboBoxLicenseType.Size = new System.Drawing.Size(296, 26);
            this.comboBoxLicenseType.TabIndex = 34;
            this.comboBoxLicenseType.ValueMember = "ID";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuery.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Search;
            this.buttonQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonQuery.Location = new System.Drawing.Point(1273, 148);
            this.buttonQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(112, 34);
            this.buttonQuery.TabIndex = 33;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // dateTimePickerOutDateTo
            // 
            this.dateTimePickerOutDateTo.Checked = false;
            this.dateTimePickerOutDateTo.Location = new System.Drawing.Point(489, 144);
            this.dateTimePickerOutDateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerOutDateTo.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerOutDateTo.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerOutDateTo.Name = "dateTimePickerOutDateTo";
            this.dateTimePickerOutDateTo.ShowCheckBox = true;
            this.dateTimePickerOutDateTo.Size = new System.Drawing.Size(298, 28);
            this.dateTimePickerOutDateTo.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 153);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "至";
            // 
            // dateTimePickerOutDateFrom
            // 
            this.dateTimePickerOutDateFrom.Checked = false;
            this.dateTimePickerOutDateFrom.Location = new System.Drawing.Point(96, 144);
            this.dateTimePickerOutDateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerOutDateFrom.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerOutDateFrom.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerOutDateFrom.Name = "dateTimePickerOutDateFrom";
            this.dateTimePickerOutDateFrom.ShowCheckBox = true;
            this.dateTimePickerOutDateFrom.Size = new System.Drawing.Size(298, 28);
            this.dateTimePickerOutDateFrom.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "过期日期";
            // 
            // textBoxRegAddress
            // 
            this.textBoxRegAddress.Location = new System.Drawing.Point(489, 104);
            this.textBoxRegAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRegAddress.Name = "textBoxRegAddress";
            this.textBoxRegAddress.Size = new System.Drawing.Size(358, 28);
            this.textBoxRegAddress.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "注册地址";
            // 
            // textBoxUnitName
            // 
            this.textBoxUnitName.Location = new System.Drawing.Point(98, 104);
            this.textBoxUnitName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUnitName.Name = "textBoxUnitName";
            this.textBoxUnitName.Size = new System.Drawing.Size(296, 28);
            this.textBoxUnitName.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "企业名称";
            // 
            // textBoxLicenseCode
            // 
            this.textBoxLicenseCode.Location = new System.Drawing.Point(489, 63);
            this.textBoxLicenseCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLicenseCode.Name = "textBoxLicenseCode";
            this.textBoxLicenseCode.Size = new System.Drawing.Size(358, 28);
            this.textBoxLicenseCode.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "证书号";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(96, 63);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(298, 28);
            this.textBoxCode.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "注册号";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(489, 22);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(358, 28);
            this.textBoxName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "证书名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(1397, 821);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "证书列表";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeight = 25;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLicenseType,
            this.colName,
            this.colUnitName,
            this.colRegAddress,
            this.colCode,
            this.colLicenseCode,
            this.colIssuanceDate,
            this.colOutDate});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(8, 29);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1381, 784);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // colLicenseType
            // 
            this.colLicenseType.Frozen = true;
            this.colLicenseType.HeaderText = "证书类型";
            this.colLicenseType.Name = "colLicenseType";
            this.colLicenseType.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "证书名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colUnitName
            // 
            this.colUnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnitName.DataPropertyName = "UnitName";
            this.colUnitName.HeaderText = "企业名称";
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.ReadOnly = true;
            // 
            // colRegAddress
            // 
            this.colRegAddress.DataPropertyName = "RegAddress";
            this.colRegAddress.HeaderText = "注册地址";
            this.colRegAddress.Name = "colRegAddress";
            this.colRegAddress.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "注册号";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colLicenseCode
            // 
            this.colLicenseCode.DataPropertyName = "LicenseCode";
            this.colLicenseCode.HeaderText = "证书号";
            this.colLicenseCode.Name = "colLicenseCode";
            this.colLicenseCode.ReadOnly = true;
            // 
            // colIssuanceDate
            // 
            this.colIssuanceDate.DataPropertyName = "IssuanceDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colIssuanceDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIssuanceDate.HeaderText = "签发日期";
            this.colIssuanceDate.Name = "colIssuanceDate";
            this.colIssuanceDate.ReadOnly = true;
            // 
            // colOutDate
            // 
            this.colOutDate.DataPropertyName = "OutDate";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colOutDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colOutDate.HeaderText = "过期日期";
            this.colOutDate.Name = "colOutDate";
            this.colOutDate.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1153, 148);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 33;
            this.button1.Text = "导出数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPharmacyLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 1032);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormPharmacyLicense";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.ShowInTaskbar = false;
            this.Text = "证照过期查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxLicenseCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUnitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRegAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDateTo;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBoxLicenseType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssuanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutDate;
        private System.Windows.Forms.Button button1;
    }
}