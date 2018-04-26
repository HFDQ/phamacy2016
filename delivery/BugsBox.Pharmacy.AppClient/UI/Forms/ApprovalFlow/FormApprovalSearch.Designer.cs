namespace BugsBox.Pharmacy.AppClient.UI.Forms.Approval
{
    partial class FormApprovalSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApprovalList = new System.Windows.Forms.DataGridView();
            this.事件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.事件说明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提交时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvApprovalNodeList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作理由 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.审批人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbApprovalType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtChangeString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plDetailView = new System.Windows.Forms.Panel();
            this.btnCloseDetail = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.plDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.63708F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.51677F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 507);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApprovalList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询结果";
            // 
            // dgvApprovalList
            // 
            this.dgvApprovalList.AllowUserToAddRows = false;
            this.dgvApprovalList.AllowUserToDeleteRows = false;
            this.dgvApprovalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprovalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.事件,
            this.事件说明,
            this.提交时间,
            this.状态,
            this.查看详细});
            this.dgvApprovalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApprovalList.Location = new System.Drawing.Point(3, 17);
            this.dgvApprovalList.MultiSelect = false;
            this.dgvApprovalList.Name = "dgvApprovalList";
            this.dgvApprovalList.ReadOnly = true;
            this.dgvApprovalList.RowTemplate.Height = 23;
            this.dgvApprovalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalList.Size = new System.Drawing.Size(804, 246);
            this.dgvApprovalList.TabIndex = 0;
            this.dgvApprovalList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprovalList_CellContentClick);
            this.dgvApprovalList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApprovalList_CellFormatting);
            this.dgvApprovalList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprovalList_RowEnter);
            // 
            // 事件
            // 
            this.事件.DataPropertyName = "ApprovalFlowTypeId";
            this.事件.HeaderText = "事件";
            this.事件.Name = "事件";
            this.事件.ReadOnly = true;
            this.事件.Width = 150;
            // 
            // 事件说明
            // 
            this.事件说明.DataPropertyName = "ChangeNote";
            this.事件说明.HeaderText = "事件说明";
            this.事件说明.Name = "事件说明";
            this.事件说明.ReadOnly = true;
            this.事件说明.Width = 300;
            // 
            // 提交时间
            // 
            this.提交时间.DataPropertyName = "CreateTime";
            this.提交时间.HeaderText = "提交时间";
            this.提交时间.Name = "提交时间";
            this.提交时间.ReadOnly = true;
            this.提交时间.Width = 120;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "Status";
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            this.状态.ReadOnly = true;
            this.状态.Width = 120;
            // 
            // 查看详细
            // 
            this.查看详细.HeaderText = "查看详细";
            this.查看详细.Name = "查看详细";
            this.查看详细.ReadOnly = true;
            this.查看详细.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.查看详细.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.查看详细.Text = "详细";
            this.查看详细.UseColumnTextForButtonValue = true;
            this.查看详细.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvApprovalNodeList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "审批流程详细";
            // 
            // dgvApprovalNodeList
            // 
            this.dgvApprovalNodeList.AllowUserToAddRows = false;
            this.dgvApprovalNodeList.AllowUserToDeleteRows = false;
            this.dgvApprovalNodeList.AllowUserToOrderColumns = true;
            this.dgvApprovalNodeList.AllowUserToResizeRows = false;
            this.dgvApprovalNodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprovalNodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.操作理由,
            this.审批人,
            this.ApproveTime});
            this.dgvApprovalNodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApprovalNodeList.Location = new System.Drawing.Point(3, 17);
            this.dgvApprovalNodeList.Name = "dgvApprovalNodeList";
            this.dgvApprovalNodeList.ReadOnly = true;
            this.dgvApprovalNodeList.RowTemplate.Height = 23;
            this.dgvApprovalNodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalNodeList.Size = new System.Drawing.Size(804, 151);
            this.dgvApprovalNodeList.TabIndex = 34;
            this.dgvApprovalNodeList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApprovalNodeList_CellFormatting);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 60;
            // 
            // 操作理由
            // 
            this.操作理由.DataPropertyName = "Comment";
            this.操作理由.HeaderText = "操作理由";
            this.操作理由.Name = "操作理由";
            this.操作理由.ReadOnly = true;
            this.操作理由.Width = 300;
            // 
            // 审批人
            // 
            this.审批人.DataPropertyName = "ApproveUserId";
            this.审批人.HeaderText = "审批人";
            this.审批人.Name = "审批人";
            this.审批人.ReadOnly = true;
            // 
            // ApproveTime
            // 
            this.ApproveTime.DataPropertyName = "ApproveTime";
            this.ApproveTime.HeaderText = "提交时间";
            this.ApproveTime.Name = "ApproveTime";
            this.ApproveTime.ReadOnly = true;
            this.ApproveTime.Width = 120;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbApprovalType);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txtChangeString);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(810, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // cmbApprovalType
            // 
            this.cmbApprovalType.FormattingEnabled = true;
            this.cmbApprovalType.Location = new System.Drawing.Point(69, 20);
            this.cmbApprovalType.Name = "cmbApprovalType";
            this.cmbApprovalType.Size = new System.Drawing.Size(128, 20);
            this.cmbApprovalType.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "*模糊查询";
            // 
            // btnSearch
            // 
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(501, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 23);
            this.btnSearch.TabIndex = 39;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtChangeString
            // 
            this.txtChangeString.Location = new System.Drawing.Point(272, 20);
            this.txtChangeString.Name = "txtChangeString";
            this.txtChangeString.Size = new System.Drawing.Size(148, 21);
            this.txtChangeString.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "变更内容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "审批流程：";
            // 
            // plDetailView
            // 
            this.plDetailView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plDetailView.Controls.Add(this.btnCloseDetail);
            this.plDetailView.Location = new System.Drawing.Point(3, 17);
            this.plDetailView.Name = "plDetailView";
            this.plDetailView.Size = new System.Drawing.Size(809, 445);
            this.plDetailView.TabIndex = 3;
            this.plDetailView.Visible = false;
            // 
            // btnCloseDetail
            // 
            this.btnCloseDetail.Location = new System.Drawing.Point(909, 3);
            this.btnCloseDetail.Name = "btnCloseDetail";
            this.btnCloseDetail.Size = new System.Drawing.Size(25, 23);
            this.btnCloseDetail.TabIndex = 0;
            this.btnCloseDetail.Text = "X";
            this.btnCloseDetail.UseVisualStyleBackColor = true;
            this.btnCloseDetail.Click += new System.EventHandler(this.btnCloseDetail_Click);
            // 
            // FormApprovalSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.plDetailView);
            this.Name = "FormApprovalSearch";
            this.Text = "审批流程查询画面";
            this.Load += new System.EventHandler(this.FormApprovalSearch_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.plDetailView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvApprovalList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvApprovalNodeList;
        private System.Windows.Forms.Panel plDetailView;
        private System.Windows.Forms.Button btnCloseDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtChangeString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbApprovalType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事件;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事件说明;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提交时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewButtonColumn 查看详细;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作理由;
        private System.Windows.Forms.DataGridViewTextBoxColumn 审批人;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveTime;

    }
}