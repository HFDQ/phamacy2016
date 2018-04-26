namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormOutInventoryCenter
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
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.dgvOutInventory = new System.Windows.Forms.DataGridView();
            this.出库单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销售订单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创建时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.保管员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制单人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出库类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1179, 32);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 29);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 29);
            this.toolStripLabel1.Text = "单号：";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(268, 32);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "销售出库质量复核",
            "采购退货质量复核"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(180, 32);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(154, 29);
            this.toolStripLabel2.Text = "出库复合单类型：";
            // 
            // dgvOutInventory
            // 
            this.dgvOutInventory.AllowUserToAddRows = false;
            this.dgvOutInventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOutInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.出库单号,
            this.销售订单号,
            this.创建时间,
            this.保管员,
            this.制单人,
            this.出库类型,
            this.查看详细});
            this.dgvOutInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutInventory.Location = new System.Drawing.Point(0, 32);
            this.dgvOutInventory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOutInventory.Name = "dgvOutInventory";
            this.dgvOutInventory.ReadOnly = true;
            this.dgvOutInventory.RowHeadersVisible = false;
            this.dgvOutInventory.RowTemplate.Height = 23;
            this.dgvOutInventory.Size = new System.Drawing.Size(1179, 511);
            this.dgvOutInventory.TabIndex = 7;
            this.dgvOutInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutInventory_CellContentClick);
            // 
            // 出库单号
            // 
            this.出库单号.DataPropertyName = "OutInventoryOrderCode";
            this.出库单号.HeaderText = "出库单号";
            this.出库单号.Name = "出库单号";
            this.出库单号.ReadOnly = true;
            this.出库单号.Width = 120;
            // 
            // 销售订单号
            // 
            this.销售订单号.DataPropertyName = "OrderCode";
            this.销售订单号.HeaderText = "订单号";
            this.销售订单号.Name = "销售订单号";
            this.销售订单号.ReadOnly = true;
            this.销售订单号.Width = 120;
            // 
            // 创建时间
            // 
            this.创建时间.DataPropertyName = "SalesOrderCreateTimeStr";
            this.创建时间.HeaderText = "创建时间";
            this.创建时间.Name = "创建时间";
            this.创建时间.ReadOnly = true;
            // 
            // 保管员
            // 
            this.保管员.DataPropertyName = "InventoryKeeper";
            this.保管员.HeaderText = "保管员";
            this.保管员.Name = "保管员";
            this.保管员.ReadOnly = true;
            this.保管员.Width = 120;
            // 
            // 制单人
            // 
            this.制单人.DataPropertyName = "SalerName";
            this.制单人.HeaderText = "销售员";
            this.制单人.Name = "制单人";
            this.制单人.ReadOnly = true;
            this.制单人.Visible = false;
            // 
            // 出库类型
            // 
            this.出库类型.DataPropertyName = "OutInventoryTypeStr";
            this.出库类型.HeaderText = "出库类型";
            this.出库类型.Name = "出库类型";
            this.出库类型.ReadOnly = true;
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
            // FormOutInventoryCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 543);
            this.Controls.Add(this.dgvOutInventory);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormOutInventoryCenter";
            this.Text = "出库单审核中心";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvOutInventory;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销售订单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 保管员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制单人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出库类型;
        private System.Windows.Forms.DataGridViewButtonColumn 查看详细;
    }
}