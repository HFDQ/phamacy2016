namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormAllDrugInventoryRecordSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pagerControl1 = new PagerControl.PagerControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCheckBoxSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStripTitle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colDrugInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurgInventoryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHouseInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.Column4 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.Column5 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column6 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column7 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column8 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column9 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column10 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.Column11 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxWarehouseZones = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.dateTimePickerOutValidDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOutValidDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPruductDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPruductDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInInventoryDateTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInInventoryDateFrom = new System.Windows.Forms.DateTimePicker();
            this.textBoxBatchNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDrugInfoName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumericUpDownColumn1 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn2 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewCalendarColumn1 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewCalendarColumn2 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewNumericUpDownColumn3 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn4 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn5 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn6 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn7 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn8 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn9 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.Location = new System.Drawing.Point(58, 457);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 0;
            this.pagerControl1.PageSize = 20;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(832, 32);
            this.pagerControl1.TabIndex = 2;
            this.pagerControl1.DataPaging += new PagerControl.PagerControl.Paging(this.pagerControl1_DataPaging);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBoxSelect,
            this.colDrugInfo,
            this.colDurgInventoryType,
            this.colWareHouseInfo,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripTitle;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(832, 335);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // colCheckBoxSelect
            // 
            this.colCheckBoxSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCheckBoxSelect.ContextMenuStrip = this.contextMenuStripTitle;
            this.colCheckBoxSelect.FalseValue = "False";
            this.colCheckBoxSelect.FillWeight = 55F;
            this.colCheckBoxSelect.Frozen = true;
            this.colCheckBoxSelect.HeaderText = "选择";
            this.colCheckBoxSelect.MinimumWidth = 55;
            this.colCheckBoxSelect.Name = "colCheckBoxSelect";
            this.colCheckBoxSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCheckBoxSelect.TrueValue = "True";
            this.colCheckBoxSelect.Width = 55;
            // 
            // contextMenuStripTitle
            // 
            this.contextMenuStripTitle.Name = "contextMenuStripTitle";
            this.contextMenuStripTitle.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripTitle.Text = "显示列";
            // 
            // colDrugInfo
            // 
            this.colDrugInfo.Frozen = true;
            this.colDrugInfo.HeaderText = "药物基本信息";
            this.colDrugInfo.MinimumWidth = 300;
            this.colDrugInfo.Name = "colDrugInfo";
            this.colDrugInfo.ReadOnly = true;
            this.colDrugInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDrugInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDrugInfo.Width = 300;
            // 
            // colDurgInventoryType
            // 
            this.colDurgInventoryType.HeaderText = "入库类型";
            this.colDurgInventoryType.MinimumWidth = 65;
            this.colDurgInventoryType.Name = "colDurgInventoryType";
            this.colDurgInventoryType.ReadOnly = true;
            this.colDurgInventoryType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDurgInventoryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDurgInventoryType.Width = 65;
            // 
            // colWareHouseInfo
            // 
            this.colWareHouseInfo.HeaderText = "存放位置";
            this.colWareHouseInfo.Name = "colWareHouseInfo";
            this.colWareHouseInfo.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BatchNumber";
            this.Column2.HeaderText = "生产批号";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PruductDate";
            this.Column3.HeaderText = "生产日期";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OutValidDate";
            this.Column4.HeaderText = "过期日期";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "InInventoryCount";
            this.Column5.DecimalPlaces = 0;
            this.Column5.HeaderText = "入库数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CurrentInventoryCount";
            this.Column6.DecimalPlaces = 0;
            this.Column6.HeaderText = "当前库存";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "SalesCount";
            this.Column7.DecimalPlaces = 0;
            this.Column7.HeaderText = "已销售";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "RetailCount";
            this.Column8.DecimalPlaces = 0;
            this.Column8.HeaderText = "已经零售";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "RetailDismantingAmount";
            this.Column9.DecimalPlaces = 0;
            this.Column9.HeaderText = "待售拆零";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "OnRetailCount";
            this.Column10.DecimalPlaces = 0;
            this.Column10.HeaderText = "已经售拆零";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CanSaleNum";
            this.Column11.DecimalPlaces = 0;
            this.Column11.HeaderText = "可销售零售数量";
            this.Column11.Name = "Column11";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(680, 478);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(769, 478);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxWarehouseZones);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.dateTimePickerOutValidDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerOutValidDateFrom);
            this.groupBox1.Controls.Add(this.pagerControl1);
            this.groupBox1.Controls.Add(this.dateTimePickerPruductDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerPruductDateFrom);
            this.groupBox1.Controls.Add(this.dateTimePickerInInventoryDateTo);
            this.groupBox1.Controls.Add(this.dateTimePickerInInventoryDateFrom);
            this.groupBox1.Controls.Add(this.textBoxBatchNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDrugInfoName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // comboBoxWarehouseZones
            // 
            this.comboBoxWarehouseZones.FormattingEnabled = true;
            this.comboBoxWarehouseZones.Location = new System.Drawing.Point(408, 44);
            this.comboBoxWarehouseZones.Name = "comboBoxWarehouseZones";
            this.comboBoxWarehouseZones.Size = new System.Drawing.Size(252, 20);
            this.comboBoxWarehouseZones.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "存放库区";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuery.Location = new System.Drawing.Point(704, 42);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 2;
            this.buttonQuery.Text = "查   询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // dateTimePickerOutValidDateTo
            // 
            this.dateTimePickerOutValidDateTo.Checked = false;
            this.dateTimePickerOutValidDateTo.Location = new System.Drawing.Point(538, 74);
            this.dateTimePickerOutValidDateTo.Name = "dateTimePickerOutValidDateTo";
            this.dateTimePickerOutValidDateTo.ShowCheckBox = true;
            this.dateTimePickerOutValidDateTo.Size = new System.Drawing.Size(122, 21);
            this.dateTimePickerOutValidDateTo.TabIndex = 12;
            this.dateTimePickerOutValidDateTo.ValueChanged += new System.EventHandler(this.dateTimePickerOutValidDate_ValueChanged);
            // 
            // dateTimePickerOutValidDateFrom
            // 
            this.dateTimePickerOutValidDateFrom.Checked = false;
            this.dateTimePickerOutValidDateFrom.Location = new System.Drawing.Point(408, 74);
            this.dateTimePickerOutValidDateFrom.Name = "dateTimePickerOutValidDateFrom";
            this.dateTimePickerOutValidDateFrom.ShowCheckBox = true;
            this.dateTimePickerOutValidDateFrom.Size = new System.Drawing.Size(124, 21);
            this.dateTimePickerOutValidDateFrom.TabIndex = 11;
            this.dateTimePickerOutValidDateFrom.ValueChanged += new System.EventHandler(this.dateTimePickerOutValidDate_ValueChanged);
            // 
            // dateTimePickerPruductDateTo
            // 
            this.dateTimePickerPruductDateTo.Checked = false;
            this.dateTimePickerPruductDateTo.Location = new System.Drawing.Point(208, 72);
            this.dateTimePickerPruductDateTo.Name = "dateTimePickerPruductDateTo";
            this.dateTimePickerPruductDateTo.ShowCheckBox = true;
            this.dateTimePickerPruductDateTo.Size = new System.Drawing.Size(135, 21);
            this.dateTimePickerPruductDateTo.TabIndex = 10;
            this.dateTimePickerPruductDateTo.ValueChanged += new System.EventHandler(this.dateTimePickerPruductDate_ValueChanged);
            // 
            // dateTimePickerPruductDateFrom
            // 
            this.dateTimePickerPruductDateFrom.Checked = false;
            this.dateTimePickerPruductDateFrom.Location = new System.Drawing.Point(74, 72);
            this.dateTimePickerPruductDateFrom.Name = "dateTimePickerPruductDateFrom";
            this.dateTimePickerPruductDateFrom.ShowCheckBox = true;
            this.dateTimePickerPruductDateFrom.Size = new System.Drawing.Size(128, 21);
            this.dateTimePickerPruductDateFrom.TabIndex = 9;
            this.dateTimePickerPruductDateFrom.ValueChanged += new System.EventHandler(this.dateTimePickerPruductDate_ValueChanged);
            // 
            // dateTimePickerInInventoryDateTo
            // 
            this.dateTimePickerInInventoryDateTo.Checked = false;
            this.dateTimePickerInInventoryDateTo.Location = new System.Drawing.Point(208, 44);
            this.dateTimePickerInInventoryDateTo.Name = "dateTimePickerInInventoryDateTo";
            this.dateTimePickerInInventoryDateTo.ShowCheckBox = true;
            this.dateTimePickerInInventoryDateTo.Size = new System.Drawing.Size(135, 21);
            this.dateTimePickerInInventoryDateTo.TabIndex = 8;
            this.dateTimePickerInInventoryDateTo.ValueChanged += new System.EventHandler(this.dateTimePickerInInventoryDate_ValueChanged);
            // 
            // dateTimePickerInInventoryDateFrom
            // 
            this.dateTimePickerInInventoryDateFrom.Checked = false;
            this.dateTimePickerInInventoryDateFrom.Location = new System.Drawing.Point(74, 44);
            this.dateTimePickerInInventoryDateFrom.Name = "dateTimePickerInInventoryDateFrom";
            this.dateTimePickerInInventoryDateFrom.ShowCheckBox = true;
            this.dateTimePickerInInventoryDateFrom.Size = new System.Drawing.Size(128, 21);
            this.dateTimePickerInInventoryDateFrom.TabIndex = 7;
            this.dateTimePickerInInventoryDateFrom.ValueChanged += new System.EventHandler(this.dateTimePickerInInventoryDate_ValueChanged);
            // 
            // textBoxBatchNumber
            // 
            this.textBoxBatchNumber.Location = new System.Drawing.Point(408, 16);
            this.textBoxBatchNumber.Name = "textBoxBatchNumber";
            this.textBoxBatchNumber.Size = new System.Drawing.Size(252, 21);
            this.textBoxBatchNumber.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "过期日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "生产日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "生产批号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "入库日期";
            // 
            // textBoxDrugInfoName
            // 
            this.textBoxDrugInfoName.Location = new System.Drawing.Point(74, 14);
            this.textBoxDrugInfoName.Name = "textBoxDrugInfoName";
            this.textBoxDrugInfoName.Size = new System.Drawing.Size(269, 21);
            this.textBoxDrugInfoName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "药物名称";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 65F;
            this.dataGridViewTextBoxColumn1.HeaderText = "药物基本信息";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "药物基本信息";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn1.HeaderText = "入库类型";
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn2
            // 
            this.dataGridViewNumericUpDownColumn2.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn2.HeaderText = "生产批号";
            this.dataGridViewNumericUpDownColumn2.Name = "dataGridViewNumericUpDownColumn2";
            this.dataGridViewNumericUpDownColumn2.ReadOnly = true;
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.HeaderText = "生产日期";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.ReadOnly = true;
            // 
            // dataGridViewCalendarColumn2
            // 
            this.dataGridViewCalendarColumn2.HeaderText = "过期日期";
            this.dataGridViewCalendarColumn2.Name = "dataGridViewCalendarColumn2";
            this.dataGridViewCalendarColumn2.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn3
            // 
            this.dataGridViewNumericUpDownColumn3.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn3.HeaderText = "入库数量";
            this.dataGridViewNumericUpDownColumn3.Name = "dataGridViewNumericUpDownColumn3";
            this.dataGridViewNumericUpDownColumn3.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn4
            // 
            this.dataGridViewNumericUpDownColumn4.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn4.HeaderText = "当前库存";
            this.dataGridViewNumericUpDownColumn4.Name = "dataGridViewNumericUpDownColumn4";
            this.dataGridViewNumericUpDownColumn4.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn5
            // 
            this.dataGridViewNumericUpDownColumn5.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn5.HeaderText = "已销售";
            this.dataGridViewNumericUpDownColumn5.Name = "dataGridViewNumericUpDownColumn5";
            this.dataGridViewNumericUpDownColumn5.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn6
            // 
            this.dataGridViewNumericUpDownColumn6.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn6.HeaderText = "已经零售";
            this.dataGridViewNumericUpDownColumn6.Name = "dataGridViewNumericUpDownColumn6";
            this.dataGridViewNumericUpDownColumn6.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn7
            // 
            this.dataGridViewNumericUpDownColumn7.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn7.HeaderText = "待售拆零";
            this.dataGridViewNumericUpDownColumn7.Name = "dataGridViewNumericUpDownColumn7";
            this.dataGridViewNumericUpDownColumn7.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn8
            // 
            this.dataGridViewNumericUpDownColumn8.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn8.HeaderText = "已经售拆零";
            this.dataGridViewNumericUpDownColumn8.Name = "dataGridViewNumericUpDownColumn8";
            this.dataGridViewNumericUpDownColumn8.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn9
            // 
            this.dataGridViewNumericUpDownColumn9.DecimalPlaces = 0;
            this.dataGridViewNumericUpDownColumn9.HeaderText = "可销\\零售数量";
            this.dataGridViewNumericUpDownColumn9.Name = "dataGridViewNumericUpDownColumn9";
            this.dataGridViewNumericUpDownColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "药物基本信息";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormAllDrugInventoryRecordSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 513);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(700, 540);
            this.Name = "FormAllDrugInventoryRecordSelector";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "所有药品库存选择";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagerControl.PagerControl pagerControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutValidDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerOutValidDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerPruductDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerPruductDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerInInventoryDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerInInventoryDateFrom;
        private System.Windows.Forms.TextBox textBoxBatchNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDrugInfoName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxWarehouseZones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTitle;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
        private Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn2;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn3;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn4;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn5;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn6;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn7;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn8;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBoxSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrugInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurgInventoryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHouseInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Windows.Forms.DataGridViewCalendarColumn Column3;
        private Windows.Forms.DataGridViewCalendarColumn Column4;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column5;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column6;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column7;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column8;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column9;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column10;
        private Windows.Forms.DataGridViewNumericUpDownColumn Column11;
    }
}