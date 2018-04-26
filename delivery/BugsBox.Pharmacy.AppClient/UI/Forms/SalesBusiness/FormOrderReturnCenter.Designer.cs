namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormOrderReturnCenter
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvOrderReturn = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.处理 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.销退单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销退状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderReturnReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销售员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销售员意见 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.营业部代表 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.营业部意见 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.质量管理部代表 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.质量管理部意见 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvOrderReturn
            // 
            this.dgvOrderReturn.AllowUserToAddRows = false;
            this.dgvOrderReturn.AllowUserToDeleteRows = false;
            this.dgvOrderReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.处理,
            this.销退单号,
            this.创建时间,
            this.销退状态,
            this.OrderReturnReason,
            this.销售员,
            this.销售员意见,
            this.营业部代表,
            this.营业部意见,
            this.质量管理部代表,
            this.质量管理部意见});
            this.dgvOrderReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderReturn.Location = new System.Drawing.Point(0, 25);
            this.dgvOrderReturn.Name = "dgvOrderReturn";
            this.dgvOrderReturn.ReadOnly = true;
            this.dgvOrderReturn.RowHeadersVisible = false;
            this.dgvOrderReturn.RowTemplate.Height = 23;
            this.dgvOrderReturn.Size = new System.Drawing.Size(844, 363);
            this.dgvOrderReturn.TabIndex = 8;
            this.dgvOrderReturn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderReturn_CellContentClick);
            this.dgvOrderReturn.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvOrderReturn_RowPrePaint);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 80;
            // 
            // 处理
            // 
            this.处理.HeaderText = "处理";
            this.处理.Name = "处理";
            this.处理.ReadOnly = true;
            this.处理.Text = "处理";
            this.处理.UseColumnTextForButtonValue = true;
            this.处理.Width = 80;
            // 
            // 销退单号
            // 
            this.销退单号.DataPropertyName = "OrderReturnCode";
            this.销退单号.HeaderText = "销退单号";
            this.销退单号.Name = "销退单号";
            this.销退单号.ReadOnly = true;
            // 
            // 创建时间
            // 
            this.创建时间.DataPropertyName = "CreateTime";
            this.创建时间.HeaderText = "创建时间";
            this.创建时间.Name = "创建时间";
            this.创建时间.ReadOnly = true;
            // 
            // 销退状态
            // 
            this.销退状态.HeaderText = "销退状态";
            this.销退状态.Name = "销退状态";
            this.销退状态.ReadOnly = true;
            // 
            // OrderReturnReason
            // 
            this.OrderReturnReason.DataPropertyName = "OrderReturnReason";
            this.OrderReturnReason.HeaderText = "销退理由";
            this.OrderReturnReason.Name = "OrderReturnReason";
            this.OrderReturnReason.ReadOnly = true;
            this.OrderReturnReason.Width = 200;
            // 
            // 销售员
            // 
            this.销售员.HeaderText = "销售员";
            this.销售员.Name = "销售员";
            this.销售员.ReadOnly = true;
            // 
            // 销售员意见
            // 
            this.销售员意见.DataPropertyName = "SellerMemo";
            this.销售员意见.HeaderText = "销售员意见";
            this.销售员意见.Name = "销售员意见";
            this.销售员意见.ReadOnly = true;
            this.销售员意见.Width = 200;
            // 
            // 营业部代表
            // 
            this.营业部代表.HeaderText = "营业部代表";
            this.营业部代表.Name = "营业部代表";
            this.营业部代表.ReadOnly = true;
            // 
            // 营业部意见
            // 
            this.营业部意见.DataPropertyName = "TradeMemo";
            this.营业部意见.HeaderText = "营业部意见";
            this.营业部意见.Name = "营业部意见";
            this.营业部意见.ReadOnly = true;
            this.营业部意见.Width = 200;
            // 
            // 质量管理部代表
            // 
            this.质量管理部代表.DataPropertyName = "QualityMemo";
            this.质量管理部代表.HeaderText = "质量管理部代表";
            this.质量管理部代表.Name = "质量管理部代表";
            this.质量管理部代表.ReadOnly = true;
            // 
            // 质量管理部意见
            // 
            this.质量管理部意见.DataPropertyName = "QualityMemo";
            this.质量管理部意见.HeaderText = "质量管理部意见";
            this.质量管理部意见.Name = "质量管理部意见";
            this.质量管理部意见.ReadOnly = true;
            this.质量管理部意见.Width = 200;
            // 
            // FormOrderReturnCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 388);
            this.Controls.Add(this.dgvOrderReturn);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormOrderReturnCenter";
            this.Text = "销退处理画面";
            this.Load += new System.EventHandler(this.FormOrderReturnCenter_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvOrderReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewButtonColumn 处理;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销退单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销退状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderReturnReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销售员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销售员意见;
        private System.Windows.Forms.DataGridViewTextBoxColumn 营业部代表;
        private System.Windows.Forms.DataGridViewTextBoxColumn 营业部意见;
        private System.Windows.Forms.DataGridViewTextBoxColumn 质量管理部代表;
        private System.Windows.Forms.DataGridViewTextBoxColumn 质量管理部意见;
    }
}