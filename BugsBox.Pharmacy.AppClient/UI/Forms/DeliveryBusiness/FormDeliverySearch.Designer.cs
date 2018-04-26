namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{
    partial class FormDeliverySearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDelivery = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.货单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.药品件数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收货公司 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发货地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收货地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.运输方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配送状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.委托人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.委托人电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.运输公司 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车辆信息 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预约时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预约者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预约单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受理日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受理者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.受理单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.取消时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.取消者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.取消单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.签收时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.签收者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.签收单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销退申请时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销退申请者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销退申请单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.pagerControl = new PagerControl.PagerControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDelivery
            // 
            this.dgvDelivery.AllowUserToAddRows = false;
            this.dgvDelivery.AllowUserToDeleteRows = false;
            this.dgvDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelivery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.配送日期,
            this.货单号,
            this.药品件数,
            this.收货公司,
            this.配送方式,
            this.发货地址,
            this.收货地址,
            this.运输方式,
            this.配送状态,
            this.委托人,
            this.委托人电话,
            this.运输公司,
            this.车辆信息,
            this.备注,
            this.预约时间,
            this.预约者,
            this.预约单号,
            this.受理日期,
            this.受理者,
            this.受理单号,
            this.取消时间,
            this.取消者,
            this.取消单号,
            this.出库时间,
            this.出库者,
            this.出库单号,
            this.签收时间,
            this.签收者,
            this.签收单号,
            this.销退申请时间,
            this.销退申请者,
            this.销退申请单号,
            this.查看详细});
            this.dgvDelivery.Location = new System.Drawing.Point(0, 86);
            this.dgvDelivery.Name = "dgvDelivery";
            this.dgvDelivery.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelivery.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDelivery.RowTemplate.Height = 23;
            this.dgvDelivery.Size = new System.Drawing.Size(802, 235);
            this.dgvDelivery.TabIndex = 11;
            this.dgvDelivery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDelivery_CellContentClick);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 80;
            // 
            // 配送日期
            // 
            this.配送日期.DataPropertyName = "DeliveryTime";
            this.配送日期.HeaderText = "配送日期";
            this.配送日期.Name = "配送日期";
            this.配送日期.ReadOnly = true;
            // 
            // 货单号
            // 
            this.货单号.DataPropertyName = "ManifestNumber";
            this.货单号.HeaderText = "货单号";
            this.货单号.Name = "货单号";
            this.货单号.ReadOnly = true;
            this.货单号.Width = 120;
            // 
            // 药品件数
            // 
            this.药品件数.DataPropertyName = "DrugsCount";
            this.药品件数.HeaderText = "药品件数";
            this.药品件数.Name = "药品件数";
            this.药品件数.ReadOnly = true;
            // 
            // 收货公司
            // 
            this.收货公司.DataPropertyName = "ReceivingCompasnyName";
            this.收货公司.HeaderText = "销售客户";
            this.收货公司.Name = "收货公司";
            this.收货公司.ReadOnly = true;
            this.收货公司.Width = 120;
            // 
            // 配送方式
            // 
            this.配送方式.HeaderText = "配送方式";
            this.配送方式.Name = "配送方式";
            this.配送方式.ReadOnly = true;
            // 
            // 发货地址
            // 
            this.发货地址.DataPropertyName = "ShippingAddress";
            this.发货地址.HeaderText = "发货地址";
            this.发货地址.Name = "发货地址";
            this.发货地址.ReadOnly = true;
            // 
            // 收货地址
            // 
            this.收货地址.DataPropertyName = "DeliveryAddress";
            this.收货地址.HeaderText = "收货地址";
            this.收货地址.Name = "收货地址";
            this.收货地址.ReadOnly = true;
            // 
            // 运输方式
            // 
            this.运输方式.HeaderText = "运输方式";
            this.运输方式.Name = "运输方式";
            this.运输方式.ReadOnly = true;
            // 
            // 配送状态
            // 
            this.配送状态.HeaderText = "配送状态";
            this.配送状态.Name = "配送状态";
            this.配送状态.ReadOnly = true;
            // 
            // 委托人
            // 
            this.委托人.DataPropertyName = "Principal";
            this.委托人.HeaderText = "委托人";
            this.委托人.Name = "委托人";
            this.委托人.ReadOnly = true;
            // 
            // 委托人电话
            // 
            this.委托人电话.DataPropertyName = "PrincipalPhone";
            this.委托人电话.HeaderText = "委托人电话";
            this.委托人电话.Name = "委托人电话";
            this.委托人电话.ReadOnly = true;
            // 
            // 运输公司
            // 
            this.运输公司.DataPropertyName = "TransportCompany";
            this.运输公司.HeaderText = "运输公司";
            this.运输公司.Name = "运输公司";
            this.运输公司.ReadOnly = true;
            // 
            // 车辆信息
            // 
            this.车辆信息.DataPropertyName = "VehicleInfo";
            this.车辆信息.HeaderText = "车辆信息";
            this.车辆信息.Name = "车辆信息";
            this.车辆信息.ReadOnly = true;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "Memo";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            // 
            // 预约时间
            // 
            this.预约时间.DataPropertyName = "ReservationTime";
            this.预约时间.HeaderText = "预约时间";
            this.预约时间.Name = "预约时间";
            this.预约时间.ReadOnly = true;
            // 
            // 预约者
            // 
            this.预约者.HeaderText = "预约者";
            this.预约者.Name = "预约者";
            this.预约者.ReadOnly = true;
            this.预约者.Width = 120;
            // 
            // 预约单号
            // 
            this.预约单号.DataPropertyName = "ReservationNo";
            this.预约单号.HeaderText = "预约单号";
            this.预约单号.Name = "预约单号";
            this.预约单号.ReadOnly = true;
            // 
            // 受理日期
            // 
            this.受理日期.DataPropertyName = "AcceptedTime";
            this.受理日期.HeaderText = "受理日期";
            this.受理日期.Name = "受理日期";
            this.受理日期.ReadOnly = true;
            // 
            // 受理者
            // 
            this.受理者.HeaderText = "受理者";
            this.受理者.Name = "受理者";
            this.受理者.ReadOnly = true;
            // 
            // 受理单号
            // 
            this.受理单号.DataPropertyName = "AcceptedNo";
            this.受理单号.HeaderText = "受理单号";
            this.受理单号.Name = "受理单号";
            this.受理单号.ReadOnly = true;
            // 
            // 取消时间
            // 
            this.取消时间.DataPropertyName = "CanceledTime";
            this.取消时间.HeaderText = "取消时间";
            this.取消时间.Name = "取消时间";
            this.取消时间.ReadOnly = true;
            // 
            // 取消者
            // 
            this.取消者.HeaderText = "取消者";
            this.取消者.Name = "取消者";
            this.取消者.ReadOnly = true;
            // 
            // 取消单号
            // 
            this.取消单号.DataPropertyName = "CanceledNo";
            this.取消单号.HeaderText = "取消单号";
            this.取消单号.Name = "取消单号";
            this.取消单号.ReadOnly = true;
            // 
            // 出库时间
            // 
            this.出库时间.DataPropertyName = "outedTime";
            this.出库时间.HeaderText = "出库时间";
            this.出库时间.Name = "出库时间";
            this.出库时间.ReadOnly = true;
            // 
            // 出库者
            // 
            this.出库者.HeaderText = "出库者";
            this.出库者.Name = "出库者";
            this.出库者.ReadOnly = true;
            // 
            // 出库单号
            // 
            this.出库单号.DataPropertyName = "outedNo";
            this.出库单号.HeaderText = "出库单号";
            this.出库单号.Name = "出库单号";
            this.出库单号.ReadOnly = true;
            // 
            // 签收时间
            // 
            this.签收时间.DataPropertyName = "SignedTime";
            this.签收时间.HeaderText = "签收时间";
            this.签收时间.Name = "签收时间";
            this.签收时间.ReadOnly = true;
            // 
            // 签收者
            // 
            this.签收者.HeaderText = "签收者";
            this.签收者.Name = "签收者";
            this.签收者.ReadOnly = true;
            // 
            // 签收单号
            // 
            this.签收单号.DataPropertyName = "SignedNo";
            this.签收单号.HeaderText = "签收单号";
            this.签收单号.Name = "签收单号";
            this.签收单号.ReadOnly = true;
            // 
            // 销退申请时间
            // 
            this.销退申请时间.DataPropertyName = "ReturnTime";
            this.销退申请时间.HeaderText = "销退申请时间";
            this.销退申请时间.Name = "销退申请时间";
            this.销退申请时间.ReadOnly = true;
            // 
            // 销退申请者
            // 
            this.销退申请者.HeaderText = "销退申请者";
            this.销退申请者.Name = "销退申请者";
            this.销退申请者.ReadOnly = true;
            // 
            // 销退申请单号
            // 
            this.销退申请单号.DataPropertyName = "ReturnNo";
            this.销退申请单号.HeaderText = "销退申请单号";
            this.销退申请单号.Name = "销退申请单号";
            this.销退申请单号.ReadOnly = true;
            // 
            // 查看详细
            // 
            this.查看详细.HeaderText = "查看详细";
            this.查看详细.Name = "查看详细";
            this.查看详细.ReadOnly = true;
            this.查看详细.Text = "详细";
            this.查看详细.UseColumnTextForButtonValue = true;
            this.查看详细.Width = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 94;
            this.label6.Text = "操作时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 91;
            this.label7.Text = "〜";
            // 
            // dtTo
            // 
            this.dtTo.Checked = false;
            this.dtTo.Location = new System.Drawing.Point(652, 19);
            this.dtTo.Name = "dtTo";
            this.dtTo.ShowCheckBox = true;
            this.dtTo.Size = new System.Drawing.Size(137, 21);
            this.dtTo.TabIndex = 93;
            // 
            // dtFrom
            // 
            this.dtFrom.Checked = false;
            this.dtFrom.Location = new System.Drawing.Point(488, 20);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.ShowCheckBox = true;
            this.dtFrom.Size = new System.Drawing.Size(137, 21);
            this.dtFrom.TabIndex = 92;
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(256, 22);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(148, 20);
            this.cmbOperator.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(45, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(148, 21);
            this.txtCode.TabIndex = 3;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(9, 26);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(41, 12);
            this.lblOrderNo.TabIndex = 2;
            this.lblOrderNo.Text = "单号：";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(206, 26);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(53, 12);
            this.lblSeller.TabIndex = 1;
            this.lblSeller.Text = "操作员：";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.label6);
            this.gbSearch.Controls.Add(this.label7);
            this.gbSearch.Controls.Add(this.dtTo);
            this.gbSearch.Controls.Add(this.dtFrom);
            this.gbSearch.Controls.Add(this.cmbOperator);
            this.gbSearch.Controls.Add(this.txtCode);
            this.gbSearch.Controls.Add(this.lblOrderNo);
            this.gbSearch.Controls.Add(this.lblSeller);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 25);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(802, 55);
            this.gbSearch.TabIndex = 10;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "搜索条件";
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Search;
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(56, 22);
            this.tsbtnSearch.Text = "查 询";
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OutInventoryNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "出库单号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "订单号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CreateTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalMoney";
            this.dataGridViewTextBoxColumn5.HeaderText = "金额合计";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "出库类型";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "出库状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "保管员";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "出库日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "复核员";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "审核日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // pagerControl
            // 
            this.pagerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pagerControl.Location = new System.Drawing.Point(0, 315);
            this.pagerControl.Name = "pagerControl";
            this.pagerControl.PageIndex = 1;
            this.pagerControl.PageSize = 20;
            this.pagerControl.RecordCount = 0;
            this.pagerControl.Size = new System.Drawing.Size(478, 45);
            this.pagerControl.TabIndex = 12;
            this.pagerControl.DataPaging += new PagerControl.PagerControl.Paging(this.pagerControl_DataPaging);
            // 
            // FormDeliverySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 350);
            this.Controls.Add(this.dgvDelivery);
            this.Controls.Add(this.pagerControl);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormDeliverySearch";
            this.Text = "配送相关情报查询";
            this.Load += new System.EventHandler(this.FormDeliverySearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDelivery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private PagerControl.PagerControl pagerControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 货单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 药品件数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收货公司;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发货地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收货地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运输方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配送状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 委托人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 委托人电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运输公司;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车辆信息;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 预约时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 预约者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 预约单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受理日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受理者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 受理单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 取消时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 取消者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 取消单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 签收时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 签收者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 签收单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销退申请时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销退申请者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销退申请单号;
        private System.Windows.Forms.DataGridViewButtonColumn 查看详细;
    }
}