namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormModule
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
            this.tblpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcUserMain = new PagerControl.PagerControl();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModuleCategory = new System.Windows.Forms.ComboBox();
            this.tblpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.pnlCommand.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tblpMain
            // 
            this.tblpMain.ColumnCount = 1;
            this.tblpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpMain.Controls.Add(this.panel1, 0, 1);
            this.tblpMain.Controls.Add(this.pnlCommand, 0, 0);
            this.tblpMain.Controls.Add(this.panel2, 0, 2);
            this.tblpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpMain.Location = new System.Drawing.Point(0, 0);
            this.tblpMain.Name = "tblpMain";
            this.tblpMain.RowCount = 3;
            this.tblpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tblpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpMain.Size = new System.Drawing.Size(534, 385);
            this.tblpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 44);
            this.panel1.TabIndex = 6;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.txtModule);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(528, 44);
            this.gbSearch.TabIndex = 11;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "搜索条件";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(79, 14);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(234, 21);
            this.txtModule.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "功能模块";
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnSearch);
            this.pnlCommand.Controls.Add(this.btnDelete);
            this.pnlCommand.Controls.Add(this.btnModify);
            this.pnlCommand.Controls.Add(this.btnAdd);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommand.Location = new System.Drawing.Point(3, 3);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(528, 27);
            this.pnlCommand.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(392, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(282, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(172, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(62, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pcUserMain);
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbModuleCategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 296);
            this.panel2.TabIndex = 9;
            // 
            // pcUserMain
            // 
            this.pcUserMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcUserMain.Location = new System.Drawing.Point(0, 249);
            this.pcUserMain.Name = "pcUserMain";
            this.pcUserMain.PageIndex = 1;
            this.pcUserMain.PageSize = 20;
            this.pcUserMain.RecordCount = 0;
            this.pcUserMain.Size = new System.Drawing.Size(528, 47);
            this.pcUserMain.TabIndex = 12;
            this.pcUserMain.DataPaging += new PagerControl.PagerControl.Paging(this.pcUserMain_DataPaging);
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(528, 296);
            this.dgvData.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "功能模块大类";
            this.label1.Visible = false;
            // 
            // cmbModuleCategory
            // 
            this.cmbModuleCategory.FormattingEnabled = true;
            this.cmbModuleCategory.Location = new System.Drawing.Point(332, 3);
            this.cmbModuleCategory.Name = "cmbModuleCategory";
            this.cmbModuleCategory.Size = new System.Drawing.Size(126, 20);
            this.cmbModuleCategory.TabIndex = 1;
            this.cmbModuleCategory.Visible = false;
            // 
            // FormModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 385);
            this.Controls.Add(this.tblpMain);
            this.Name = "FormModule";
            this.Text = "功能模块";
            this.Load += new System.EventHandler(this.FormModule_Load);
            this.tblpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.pnlCommand.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblpMain;
        private System.Windows.Forms.Panel pnlCommand;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModuleCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private PagerControl.PagerControl pcUserMain;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbSearch;
    }
}