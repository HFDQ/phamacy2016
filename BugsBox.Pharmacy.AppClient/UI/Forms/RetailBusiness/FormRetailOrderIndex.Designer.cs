namespace BugsBox.Pharmacy.AppClient.UI.Forms.RetailBusiness
{
    partial class FormRetailOrderIndex
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cmbRetailCustomerType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRetailPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtFT = new BugsBox.Pharmacy.UI.Common.UserControls.FromToDateTime();
            this.cmbSeller = new System.Windows.Forms.ComboBox();
            this.txtOrders = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.门店编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivableMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GotMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealPayMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcMain = new PagerControl.PagerControl();
            this.toolStrip1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSearch,
            this.tsbtnAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Add;
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(76, 22);
            this.tsbtnAdd.Text = "新建订单";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.Controls.Add(this.cmbRetailCustomerType);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.cmbRetailPaymentMethod);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.DtFT);
            this.gbSearch.Controls.Add(this.cmbSeller);
            this.gbSearch.Controls.Add(this.txtOrders);
            this.gbSearch.Controls.Add(this.lblOrderNo);
            this.gbSearch.Controls.Add(this.lblSeller);
            this.gbSearch.Location = new System.Drawing.Point(3, 28);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(776, 78);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "搜索条件";
            // 
            // cmbRetailCustomerType
            // 
            this.cmbRetailCustomerType.FormattingEnabled = true;
            this.cmbRetailCustomerType.Location = new System.Drawing.Point(348, 18);
            this.cmbRetailCustomerType.Name = "cmbRetailCustomerType";
            this.cmbRetailCustomerType.Size = new System.Drawing.Size(134, 20);
            this.cmbRetailCustomerType.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "付款方式";
            // 
            // cmbRetailPaymentMethod
            // 
            this.cmbRetailPaymentMethod.FormattingEnabled = true;
            this.cmbRetailPaymentMethod.Location = new System.Drawing.Point(570, 18);
            this.cmbRetailPaymentMethod.Name = "cmbRetailPaymentMethod";
            this.cmbRetailPaymentMethod.Size = new System.Drawing.Size(133, 20);
            this.cmbRetailPaymentMethod.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "客户类型";
            // 
            // DtFT
            // 
            this.DtFT.EndTime = new System.DateTime(2013, 8, 8, 20, 40, 3, 143);
            this.DtFT.LabelName = "订单时间";
            this.DtFT.Location = new System.Drawing.Point(281, 39);
            this.DtFT.Name = "DtFT";
            this.DtFT.Size = new System.Drawing.Size(503, 38);
            this.DtFT.StartTime = new System.DateTime(2013, 8, 7, 20, 40, 3, 127);
            this.DtFT.TabIndex = 7;
            // 
            // cmbSeller
            // 
            this.cmbSeller.FormattingEnabled = true;
            this.cmbSeller.Location = new System.Drawing.Point(69, 52);
            this.cmbSeller.Name = "cmbSeller";
            this.cmbSeller.Size = new System.Drawing.Size(198, 20);
            this.cmbSeller.TabIndex = 6;
            // 
            // txtOrders
            // 
            this.txtOrders.Location = new System.Drawing.Point(69, 18);
            this.txtOrders.Name = "txtOrders";
            this.txtOrders.Size = new System.Drawing.Size(198, 21);
            this.txtOrders.TabIndex = 3;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(9, 22);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(41, 12);
            this.lblOrderNo.TabIndex = 2;
            this.lblOrderNo.Text = "订单号";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(12, 56);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(41, 12);
            this.lblSeller.TabIndex = 1;
            this.lblSeller.Text = "销售员";
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.门店编号,
            this.客户类型,
            this.付款方式,
            this.TotalMoney,
            this.ReceivableMoney,
            this.GotMoney,
            this.ChangeMoney,
            this.RealPayMoney});
            this.dgvMain.Location = new System.Drawing.Point(3, 111);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(776, 224);
            this.dgvMain.TabIndex = 11;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            this.dgvMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMain_CellFormatting);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "订单编号";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // 门店编号
            // 
            this.门店编号.DataPropertyName = "StoreId";
            this.门店编号.HeaderText = "门店编号";
            this.门店编号.Name = "门店编号";
            this.门店编号.ReadOnly = true;
            // 
            // 客户类型
            // 
            this.客户类型.DataPropertyName = "RetailCustomerTypeValue";
            this.客户类型.HeaderText = "客户类型";
            this.客户类型.Name = "客户类型";
            this.客户类型.ReadOnly = true;
            // 
            // 付款方式
            // 
            this.付款方式.DataPropertyName = "RetailPaymentMethodValue";
            this.付款方式.HeaderText = "付款方式";
            this.付款方式.Name = "付款方式";
            this.付款方式.ReadOnly = true;
            // 
            // TotalMoney
            // 
            this.TotalMoney.DataPropertyName = "TotalMoney";
            this.TotalMoney.HeaderText = "金额总计";
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.ReadOnly = true;
            // 
            // ReceivableMoney
            // 
            this.ReceivableMoney.DataPropertyName = "ReceivableMoney";
            this.ReceivableMoney.HeaderText = "应收款";
            this.ReceivableMoney.Name = "ReceivableMoney";
            this.ReceivableMoney.ReadOnly = true;
            // 
            // GotMoney
            // 
            this.GotMoney.DataPropertyName = "GotMoney";
            this.GotMoney.HeaderText = "收钱";
            this.GotMoney.Name = "GotMoney";
            this.GotMoney.ReadOnly = true;
            // 
            // ChangeMoney
            // 
            this.ChangeMoney.DataPropertyName = "ChangeMoney";
            this.ChangeMoney.HeaderText = "找零";
            this.ChangeMoney.Name = "ChangeMoney";
            this.ChangeMoney.ReadOnly = true;
            // 
            // RealPayMoney
            // 
            this.RealPayMoney.DataPropertyName = "RealPayMoney";
            this.RealPayMoney.HeaderText = "实付";
            this.RealPayMoney.Name = "RealPayMoney";
            this.RealPayMoney.ReadOnly = true;
            // 
            // pcMain
            // 
            this.pcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcMain.Location = new System.Drawing.Point(3, 338);
            this.pcMain.Margin = new System.Windows.Forms.Padding(4);
            this.pcMain.Name = "pcMain";
            this.pcMain.PageIndex = 1;
            this.pcMain.PageSize = 20;
            this.pcMain.RecordCount = 0;
            this.pcMain.Size = new System.Drawing.Size(491, 33);
            this.pcMain.TabIndex = 12;
            // 
            // FormRetailOrderIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 371);
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormRetailOrderIndex";
            this.Text = "零售检索画面";
            this.Load += new System.EventHandler(this.FormRetailOrderIndex_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.ComboBox cmbRetailPaymentMethod;
        private System.Windows.Forms.Label label1;
        private Pharmacy.UI.Common.UserControls.FromToDateTime DtFT;
        private System.Windows.Forms.ComboBox cmbSeller;
        private System.Windows.Forms.TextBox txtOrders;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cmbRetailCustomerType;
        private System.Windows.Forms.Label label2;
        private PagerControl.PagerControl pcMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn 门店编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivableMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn GotMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealPayMoney;
    }
}