namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormApprovalManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApprovalManager));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvApprovalNodeList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.审批人角色 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.roleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbApprovalFlowCat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbApprovalFlowType = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAdd,
            this.btnDelete,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 22);
            this.btnAdd.Text = "新增节点";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Delete1;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 22);
            this.btnDelete.Text = "删除节点";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Save1;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 22);
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvApprovalNodeList
            // 
            this.dgvApprovalNodeList.AllowUserToResizeRows = false;
            this.dgvApprovalNodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApprovalNodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprovalNodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.Column1,
            this.描述,
            this.审批人角色});
            this.dgvApprovalNodeList.Location = new System.Drawing.Point(216, 166);
            this.dgvApprovalNodeList.Name = "dgvApprovalNodeList";
            this.dgvApprovalNodeList.RowTemplate.Height = 23;
            this.dgvApprovalNodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApprovalNodeList.Size = new System.Drawing.Size(604, 258);
            this.dgvApprovalNodeList.TabIndex = 48;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "Order";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "节点名";
            this.Column1.MaxInputLength = 20;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // 描述
            // 
            this.描述.DataPropertyName = "Decription";
            this.描述.HeaderText = "描述";
            this.描述.MaxInputLength = 512;
            this.描述.Name = "描述";
            this.描述.Width = 250;
            // 
            // 审批人角色
            // 
            this.审批人角色.DataPropertyName = "RoleId";
            this.审批人角色.DataSource = this.roleBindingSource;
            this.审批人角色.HeaderText = "审批人角色";
            this.审批人角色.Name = "审批人角色";
            this.审批人角色.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.审批人角色.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "节点编辑：";
            // 
            // txtDecription
            // 
            this.txtDecription.Location = new System.Drawing.Point(216, 87);
            this.txtDecription.Multiline = true;
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.ReadOnly = true;
            this.txtDecription.Size = new System.Drawing.Size(401, 52);
            this.txtDecription.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "描述：";
            // 
            // cmbApprovalFlowCat
            // 
            this.cmbApprovalFlowCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovalFlowCat.FormattingEnabled = true;
            this.cmbApprovalFlowCat.Location = new System.Drawing.Point(73, 36);
            this.cmbApprovalFlowCat.Name = "cmbApprovalFlowCat";
            this.cmbApprovalFlowCat.Size = new System.Drawing.Size(121, 20);
            this.cmbApprovalFlowCat.TabIndex = 43;
            this.cmbApprovalFlowCat.SelectedIndexChanged += new System.EventHandler(this.cmbApprovalFlowCat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "审批分类：";
            // 
            // lbApprovalFlowType
            // 
            this.lbApprovalFlowType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbApprovalFlowType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbApprovalFlowType.FormattingEnabled = true;
            this.lbApprovalFlowType.ItemHeight = 14;
            this.lbApprovalFlowType.Items.AddRange(new object[] {
            "供应商A审批",
            "采购商A审批",
            "药品A审批"});
            this.lbApprovalFlowType.Location = new System.Drawing.Point(14, 71);
            this.lbApprovalFlowType.Name = "lbApprovalFlowType";
            this.lbApprovalFlowType.Size = new System.Drawing.Size(180, 340);
            this.lbApprovalFlowType.TabIndex = 42;
            this.lbApprovalFlowType.SelectedValueChanged += new System.EventHandler(this.lbApprovalFlowType_SelectedValueChanged);
            // 
            // FormApprovalManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 436);
            this.Controls.Add(this.dgvApprovalNodeList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDecription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbApprovalFlowCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbApprovalFlowType);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormApprovalManager";
            this.Text = "审批类型管理";
            this.Load += new System.EventHandler(this.FormApprovalManager_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovalNodeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvApprovalNodeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbApprovalFlowCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbApprovalFlowType;
        private System.Windows.Forms.BindingSource roleBindingSource;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 描述;
        private System.Windows.Forms.DataGridViewComboBoxColumn 审批人角色;

    }
}