namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    partial class usSalesOrder
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtSalesDate = new System.Windows.Forms.DateTimePicker();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.lblOrderState = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl金额合计 = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt销售员名 = new System.Windows.Forms.TextBox();
            this.cmbSalesMan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt采购商名称 = new System.Windows.Forms.TextBox();
            this.cmbSupply = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDrugDetailList = new System.Windows.Forms.DataGridView();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.行号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.说明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产厂商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.有效期至 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugDetailList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDrugDetailList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.47309F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.52691F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 353);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtSalesDate);
            this.panel1.Controls.Add(this.rtbRemark);
            this.panel1.Controls.Add(this.lblOrderState);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbl金额合计);
            this.panel1.Controls.Add(this.lblCreateDate);
            this.panel1.Controls.Add(this.lblOrderCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.txtTotalMoney);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt销售员名);
            this.panel1.Controls.Add(this.cmbSalesMan);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt采购商名称);
            this.panel1.Controls.Add(this.cmbSupply);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 211);
            this.panel1.TabIndex = 7;
            // 
            // dtSalesDate
            // 
            this.dtSalesDate.Location = new System.Drawing.Point(57, 45);
            this.dtSalesDate.Name = "dtSalesDate";
            this.dtSalesDate.Size = new System.Drawing.Size(121, 21);
            this.dtSalesDate.TabIndex = 64;
            // 
            // rtbRemark
            // 
            this.rtbRemark.Location = new System.Drawing.Point(57, 136);
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(617, 68);
            this.rtbRemark.TabIndex = 63;
            this.rtbRemark.Text = "";
            // 
            // lblOrderState
            // 
            this.lblOrderState.AutoSize = true;
            this.lblOrderState.Location = new System.Drawing.Point(599, 88);
            this.lblOrderState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderState.Name = "lblOrderState";
            this.lblOrderState.Size = new System.Drawing.Size(41, 12);
            this.lblOrderState.TabIndex = 62;
            this.lblOrderState.Text = "待审核";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(540, 88);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 61;
            this.label12.Text = "订单状态：";
            // 
            // lbl金额合计
            // 
            this.lbl金额合计.AutoSize = true;
            this.lbl金额合计.Location = new System.Drawing.Point(538, 112);
            this.lbl金额合计.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl金额合计.Name = "lbl金额合计";
            this.lbl金额合计.Size = new System.Drawing.Size(65, 12);
            this.lbl金额合计.TabIndex = 60;
            this.lbl金额合计.Text = "折前价:800";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(599, 70);
            this.lblCreateDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(77, 12);
            this.lblCreateDate.TabIndex = 59;
            this.lblCreateDate.Text = "2013年8月7日";
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Location = new System.Drawing.Point(599, 51);
            this.lblOrderCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(59, 12);
            this.lblOrderCode.TabIndex = 58;
            this.lblOrderCode.Text = "*新增编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "录入日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(540, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "单据编号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "备注：";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(370, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "销售订单";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(396, 105);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(111, 21);
            this.txtTotalMoney.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "金额合计：";
            // 
            // txt销售员名
            // 
            this.txt销售员名.Location = new System.Drawing.Point(186, 104);
            this.txt销售员名.Name = "txt销售员名";
            this.txt销售员名.ReadOnly = true;
            this.txt销售员名.Size = new System.Drawing.Size(134, 21);
            this.txt销售员名.TabIndex = 51;
            // 
            // cmbSalesMan
            // 
            this.cmbSalesMan.FormattingEnabled = true;
            this.cmbSalesMan.Location = new System.Drawing.Point(57, 104);
            this.cmbSalesMan.Name = "cmbSalesMan";
            this.cmbSalesMan.Size = new System.Drawing.Size(121, 20);
            this.cmbSalesMan.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "销售员：";
            // 
            // txt采购商名称
            // 
            this.txt采购商名称.Location = new System.Drawing.Point(186, 75);
            this.txt采购商名称.Name = "txt采购商名称";
            this.txt采购商名称.ReadOnly = true;
            this.txt采购商名称.Size = new System.Drawing.Size(321, 21);
            this.txt采购商名称.TabIndex = 48;
            // 
            // cmbSupply
            // 
            this.cmbSupply.FormattingEnabled = true;
            this.cmbSupply.Location = new System.Drawing.Point(57, 75);
            this.cmbSupply.Name = "cmbSupply";
            this.cmbSupply.Size = new System.Drawing.Size(121, 20);
            this.cmbSupply.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "采购商：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "日期：";
            // 
            // dgvDrugDetailList
            // 
            this.dgvDrugDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrugDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.操作,
            this.行号,
            this.商品编号,
            this.商品名称,
            this.批号,
            this.单价,
            this.数量,
            this.金额,
            this.说明,
            this.单位,
            this.规格,
            this.生产厂商,
            this.生产日期,
            this.有效期至});
            this.dgvDrugDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrugDetailList.Location = new System.Drawing.Point(3, 220);
            this.dgvDrugDetailList.Name = "dgvDrugDetailList";
            this.dgvDrugDetailList.RowTemplate.Height = 23;
            this.dgvDrugDetailList.Size = new System.Drawing.Size(896, 130);
            this.dgvDrugDetailList.TabIndex = 8;
            // 
            // 操作
            // 
            this.操作.HeaderText = "操作";
            this.操作.Name = "操作";
            this.操作.Text = "添加";
            this.操作.UseColumnTextForButtonValue = true;
            this.操作.Width = 60;
            // 
            // 行号
            // 
            this.行号.HeaderText = "行号";
            this.行号.Name = "行号";
            this.行号.ReadOnly = true;
            this.行号.Width = 60;
            // 
            // 商品编号
            // 
            this.商品编号.HeaderText = "商品编号";
            this.商品编号.Name = "商品编号";
            this.商品编号.Width = 150;
            // 
            // 商品名称
            // 
            this.商品名称.HeaderText = "商品名称";
            this.商品名称.Name = "商品名称";
            this.商品名称.Width = 200;
            // 
            // 批号
            // 
            this.批号.HeaderText = "批号";
            this.批号.Name = "批号";
            this.批号.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // 单价
            // 
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            // 
            // 数量
            // 
            this.数量.HeaderText = "数量";
            this.数量.Name = "数量";
            // 
            // 金额
            // 
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            // 
            // 说明
            // 
            this.说明.HeaderText = "说明";
            this.说明.Name = "说明";
            this.说明.Width = 200;
            // 
            // 单位
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.单位.DefaultCellStyle = dataGridViewCellStyle1;
            this.单位.HeaderText = "单位";
            this.单位.Name = "单位";
            this.单位.ReadOnly = true;
            this.单位.Width = 60;
            // 
            // 规格
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.规格.DefaultCellStyle = dataGridViewCellStyle2;
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            this.规格.ReadOnly = true;
            // 
            // 生产厂商
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.生产厂商.DefaultCellStyle = dataGridViewCellStyle3;
            this.生产厂商.HeaderText = "生产厂商";
            this.生产厂商.Name = "生产厂商";
            this.生产厂商.ReadOnly = true;
            // 
            // 生产日期
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.生产日期.DefaultCellStyle = dataGridViewCellStyle4;
            this.生产日期.HeaderText = "生产日期";
            this.生产日期.Name = "生产日期";
            this.生产日期.ReadOnly = true;
            // 
            // 有效期至
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.有效期至.DefaultCellStyle = dataGridViewCellStyle5;
            this.有效期至.HeaderText = "有效期至";
            this.有效期至.Name = "有效期至";
            this.有效期至.ReadOnly = true;
            // 
            // usSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "usSalesOrder";
            this.Size = new System.Drawing.Size(902, 353);
            this.Load += new System.EventHandler(this.usSalesOrder_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugDetailList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl金额合计;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt销售员名;
        private System.Windows.Forms.ComboBox cmbSalesMan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt采购商名称;
        private System.Windows.Forms.ComboBox cmbSupply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDrugDetailList;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
        private System.Windows.Forms.DataGridViewTextBoxColumn 行号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 商品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 批号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额;
        private System.Windows.Forms.DataGridViewTextBoxColumn 说明;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产厂商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 有效期至;
        private System.Windows.Forms.RichTextBox rtbRemark;
        private System.Windows.Forms.DateTimePicker dtSalesDate;
    }
}
