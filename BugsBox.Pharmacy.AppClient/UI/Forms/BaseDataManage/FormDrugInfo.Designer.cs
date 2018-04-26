namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{ 
    partial class FormDrugInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            BugsBox.Pharmacy.Models.DrugInfo drugInfo1 = new BugsBox.Pharmacy.Models.DrugInfo();
            BugsBox.Pharmacy.Models.GoodsAdditionalProperty goodsAdditionalProperty1 = new BugsBox.Pharmacy.Models.GoodsAdditionalProperty();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApprovalDetails = new System.Windows.Forms.Button();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.pagerControl1 = new PagerControl.PagerControl();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugsBoxFocusColorProvider1 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ucGoodsInfo1 = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucGoodsInfo();
            this.dataGridViewDisableCheckBoxColumn1 = new BugsBox.Pharmacy.AppClient.UI.Forms.DataGridViewDisableCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.searchGroupBox.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSearch);
            this.tabControl1.Controls.Add(this.tabPageEdit);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1048, 551);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.dataGridView1);
            this.tabPageSearch.Controls.Add(this.searchGroupBox);
            this.tabPageSearch.Controls.Add(this.pagerControl1);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageSearch.Size = new System.Drawing.Size(1040, 525);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "数据查询";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1034, 419);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.button1);
            this.searchGroupBox.Controls.Add(this.btnApprovalDetails);
            this.searchGroupBox.Controls.Add(this.txtSearchKeyword);
            this.searchGroupBox.Controls.Add(this.label30);
            this.searchGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchGroupBox.Location = new System.Drawing.Point(3, 3);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(1034, 55);
            this.searchGroupBox.TabIndex = 3;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "查询条件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "详细";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApprovalDetails
            // 
            this.btnApprovalDetails.Enabled = false;
            this.btnApprovalDetails.Location = new System.Drawing.Point(616, 22);
            this.btnApprovalDetails.Name = "btnApprovalDetails";
            this.btnApprovalDetails.Size = new System.Drawing.Size(86, 23);
            this.btnApprovalDetails.TabIndex = 2;
            this.btnApprovalDetails.Text = "查看审批详情";
            this.btnApprovalDetails.UseVisualStyleBackColor = true;
            this.btnApprovalDetails.Click += new System.EventHandler(this.btnApprovalDetails_Click);
            // 
            // txtSearchKeyword
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.txtSearchKeyword, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.txtSearchKeyword, System.Drawing.Color.White);
            this.txtSearchKeyword.Location = new System.Drawing.Point(65, 22);
            this.txtSearchKeyword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(135, 21);
            this.txtSearchKeyword.TabIndex = 1;
            this.txtSearchKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchKeyword_KeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(14, 26);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 12);
            this.label30.TabIndex = 0;
            this.label30.Text = "关键字:";
            // 
            // pagerControl1
            // 
            this.pagerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerControl1.Location = new System.Drawing.Point(3, 477);
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 20;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(1034, 45);
            this.pagerControl1.TabIndex = 2;
            this.pagerControl1.DataPaging += new PagerControl.PagerControl.Paging(this.pagerControl1_DataPaging);
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this.panel1);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageEdit.Size = new System.Drawing.Size(1040, 525);
            this.tabPageEdit.TabIndex = 1;
            this.tabPageEdit.Text = "编辑数据";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.textBoxTime);
            this.panel1.Controls.Add(this.textBoxUserName);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.ucGoodsInfo1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 639);
            this.panel1.TabIndex = 0;
            // 
            // textBoxTime
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxTime, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxTime, System.Drawing.Color.White);
            this.textBoxTime.Location = new System.Drawing.Point(746, 520);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(129, 21);
            this.textBoxTime.TabIndex = 145;
            // 
            // textBoxUserName
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.textBoxUserName, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.textBoxUserName, System.Drawing.Color.White);
            this.textBoxUserName.Location = new System.Drawing.Point(553, 520);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(100, 21);
            this.textBoxUserName.TabIndex = 146;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(689, 523);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(53, 12);
            this.label55.TabIndex = 143;
            this.label55.Text = "操作时间";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(485, 523);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 144;
            this.label34.Text = "操作人员";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripButton2,
            this.btnSearch,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnDelete,
            this.btnModify,
            this.toolStripSeparator2,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 28);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Search;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 28);
            this.btnSearch.Text = "查询";
            this.btnSearch.ToolTipText = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 28);
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Del;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 28);
            this.btnDelete.Text = "删除";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Edit;
            this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(60, 28);
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Save1;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 28);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 28);
            this.btnCancel.Text = "返回";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.data;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(108, 28);
            this.toolStripButton1.Text = "导出品种信息";
            this.toolStripButton1.ToolTipText = "先在左下角‘每页显示‘中输入要查询的结果数量，然后回车，得到查询结果，再执行导出操作。";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "编码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "商品类型";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn3.HeaderText = "商品名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BarCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "条形码";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DictionarySpecificationCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "规格";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DictionaryDosageCode";
            this.dataGridViewTextBoxColumn6.HeaderText = "剂型";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DictionaryMeasurementUnitCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "计量单位";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FactoryName";
            this.dataGridViewTextBoxColumn8.HeaderText = "厂家";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SpecialDrugCategoryCode";
            this.dataGridViewTextBoxColumn9.HeaderText = "特殊药物";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "BusinessScopeCode";
            this.dataGridViewTextBoxColumn10.HeaderText = "经营范围";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PurchaseManageCategoryDetailCode";
            this.dataGridViewTextBoxColumn11.HeaderText = "管理分类";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DrugCategoryCode";
            this.dataGridViewTextBoxColumn12.HeaderText = "药物分类";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "MedicalCategoryDetailCode";
            this.dataGridViewTextBoxColumn13.HeaderText = "医疗分类";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "DrugClinicalCategoryCode";
            this.dataGridViewTextBoxColumn14.HeaderText = "临床分类";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DrugStorageTypeCode";
            this.dataGridViewTextBoxColumn15.HeaderText = "存储条件";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "DictionaryPiecemealUnitCode";
            this.dataGridViewTextBoxColumn16.HeaderText = "拆零单位";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Web_info;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 28);
            this.toolStripButton2.Text = "查看明细";
            this.toolStripButton2.ToolTipText = "查询";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // ucGoodsInfo1
            // 
            this.ucGoodsInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            drugInfo1.ApprovalDate = new System.DateTime(((long)(0)));
            drugInfo1.ApprovalStatus = BugsBox.Pharmacy.Models.ApprovalStatus.NonApproval;
            drugInfo1.ApprovalStatusValue = 0;
            drugInfo1.BarCode = null;
            drugInfo1.BigPackage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.BusinessScopeCode = null;
            drugInfo1.Code = null;
            drugInfo1.CommendedUser = null;
            drugInfo1.CreateTime = new System.DateTime(((long)(0)));
            drugInfo1.CreateUserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.Deleted = false;
            drugInfo1.DeleteTime = null;
            drugInfo1.Description = null;
            drugInfo1.DictionaryDosageCode = null;
            drugInfo1.DictionaryMeasurementUnitCode = null;
            drugInfo1.DictionaryPiecemealUnitCode = null;
            drugInfo1.DictionarySpecificationCode = null;
            drugInfo1.DictionaryUserDefinedTypeCode = null;
            drugInfo1.DocCode = null;
            drugInfo1.DrugCategoryCode = null;
            drugInfo1.DrugClinicalCategoryCode = null;
            drugInfo1.DrugInventoryRecords = null;
            drugInfo1.DrugStorageTypeCode = null;
            drugInfo1.Enabled = false;
            drugInfo1.FactoryName = null;
            drugInfo1.FactoryNameAbbreviation = null;
            drugInfo1.FlowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.Function = null;
            drugInfo1.GoodsAdditionalProperty = null;
            drugInfo1.GoodsType = BugsBox.Pharmacy.Models.GoodsType.DrugDomestic;
            drugInfo1.GoodsTypeValue = 0;
            drugInfo1.Id = new System.Guid("839843e9-24a4-4248-9c0a-54b5520e503a");
            drugInfo1.Ingredient = null;
            drugInfo1.InstEntProductLiscencePermitNumber = null;
            drugInfo1.IsApproval = false;
            drugInfo1.IsImport = false;
            drugInfo1.IsLock = false;
            drugInfo1.IsMainMaintenance = false;
            drugInfo1.IsMedicalInsurance = false;
            drugInfo1.IsPrescription = false;
            drugInfo1.IsSpecialDrugCategory = false;
            drugInfo1.LicensePermissionNumber = null;
            drugInfo1.LimitedLowPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.LimitedUpPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.LockRemark = null;
            drugInfo1.LowSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.MaxInventoryCount = 0;
            drugInfo1.MedicalCategoryDetailCode = null;
            drugInfo1.MiddlePackage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.MinInventoryCount = 0;
            drugInfo1.NationalSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.Origin = null;
            drugInfo1.Package = null;
            drugInfo1.PackageAmount = 0;
            drugInfo1.PerformanceStandards = null;
            drugInfo1.PermitDate = new System.DateTime(((long)(0)));
            drugInfo1.PermitLicenseCode = null;
            drugInfo1.PermitOutDate = new System.DateTime(((long)(0)));
            drugInfo1.PiecemealNumber = 0;
            drugInfo1.PiecemealSpecification = null;
            drugInfo1.Pinyin = null;
            drugInfo1.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.ProductEnglishName = null;
            drugInfo1.ProductGeneralName = null;
            drugInfo1.ProductName = null;
            drugInfo1.ProductOtherName = null;
            drugInfo1.PurchaseManageCategoryDetailCode = null;
            drugInfo1.PurchasePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.RetailPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.SalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.SmallPackage = 0;
            drugInfo1.SpecialDrugCategoryCode = null;
            drugInfo1.StandardCode = null;
            drugInfo1.TagPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            drugInfo1.UpdateTime = new System.DateTime(((long)(0)));
            drugInfo1.UpdateUserId = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.Valid = false;
            drugInfo1.ValidPeriod = 0;
            drugInfo1.ValidRemark = null;
            drugInfo1.WareHouses = new System.Guid("00000000-0000-0000-0000-000000000000");
            drugInfo1.WareHouseZones = null;
            drugInfo1.WholeSalePrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucGoodsInfo1.DrugInfo = drugInfo1;
            this.ucGoodsInfo1.FlowTypeID = new System.Guid("00000000-0000-0000-0000-000000000000");
            goodsAdditionalProperty1.CareFunction = null;
            goodsAdditionalProperty1.Deleted = false;
            goodsAdditionalProperty1.DeleteTime = null;
            goodsAdditionalProperty1.DrugInfo = null;
            goodsAdditionalProperty1.DrugInfoId = new System.Guid("00000000-0000-0000-0000-000000000000");
            goodsAdditionalProperty1.FactoryAddress = null;
            goodsAdditionalProperty1.FactoryAddressEnglish = null;
            goodsAdditionalProperty1.FactoryNameEnglish = null;
            goodsAdditionalProperty1.HealthPermit = null;
            goodsAdditionalProperty1.Id = new System.Guid("88e59bfc-ada0-4ef9-8fb7-458ca65160dd");
            goodsAdditionalProperty1.LandmarkIngredient = null;
            goodsAdditionalProperty1.LicensePermissionDate = new System.DateTime(((long)(0)));
            goodsAdditionalProperty1.MainIngredient = null;
            goodsAdditionalProperty1.NotSuitablePeople = null;
            goodsAdditionalProperty1.ProductAddress = null;
            goodsAdditionalProperty1.ProductAddressEnglish = null;
            goodsAdditionalProperty1.ProductCountry = null;
            goodsAdditionalProperty1.ProductCountryEnglish = null;
            goodsAdditionalProperty1.PutOnRecord = null;
            goodsAdditionalProperty1.PutOnRecordDate = new System.DateTime(((long)(0)));
            goodsAdditionalProperty1.RegCode = null;
            goodsAdditionalProperty1.RegProxyCompany = null;
            goodsAdditionalProperty1.SuitablePeople = null;
            goodsAdditionalProperty1.UsageAndDosage = null;
            this.ucGoodsInfo1.GoodsAdditional = goodsAdditionalProperty1;
            this.ucGoodsInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucGoodsInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ucGoodsInfo1.Name = "ucGoodsInfo1";
            this.ucGoodsInfo1.RunMode = BugsBox.Pharmacy.UI.Common.FormRunMode.Add;
            this.ucGoodsInfo1.SelectedWarehouseZones = "";
            this.ucGoodsInfo1.Size = new System.Drawing.Size(956, 639);
            this.ucGoodsInfo1.TabIndex = 0;
            // 
            // dataGridViewDisableCheckBoxColumn1
            // 
            this.dataGridViewDisableCheckBoxColumn1.DataPropertyName = "Selected";
            this.dataGridViewDisableCheckBoxColumn1.FalseValue = "NoSelected";
            this.dataGridViewDisableCheckBoxColumn1.HeaderText = "";
            this.dataGridViewDisableCheckBoxColumn1.IndeterminateValue = "Indeterminate";
            this.dataGridViewDisableCheckBoxColumn1.Name = "dataGridViewDisableCheckBoxColumn1";
            this.dataGridViewDisableCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableCheckBoxColumn1.TrueValue = "Selected";
            this.dataGridViewDisableCheckBoxColumn1.Width = 20;
            // 
            // FormDrugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 582);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDrugInfo";
            this.Text = "药品信息管理";
            this.Load += new System.EventHandler(this.FormDrugInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.tabPageEdit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private PagerControl.PagerControl pagerControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Panel panel1;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private UserControls.ucGoodsInfo ucGoodsInfo1;
        private System.Windows.Forms.Button btnApprovalDetails;
        private DataGridViewDisableCheckBoxColumn dataGridViewDisableCheckBoxColumn1;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}