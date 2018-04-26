namespace BugsBox.Pharmacy.AppClient.UI.Forms.RetailBusiness
{
    partial class FormRetailOrderCenter
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pcMain = new PagerControl.PagerControl();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pcMain, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvMain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 371);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pcMain
            // 
            this.pcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcMain.Location = new System.Drawing.Point(4, 335);
            this.pcMain.Margin = new System.Windows.Forms.Padding(4);
            this.pcMain.Name = "pcMain";
            this.pcMain.PageIndex = 1;
            this.pcMain.PageSize = 20;
            this.pcMain.RecordCount = 0;
            this.pcMain.Size = new System.Drawing.Size(491, 32);
            this.pcMain.TabIndex = 13;
            this.pcMain.DataPaging += new PagerControl.PagerControl.Paging(this.pcMain_DataPaging);
            // 
            // dgvMain
            // 
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
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(3, 73);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(776, 255);
            this.dgvMain.TabIndex = 12;
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Refresh;
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(56, 22);
            this.tsbtnSearch.Text = "刷 新";
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOrderNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 39);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单搜索";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(64, 12);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(228, 21);
            this.txtOrderNo.TabIndex = 1;
            this.txtOrderNo.TextChanged += new System.EventHandler(this.txtOrderNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号:";
            // 
            // FormRetailOrderCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 371);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRetailOrderCenter";
            this.Text = "零售中心";
            this.Load += new System.EventHandler(this.FormRetailOrderIndex_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn 门店编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivableMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn GotMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealPayMoney;
        private PagerControl.PagerControl pcMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label1;

    }
}