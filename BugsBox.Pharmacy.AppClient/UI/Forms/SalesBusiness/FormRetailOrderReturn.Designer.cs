namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormRetailOrderReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRetailOrderReturn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtActualRefund = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTheoryRefund = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReduceMoneyReturn = new System.Windows.Forms.TextBox();
            this.txtRefund = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbRetailCustomerType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbRetailPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRealPayMoney = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChangeMoney = new System.Windows.Forms.TextBox();
            this.txtGotMoney = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReceivableMoney = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReduceMoney = new System.Windows.Forms.TextBox();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.btnDetailAdd = new System.Windows.Forms.Button();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDrugDetailList = new System.Windows.Forms.DataGridView();
            this.库存ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.行号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.折扣 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.退货数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.说明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产厂商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.有效期至 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regularExpressionValidator1 = new CustomValidatorsLibrary.RegularExpressionValidator();
            this.regularExpressionValidator2 = new CustomValidatorsLibrary.RegularExpressionValidator();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnReturn,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(824, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnReturn
            // 
            this.tsbtnReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnReturn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReturn.Image")));
            this.tsbtnReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReturn.Name = "tsbtnReturn";
            this.tsbtnReturn.Size = new System.Drawing.Size(36, 22);
            this.tsbtnReturn.Text = "退货";
            this.tsbtnReturn.Click += new System.EventHandler(this.tsbtnReturn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtActualRefund);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtTheoryRefund);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtReduceMoneyReturn);
            this.panel1.Controls.Add(this.txtRefund);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cmbRetailCustomerType);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cmbRetailPaymentMethod);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRealPayMoney);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtChangeMoney);
            this.panel1.Controls.Add(this.txtGotMoney);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtReceivableMoney);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtReduceMoney);
            this.panel1.Controls.Add(this.txtTotalMoney);
            this.panel1.Controls.Add(this.btnDetailAdd);
            this.panel1.Controls.Add(this.lblCreateDate);
            this.panel1.Controls.Add(this.lblOrderNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 176);
            this.panel1.TabIndex = 7;
            // 
            // txtActualRefund
            // 
            this.txtActualRefund.AcceptsReturn = true;
            this.txtActualRefund.Location = new System.Drawing.Point(581, 106);
            this.txtActualRefund.Name = "txtActualRefund";
            this.txtActualRefund.Size = new System.Drawing.Size(100, 21);
            this.txtActualRefund.TabIndex = 88;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(527, 110);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 87;
            this.label16.Text = "实退款：";
            // 
            // txtTheoryRefund
            // 
            this.txtTheoryRefund.AcceptsReturn = true;
            this.txtTheoryRefund.Location = new System.Drawing.Point(420, 106);
            this.txtTheoryRefund.Name = "txtTheoryRefund";
            this.txtTheoryRefund.ReadOnly = true;
            this.txtTheoryRefund.Size = new System.Drawing.Size(100, 21);
            this.txtTheoryRefund.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 85;
            this.label2.Text = "应退款：";
            // 
            // txtReduceMoneyReturn
            // 
            this.txtReduceMoneyReturn.AcceptsReturn = true;
            this.txtReduceMoneyReturn.Location = new System.Drawing.Point(248, 106);
            this.txtReduceMoneyReturn.Name = "txtReduceMoneyReturn";
            this.txtReduceMoneyReturn.Size = new System.Drawing.Size(100, 21);
            this.txtReduceMoneyReturn.TabIndex = 84;
            this.txtReduceMoneyReturn.Text = "0";
            this.txtReduceMoneyReturn.TextChanged += new System.EventHandler(this.txtReduceMoneyReturn_TextChanged);
            // 
            // txtRefund
            // 
            this.txtRefund.AcceptsReturn = true;
            this.txtRefund.Location = new System.Drawing.Point(71, 106);
            this.txtRefund.Name = "txtRefund";
            this.txtRefund.ReadOnly = true;
            this.txtRefund.Size = new System.Drawing.Size(100, 21);
            this.txtRefund.TabIndex = 83;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 110);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 82;
            this.label14.Text = "退款合计：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(179, 110);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 81;
            this.label15.Text = "优惠返还：";
            // 
            // cmbRetailCustomerType
            // 
            this.cmbRetailCustomerType.FormattingEnabled = true;
            this.cmbRetailCustomerType.Location = new System.Drawing.Point(72, 52);
            this.cmbRetailCustomerType.Name = "cmbRetailCustomerType";
            this.cmbRetailCustomerType.Size = new System.Drawing.Size(100, 20);
            this.cmbRetailCustomerType.TabIndex = 80;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 56);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 79;
            this.label13.Text = "客户类型：";
            // 
            // cmbRetailPaymentMethod
            // 
            this.cmbRetailPaymentMethod.FormattingEnabled = true;
            this.cmbRetailPaymentMethod.Location = new System.Drawing.Point(72, 79);
            this.cmbRetailPaymentMethod.Name = "cmbRetailPaymentMethod";
            this.cmbRetailPaymentMethod.Size = new System.Drawing.Size(100, 20);
            this.cmbRetailPaymentMethod.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "付款方式：";
            // 
            // txtRealPayMoney
            // 
            this.txtRealPayMoney.AcceptsReturn = true;
            this.txtRealPayMoney.Location = new System.Drawing.Point(581, 78);
            this.txtRealPayMoney.Name = "txtRealPayMoney";
            this.txtRealPayMoney.ReadOnly = true;
            this.txtRealPayMoney.Size = new System.Drawing.Size(100, 21);
            this.txtRealPayMoney.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 75;
            this.label10.Text = "实收款：";
            // 
            // txtChangeMoney
            // 
            this.txtChangeMoney.AcceptsReturn = true;
            this.txtChangeMoney.Location = new System.Drawing.Point(420, 78);
            this.txtChangeMoney.Name = "txtChangeMoney";
            this.txtChangeMoney.ReadOnly = true;
            this.txtChangeMoney.Size = new System.Drawing.Size(100, 21);
            this.txtChangeMoney.TabIndex = 74;
            this.txtChangeMoney.Text = "0";
            // 
            // txtGotMoney
            // 
            this.txtGotMoney.AcceptsReturn = true;
            this.txtGotMoney.Location = new System.Drawing.Point(248, 78);
            this.txtGotMoney.Name = "txtGotMoney";
            this.txtGotMoney.ReadOnly = true;
            this.txtGotMoney.Size = new System.Drawing.Size(100, 21);
            this.txtGotMoney.TabIndex = 73;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 83);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 72;
            this.label11.Text = "收款：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 81);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 71;
            this.label12.Text = "找零：";
            // 
            // txtReceivableMoney
            // 
            this.txtReceivableMoney.AcceptsReturn = true;
            this.txtReceivableMoney.Location = new System.Drawing.Point(581, 52);
            this.txtReceivableMoney.Name = "txtReceivableMoney";
            this.txtReceivableMoney.ReadOnly = true;
            this.txtReceivableMoney.Size = new System.Drawing.Size(100, 21);
            this.txtReceivableMoney.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 69;
            this.label9.Text = "应收款：";
            // 
            // txtReduceMoney
            // 
            this.txtReduceMoney.AcceptsReturn = true;
            this.txtReduceMoney.Location = new System.Drawing.Point(420, 52);
            this.txtReduceMoney.Name = "txtReduceMoney";
            this.txtReduceMoney.ReadOnly = true;
            this.txtReduceMoney.Size = new System.Drawing.Size(100, 21);
            this.txtReduceMoney.TabIndex = 68;
            this.txtReduceMoney.Text = "0";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.AcceptsReturn = true;
            this.txtTotalMoney.Location = new System.Drawing.Point(248, 52);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.ReadOnly = true;
            this.txtTotalMoney.Size = new System.Drawing.Size(100, 21);
            this.txtTotalMoney.TabIndex = 67;
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetailAdd.Location = new System.Drawing.Point(738, 150);
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(75, 23);
            this.btnDetailAdd.TabIndex = 66;
            this.btnDetailAdd.Text = "新增";
            this.btnDetailAdd.UseVisualStyleBackColor = true;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(597, 33);
            this.lblCreateDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(0, 12);
            this.lblCreateDate.TabIndex = 59;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(597, 14);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(0, 12);
            this.lblOrderNo.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(545, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "录入日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "单据编号：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(71, 132);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(610, 41);
            this.txtRemark.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "备注：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(238, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "零售退货单据";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "金额合计：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "优惠：";
            // 
            // dgvDrugDetailList
            // 
            this.dgvDrugDetailList.AllowUserToAddRows = false;
            this.dgvDrugDetailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDrugDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrugDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.库存ID,
            this.行号,
            this.商品编号,
            this.商品名称,
            this.批号,
            this.单价,
            this.实际单价,
            this.折扣,
            this.数量,
            this.退货数量,
            this.金额,
            this.说明,
            this.单位,
            this.规格,
            this.生产厂商,
            this.生产日期,
            this.有效期至});
            this.dgvDrugDetailList.Location = new System.Drawing.Point(4, 207);
            this.dgvDrugDetailList.Name = "dgvDrugDetailList";
            this.dgvDrugDetailList.RowTemplate.Height = 23;
            this.dgvDrugDetailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrugDetailList.Size = new System.Drawing.Size(816, 247);
            this.dgvDrugDetailList.TabIndex = 8;
            this.dgvDrugDetailList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrugDetailList_CellEndEdit);
            // 
            // 库存ID
            // 
            this.库存ID.DataPropertyName = "DrugInventoryRecordID";
            this.库存ID.HeaderText = "库存ID";
            this.库存ID.Name = "库存ID";
            this.库存ID.Visible = false;
            // 
            // 行号
            // 
            this.行号.DataPropertyName = "Index";
            this.行号.HeaderText = "行号";
            this.行号.Name = "行号";
            this.行号.Width = 60;
            // 
            // 商品编号
            // 
            this.商品编号.DataPropertyName = "DrugInfoId";
            this.商品编号.HeaderText = "商品编号";
            this.商品编号.Name = "商品编号";
            this.商品编号.ReadOnly = true;
            this.商品编号.Width = 150;
            // 
            // 商品名称
            // 
            this.商品名称.DataPropertyName = "productName";
            this.商品名称.HeaderText = "商品名称";
            this.商品名称.Name = "商品名称";
            this.商品名称.ReadOnly = true;
            this.商品名称.Width = 200;
            // 
            // 批号
            // 
            this.批号.DataPropertyName = "BatchNumber";
            this.批号.HeaderText = "批号";
            this.批号.Name = "批号";
            this.批号.ReadOnly = true;
            this.批号.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 单价
            // 
            this.单价.DataPropertyName = "UnitPrice";
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            this.单价.ReadOnly = true;
            // 
            // 实际单价
            // 
            this.实际单价.DataPropertyName = "ActualPrice";
            this.实际单价.HeaderText = "实际单价";
            this.实际单价.Name = "实际单价";
            this.实际单价.ReadOnly = true;
            // 
            // 折扣
            // 
            this.折扣.DataPropertyName = "Discount";
            this.折扣.HeaderText = "折扣";
            this.折扣.Name = "折扣";
            this.折扣.ReadOnly = true;
            // 
            // 数量
            // 
            this.数量.DataPropertyName = "Amount";
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            // 
            // 退货数量
            // 
            this.退货数量.DataPropertyName = "ReturnQuantity";
            this.退货数量.HeaderText = "退货数量";
            this.退货数量.Name = "退货数量";
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "Price";
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            // 
            // 说明
            // 
            this.说明.DataPropertyName = "Decription";
            this.说明.HeaderText = "说明";
            this.说明.Name = "说明";
            this.说明.ReadOnly = true;
            this.说明.Width = 200;
            // 
            // 单位
            // 
            this.单位.DataPropertyName = "MeasurementUnit";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.单位.DefaultCellStyle = dataGridViewCellStyle6;
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            this.单位.ReadOnly = true;
            this.单位.Width = 60;
            // 
            // 规格
            // 
            this.规格.DataPropertyName = "SpecificationCode";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.规格.DefaultCellStyle = dataGridViewCellStyle7;
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            this.规格.ReadOnly = true;
            // 
            // 生产厂商
            // 
            this.生产厂商.DataPropertyName = "FactoryName";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.生产厂商.DefaultCellStyle = dataGridViewCellStyle8;
            this.生产厂商.HeaderText = "生产厂商";
            this.生产厂商.Name = "生产厂商";
            this.生产厂商.ReadOnly = true;
            // 
            // 生产日期
            // 
            this.生产日期.DataPropertyName = "PruductDate";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.生产日期.DefaultCellStyle = dataGridViewCellStyle9;
            this.生产日期.HeaderText = "生产日期";
            this.生产日期.Name = "生产日期";
            this.生产日期.ReadOnly = true;
            // 
            // 有效期至
            // 
            this.有效期至.DataPropertyName = "OutValidDate";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.有效期至.DefaultCellStyle = dataGridViewCellStyle10;
            this.有效期至.HeaderText = "有效期至";
            this.有效期至.Name = "有效期至";
            this.有效期至.ReadOnly = true;
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.ControlToValidate = this.txtReduceMoney;
            this.regularExpressionValidator1.ErrorMessage = "输入数据不合法";
            this.regularExpressionValidator1.Icon = null;
            this.regularExpressionValidator1.ValidationExpression = "/^[-\\+]?\\d+(\\.\\d+)?$/";
            // 
            // regularExpressionValidator2
            // 
            this.regularExpressionValidator2.ControlToValidate = this.txtGotMoney;
            this.regularExpressionValidator2.ErrorMessage = "输入数据不合法";
            this.regularExpressionValidator2.Icon = null;
            this.regularExpressionValidator2.ValidationExpression = "/^[-\\+]?\\d+(\\.\\d+)?$/";
            // 
            // FormRetailOrderReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 459);
            this.Controls.Add(this.dgvDrugDetailList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormRetailOrderReturn";
            this.Text = "零售退货编辑";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugDetailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDrugDetailList;
        private System.Windows.Forms.TextBox txtReduceMoney;
        private System.Windows.Forms.TextBox txtReceivableMoney;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRealPayMoney;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChangeMoney;
        private System.Windows.Forms.TextBox txtGotMoney;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRetailPaymentMethod;
        private System.Windows.Forms.ComboBox cmbRetailCustomerType;
        private System.Windows.Forms.Label label13;
        private CustomValidatorsLibrary.RegularExpressionValidator regularExpressionValidator1;
        private CustomValidatorsLibrary.RegularExpressionValidator regularExpressionValidator2;
        private System.Windows.Forms.TextBox txtTheoryRefund;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReduceMoneyReturn;
        private System.Windows.Forms.TextBox txtRefund;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtActualRefund;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 批号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 折扣;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 退货数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 说明;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产厂商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 有效期至;
        private System.Windows.Forms.ToolStripButton tsbtnReturn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnDetailAdd;
    }
}