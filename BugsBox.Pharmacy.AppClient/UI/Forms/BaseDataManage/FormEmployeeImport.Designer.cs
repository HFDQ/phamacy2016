namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormEmployeeImport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.员工号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.邮箱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.级别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学历 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.职责 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开始工作日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.特点专长 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.药师职称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.证书编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.证书日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部门代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 266);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.lblFile);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtFilePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 37);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(659, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 21);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(553, 10);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(66, 21);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(7, 12);
            this.lblFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(53, 12);
            this.lblFile.TabIndex = 8;
            this.lblFile.Text = "导入文件";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(447, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 21);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "浏览…";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(66, 10);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(367, 21);
            this.txtFilePath.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.员工号,
            this.联系地址,
            this.姓名,
            this.性别,
            this.身份证,
            this.电话,
            this.邮箱,
            this.级别,
            this.学历,
            this.职责,
            this.生日,
            this.开始工作日,
            this.特点专长,
            this.药师职称,
            this.证书编号,
            this.证书日期,
            this.部门代码});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 43);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(741, 199);
            this.dataGridView1.TabIndex = 1;
            // 
            // 员工号
            // 
            this.员工号.DataPropertyName = "员工号";
            this.员工号.HeaderText = "员工号";
            this.员工号.Name = "员工号";
            this.员工号.ReadOnly = true;
            // 
            // 联系地址
            // 
            this.联系地址.DataPropertyName = "联系地址";
            this.联系地址.HeaderText = "联系地址";
            this.联系地址.Name = "联系地址";
            this.联系地址.ReadOnly = true;
            // 
            // 姓名
            // 
            this.姓名.DataPropertyName = "姓名";
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.ReadOnly = true;
            // 
            // 性别
            // 
            this.性别.DataPropertyName = "性别";
            this.性别.HeaderText = "性别";
            this.性别.Name = "性别";
            this.性别.ReadOnly = true;
            // 
            // 身份证
            // 
            this.身份证.DataPropertyName = "身份证";
            this.身份证.HeaderText = "身份证";
            this.身份证.Name = "身份证";
            this.身份证.ReadOnly = true;
            // 
            // 电话
            // 
            this.电话.DataPropertyName = "电话";
            this.电话.HeaderText = "电话";
            this.电话.Name = "电话";
            this.电话.ReadOnly = true;
            // 
            // 邮箱
            // 
            this.邮箱.DataPropertyName = "邮箱";
            this.邮箱.HeaderText = "邮箱";
            this.邮箱.Name = "邮箱";
            this.邮箱.ReadOnly = true;
            // 
            // 级别
            // 
            this.级别.DataPropertyName = "级别";
            this.级别.HeaderText = "级别";
            this.级别.Name = "级别";
            this.级别.ReadOnly = true;
            // 
            // 学历
            // 
            this.学历.DataPropertyName = "学历";
            this.学历.HeaderText = "学历";
            this.学历.Name = "学历";
            this.学历.ReadOnly = true;
            // 
            // 职责
            // 
            this.职责.DataPropertyName = "职责";
            this.职责.HeaderText = "职责";
            this.职责.Name = "职责";
            this.职责.ReadOnly = true;
            // 
            // 生日
            // 
            this.生日.DataPropertyName = "生日";
            this.生日.HeaderText = "生日";
            this.生日.Name = "生日";
            this.生日.ReadOnly = true;
            // 
            // 开始工作日
            // 
            this.开始工作日.DataPropertyName = "开始工作日";
            this.开始工作日.HeaderText = "开始工作日";
            this.开始工作日.Name = "开始工作日";
            this.开始工作日.ReadOnly = true;
            // 
            // 特点专长
            // 
            this.特点专长.DataPropertyName = "特点专长";
            this.特点专长.HeaderText = "特点专长";
            this.特点专长.Name = "特点专长";
            this.特点专长.ReadOnly = true;
            // 
            // 药师职称
            // 
            this.药师职称.DataPropertyName = "药师职称";
            this.药师职称.HeaderText = "药师职称";
            this.药师职称.Name = "药师职称";
            this.药师职称.ReadOnly = true;
            // 
            // 证书编号
            // 
            this.证书编号.DataPropertyName = "证书编号";
            this.证书编号.HeaderText = "证书编号";
            this.证书编号.Name = "证书编号";
            this.证书编号.ReadOnly = true;
            // 
            // 证书日期
            // 
            this.证书日期.DataPropertyName = "证书日期";
            this.证书日期.HeaderText = "证书日期";
            this.证书日期.Name = "证书日期";
            this.证书日期.ReadOnly = true;
            // 
            // 部门代码
            // 
            this.部门代码.DataPropertyName = "部门代码";
            this.部门代码.HeaderText = "部门代码";
            this.部门代码.Name = "部门代码";
            this.部门代码.ReadOnly = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(2, 246);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 18);
            this.progressBar1.TabIndex = 2;
            // 
            // FormEmployeeImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormEmployeeImport";
            this.Text = "员工信息导入";
            this.Load += new System.EventHandler(this.FormEmployeeImport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 员工号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 邮箱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 级别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学历;
        private System.Windows.Forms.DataGridViewTextBoxColumn 职责;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开始工作日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 特点专长;
        private System.Windows.Forms.DataGridViewTextBoxColumn 药师职称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 证书编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 证书日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部门代码;
    }
}