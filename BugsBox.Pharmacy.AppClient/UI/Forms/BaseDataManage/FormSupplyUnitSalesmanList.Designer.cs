namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormSupplyUnitSalesmanList
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerOutDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOutDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIdNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSupplyUnitId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colSupplyUnitInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collegalperson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colButtonCheck = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pagerControl = new PagerControl.PagerControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePickerOutDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerOutDateFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxIdNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSupplyUnitId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(723, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Add1;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(640, 72);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 13;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuery.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Search;
            this.buttonQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonQuery.Location = new System.Drawing.Point(559, 72);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 12;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "~";
            // 
            // dateTimePickerOutDateTo
            // 
            this.dateTimePickerOutDateTo.Checked = false;
            this.dateTimePickerOutDateTo.Location = new System.Drawing.Point(304, 73);
            this.dateTimePickerOutDateTo.Name = "dateTimePickerOutDateTo";
            this.dateTimePickerOutDateTo.ShowCheckBox = true;
            this.dateTimePickerOutDateTo.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOutDateTo.TabIndex = 10;
            // 
            // dateTimePickerOutDateFrom
            // 
            this.dateTimePickerOutDateFrom.Checked = false;
            this.dateTimePickerOutDateFrom.Location = new System.Drawing.Point(81, 73);
            this.dateTimePickerOutDateFrom.Name = "dateTimePickerOutDateFrom";
            this.dateTimePickerOutDateFrom.ShowCheckBox = true;
            this.dateTimePickerOutDateFrom.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOutDateFrom.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "过期日期";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(53, 47);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(497, 21);
            this.textBoxAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "地址";
            // 
            // textBoxIdNumber
            // 
            this.textBoxIdNumber.Location = new System.Drawing.Point(360, 18);
            this.textBoxIdNumber.Name = "textBoxIdNumber";
            this.textBoxIdNumber.Size = new System.Drawing.Size(190, 21);
            this.textBoxIdNumber.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(211, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // comboBoxSupplyUnitId
            // 
            this.comboBoxSupplyUnitId.DisplayMember = "Name";
            this.comboBoxSupplyUnitId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplyUnitId.FormattingEnabled = true;
            this.comboBoxSupplyUnitId.Location = new System.Drawing.Point(53, 19);
            this.comboBoxSupplyUnitId.Name = "comboBoxSupplyUnitId";
            this.comboBoxSupplyUnitId.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSupplyUnitId.TabIndex = 1;
            this.comboBoxSupplyUnitId.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "供货商";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(723, 424);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务人员列表";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 361);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeight = 25;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSupplyUnitInfo,
            this.collegalperson,
            this.colName,
            this.colIDNumber,
            this.colAddress,
            this.colStartTime,
            this.colOutDate,
            this.colButtonEdit,
            this.colButtonCheck});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(713, 361);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_RowPrePaint);
            // 
            // colSupplyUnitInfo
            // 
            this.colSupplyUnitInfo.HeaderText = "所属供货商";
            this.colSupplyUnitInfo.Name = "colSupplyUnitInfo";
            this.colSupplyUnitInfo.ReadOnly = true;
            this.colSupplyUnitInfo.Width = 150;
            // 
            // collegalperson
            // 
            this.collegalperson.HeaderText = "法人";
            this.collegalperson.Name = "collegalperson";
            this.collegalperson.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colIDNumber
            // 
            this.colIDNumber.DataPropertyName = "IDNumber";
            this.colIDNumber.HeaderText = "身份证";
            this.colIDNumber.Name = "colIDNumber";
            this.colIDNumber.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "地址";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "委托起始日期";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colOutDate
            // 
            this.colOutDate.DataPropertyName = "OutDate";
            this.colOutDate.HeaderText = "委托截止日期";
            this.colOutDate.Name = "colOutDate";
            this.colOutDate.ReadOnly = true;
            // 
            // colButtonEdit
            // 
            this.colButtonEdit.HeaderText = "编辑";
            this.colButtonEdit.Name = "colButtonEdit";
            this.colButtonEdit.ReadOnly = true;
            this.colButtonEdit.Text = "编辑";
            this.colButtonEdit.UseColumnTextForButtonValue = true;
            this.colButtonEdit.Width = 65;
            // 
            // colButtonCheck
            // 
            this.colButtonCheck.HeaderText = "审核";
            this.colButtonCheck.Name = "colButtonCheck";
            this.colButtonCheck.ReadOnly = true;
            this.colButtonCheck.Text = "审核";
            this.colButtonCheck.UseColumnTextForButtonValue = true;
            this.colButtonCheck.Width = 65;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pagerControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 39);
            this.panel2.TabIndex = 3;
            // 
            // pagerControl
            // 
            this.pagerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagerControl.Location = new System.Drawing.Point(0, 0);
            this.pagerControl.Name = "pagerControl";
            this.pagerControl.PageIndex = 1;
            this.pagerControl.PageSize = 20;
            this.pagerControl.RecordCount = 0;
            this.pagerControl.Size = new System.Drawing.Size(713, 39);
            this.pagerControl.TabIndex = 1;
            this.pagerControl.DataPaging += new PagerControl.PagerControl.Paging(this.pagerControl_DataPaging);
            // 
            // FormSupplyUnitSalesmanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormSupplyUnitSalesmanList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "供货商业务人员管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSupplyUnitId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIdNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutDateTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PagerControl.PagerControl pagerControl;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplyUnitInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn collegalperson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutDate;
        private System.Windows.Forms.DataGridViewButtonColumn colButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colButtonCheck;

    }
}