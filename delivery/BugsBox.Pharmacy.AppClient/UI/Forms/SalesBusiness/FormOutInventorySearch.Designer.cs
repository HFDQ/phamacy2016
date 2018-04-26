namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormOutInventorySearch
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.dgvOutInventory = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.订单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额合计 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.保管员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.复核员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.第二复核员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.审核结果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pagerControl = new PagerControl.PagerControl();
            this.toolStrip1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSearch,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.data;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton1.Text = "导出EXCEL";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.checkBox1);
            this.gbSearch.Controls.Add(this.label6);
            this.gbSearch.Controls.Add(this.label7);
            this.gbSearch.Controls.Add(this.dtTo);
            this.gbSearch.Controls.Add(this.dtFrom);
            this.gbSearch.Controls.Add(this.txtCode);
            this.gbSearch.Controls.Add(this.lblOrderNo);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 25);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(818, 55);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "搜索条件";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(215, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 95;
            this.checkBox1.Text = "是否重点药品";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 94;
            this.label6.Text = "查询时间：";
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
            // dgvOutInventory
            // 
            this.dgvOutInventory.AllowUserToAddRows = false;
            this.dgvOutInventory.AllowUserToDeleteRows = false;
            this.dgvOutInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.出库单号,
            this.订单号,
            this.创建时间,
            this.金额合计,
            this.出库类型,
            this.出库状态,
            this.保管员,
            this.出库日期,
            this.复核员,
            this.第二复核员,
            this.审核结果,
            this.Column1,
            this.查看详细});
            this.dgvOutInventory.Location = new System.Drawing.Point(0, 86);
            this.dgvOutInventory.Name = "dgvOutInventory";
            this.dgvOutInventory.ReadOnly = true;
            this.dgvOutInventory.RowTemplate.Height = 23;
            this.dgvOutInventory.Size = new System.Drawing.Size(818, 260);
            this.dgvOutInventory.TabIndex = 8;
            this.dgvOutInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutInventory_CellContentClick);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 80;
            // 
            // 出库单号
            // 
            this.出库单号.DataPropertyName = "OutInventoryNumber";
            this.出库单号.HeaderText = "出库单号";
            this.出库单号.Name = "出库单号";
            this.出库单号.ReadOnly = true;
            this.出库单号.Width = 120;
            // 
            // 订单号
            // 
            this.订单号.DataPropertyName = "OrderCode";
            this.订单号.HeaderText = "订单号";
            this.订单号.Name = "订单号";
            this.订单号.ReadOnly = true;
            this.订单号.Width = 120;
            // 
            // 创建时间
            // 
            this.创建时间.DataPropertyName = "CreateTime";
            this.创建时间.HeaderText = "创建时间";
            this.创建时间.Name = "创建时间";
            this.创建时间.ReadOnly = true;
            // 
            // 金额合计
            // 
            this.金额合计.DataPropertyName = "TotalMoney";
            this.金额合计.HeaderText = "金额合计";
            this.金额合计.Name = "金额合计";
            this.金额合计.ReadOnly = true;
            // 
            // 出库类型
            // 
            this.出库类型.HeaderText = "出库类型";
            this.出库类型.Name = "出库类型";
            this.出库类型.ReadOnly = true;
            // 
            // 出库状态
            // 
            this.出库状态.HeaderText = "出库状态";
            this.出库状态.Name = "出库状态";
            this.出库状态.ReadOnly = true;
            // 
            // 保管员
            // 
            this.保管员.HeaderText = "保管员";
            this.保管员.Name = "保管员";
            this.保管员.ReadOnly = true;
            this.保管员.Width = 120;
            // 
            // 出库日期
            // 
            this.出库日期.DataPropertyName = "OrderOutInventoryTime";
            this.出库日期.HeaderText = "拣货日期";
            this.出库日期.Name = "出库日期";
            this.出库日期.ReadOnly = true;
            // 
            // 复核员
            // 
            this.复核员.HeaderText = "第一复核员";
            this.复核员.Name = "复核员";
            this.复核员.ReadOnly = true;
            // 
            // 第二复核员
            // 
            this.第二复核员.HeaderText = "第二复核员";
            this.第二复核员.Name = "第二复核员";
            this.第二复核员.ReadOnly = true;
            this.第二复核员.Visible = false;
            // 
            // 审核结果
            // 
            this.审核结果.DataPropertyName = "OrderOutInventoryTime";
            this.审核结果.HeaderText = "审核结果";
            this.审核结果.Name = "审核结果";
            this.审核结果.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.NullValue = "合格";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "复核结果";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            // pagerControl
            // 
            this.pagerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pagerControl.Location = new System.Drawing.Point(0, 340);
            this.pagerControl.Name = "pagerControl";
            this.pagerControl.PageIndex = 1;
            this.pagerControl.PageSize = 20;
            this.pagerControl.RecordCount = 0;
            this.pagerControl.Size = new System.Drawing.Size(488, 45);
            this.pagerControl.TabIndex = 9;
            this.pagerControl.DataPaging += new PagerControl.PagerControl.Paging(this.pagerControl_DataPaging);
            // 
            // FormOutInventorySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 373);
            this.Controls.Add(this.dgvOutInventory);
            this.Controls.Add(this.pagerControl);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormOutInventorySearch";
            this.Text = "出库记录查询/出库审核记录查询";
            this.Load += new System.EventHandler(this.FormOutInventoryIndex_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.DataGridView dgvOutInventory;
        private PagerControl.PagerControl pagerControl;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 订单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 金额合计;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 保管员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 复核员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 第二复核员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 审核结果;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn 查看详细;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}