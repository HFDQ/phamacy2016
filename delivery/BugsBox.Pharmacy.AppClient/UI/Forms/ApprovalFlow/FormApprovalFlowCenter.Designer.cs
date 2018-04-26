namespace BugsBox.Pharmacy.AppClient.UI.Forms.Approval
{
    partial class FormApprovalFlowCenter
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvApprovalNodeList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label24 = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.txtOperatorReason = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.plDetailView = new System.Windows.Forms.Panel();
            this.btnCloseDetail = new System.Windows.Forms.Button();
            this.事件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.事件说明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提交时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看详细 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colFlowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).BeginInit();
            this.plDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 843);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApprovalList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1346, 497);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待审批事件";
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
            this.查看详细,
            this.colFlowID});
            this.dgvApprovalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApprovalList.Location = new System.Drawing.Point(4, 25);
            this.dgvApprovalList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvApprovalList.MultiSelect = false;
            this.dgvApprovalList.Name = "dgvApprovalList";
            this.dgvApprovalList.ReadOnly = true;
            this.dgvApprovalList.RowTemplate.Height = 23;
            this.dgvApprovalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalList.Size = new System.Drawing.Size(1338, 468);
            this.dgvApprovalList.TabIndex = 0;
            this.dgvApprovalList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprovalList_CellContentClick);
            this.dgvApprovalList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApprovalList_CellFormatting);
            this.dgvApprovalList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprovalList_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvApprovalNodeList);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.btnReject);
            this.groupBox2.Controls.Add(this.txtOperatorReason);
            this.groupBox2.Controls.Add(this.btnAccept);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 509);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1346, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "审批";
            // 
            // dgvApprovalNodeList
            // 
            this.dgvApprovalNodeList.AllowUserToAddRows = false;
            this.dgvApprovalNodeList.AllowUserToDeleteRows = false;
            this.dgvApprovalNodeList.AllowUserToOrderColumns = true;
            this.dgvApprovalNodeList.AllowUserToResizeRows = false;
            this.dgvApprovalNodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApprovalNodeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApprovalNodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprovalNodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.Status,
            this.Comment,
            this.ApproveUserName,
            this.ApproveTime});
            this.dgvApprovalNodeList.Location = new System.Drawing.Point(4, 26);
            this.dgvApprovalNodeList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvApprovalNodeList.Name = "dgvApprovalNodeList";
            this.dgvApprovalNodeList.ReadOnly = true;
            this.dgvApprovalNodeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvApprovalNodeList.RowTemplate.Height = 23;
            this.dgvApprovalNodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalNodeList.Size = new System.Drawing.Size(1333, 245);
            this.dgvApprovalNodeList.TabIndex = 34;
            this.dgvApprovalNodeList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApprovalNodeList_CellFormatting);
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "Order";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "备注";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // ApproveUserName
            // 
            this.ApproveUserName.DataPropertyName = "ApproveUserName";
            this.ApproveUserName.HeaderText = " 创建人/审批人";
            this.ApproveUserName.Name = "ApproveUserName";
            this.ApproveUserName.ReadOnly = true;
            // 
            // ApproveTime
            // 
            this.ApproveTime.DataPropertyName = "ApproveTime";
            this.ApproveTime.HeaderText = "提交时间";
            this.ApproveTime.Name = "ApproveTime";
            this.ApproveTime.ReadOnly = true;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 292);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(98, 18);
            this.label24.TabIndex = 33;
            this.label24.Text = "审批意见：";
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReject.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Forbidden;
            this.btnReject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReject.Location = new System.Drawing.Point(1218, 284);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnReject.Size = new System.Drawing.Size(120, 34);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "拒绝";
            this.btnReject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // txtOperatorReason
            // 
            this.txtOperatorReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperatorReason.Location = new System.Drawing.Point(116, 284);
            this.txtOperatorReason.Margin = new System.Windows.Forms.Padding(4);
            this.txtOperatorReason.Name = "txtOperatorReason";
            this.txtOperatorReason.Size = new System.Drawing.Size(954, 28);
            this.txtOperatorReason.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAccept.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Ok;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(1088, 284);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnAccept.Size = new System.Drawing.Size(120, 34);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "审批通过";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // plDetailView
            // 
            this.plDetailView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plDetailView.Controls.Add(this.btnCloseDetail);
            this.plDetailView.Location = new System.Drawing.Point(4, 26);
            this.plDetailView.Margin = new System.Windows.Forms.Padding(4);
            this.plDetailView.Name = "plDetailView";
            this.plDetailView.Size = new System.Drawing.Size(1346, 758);
            this.plDetailView.TabIndex = 1;
            this.plDetailView.Visible = false;
            // 
            // btnCloseDetail
            // 
            this.btnCloseDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDetail.Location = new System.Drawing.Point(1304, 4);
            this.btnCloseDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseDetail.Name = "btnCloseDetail";
            this.btnCloseDetail.Size = new System.Drawing.Size(38, 34);
            this.btnCloseDetail.TabIndex = 0;
            this.btnCloseDetail.Text = "X";
            this.btnCloseDetail.UseVisualStyleBackColor = true;
            this.btnCloseDetail.Click += new System.EventHandler(this.btnCloseDetail_Click);
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
            // colFlowID
            // 
            this.colFlowID.DataPropertyName = "FlowId";
            this.colFlowID.HeaderText = "审核特征码";
            this.colFlowID.Name = "colFlowID";
            this.colFlowID.ReadOnly = true;
            // 
            // FormApprovalFlowCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 843);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.plDetailView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormApprovalFlowCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "审批中心";
            this.Load += new System.EventHandler(this.FormApprovalFlowCenter_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).EndInit();
            this.plDetailView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvApprovalList;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.TextBox txtOperatorReason;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dgvApprovalNodeList;
        private System.Windows.Forms.Panel plDetailView;
        private System.Windows.Forms.Button btnCloseDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事件;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事件说明;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提交时间;
        private System.Windows.Forms.DataGridViewButtonColumn 查看详细;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlowID;
    }
}