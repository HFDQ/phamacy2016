namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormModuleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModuleEdit));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPriKey = new System.Windows.Forms.TextBox();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.bbfcRoleEdit = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.requiredFieldValidator1 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator2 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator3 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 268);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 24);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtPriKey);
            this.panel2.Controls.Add(this.rtbDesc);
            this.panel2.Controls.Add(this.cmbCategory);
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Controls.Add(this.lblDesc);
            this.panel2.Controls.Add(this.txtModule);
            this.panel2.Controls.Add(this.lblModule);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 232);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "授权Key：";
            // 
            // txtPriKey
            // 
            this.bbfcRoleEdit.SetFocusBackColor(this.txtPriKey, System.Drawing.Color.MediumBlue);
            this.bbfcRoleEdit.SetFocusForeColor(this.txtPriKey, System.Drawing.Color.White);
            this.txtPriKey.Location = new System.Drawing.Point(113, 80);
            this.txtPriKey.MaxLength = 64;
            this.txtPriKey.Name = "txtPriKey";
            this.txtPriKey.Size = new System.Drawing.Size(262, 21);
            this.txtPriKey.TabIndex = 7;
            // 
            // rtbDesc
            // 
            this.bbfcRoleEdit.SetFocusBackColor(this.rtbDesc, System.Drawing.Color.MediumBlue);
            this.bbfcRoleEdit.SetFocusForeColor(this.rtbDesc, System.Drawing.Color.White);
            this.rtbDesc.Location = new System.Drawing.Point(113, 114);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(262, 74);
            this.rtbDesc.TabIndex = 9;
            this.rtbDesc.Text = "";
            // 
            // cmbCategory
            // 
            this.bbfcRoleEdit.SetFocusBackColor(this.cmbCategory, System.Drawing.Color.MediumBlue);
            this.bbfcRoleEdit.SetFocusForeColor(this.cmbCategory, System.Drawing.Color.White);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(113, 42);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(262, 20);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.CausesValidation = false;
            this.lblCategory.Location = new System.Drawing.Point(7, 45);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 12);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "所属类别：";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(9, 134);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(89, 12);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "功能模块描述：";
            // 
            // txtModule
            // 
            this.bbfcRoleEdit.SetFocusBackColor(this.txtModule, System.Drawing.Color.MediumBlue);
            this.bbfcRoleEdit.SetFocusForeColor(this.txtModule, System.Drawing.Color.White);
            this.txtModule.Location = new System.Drawing.Point(113, 9);
            this.txtModule.MaxLength = 64;
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(262, 21);
            this.txtModule.TabIndex = 3;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(9, 12);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(65, 12);
            this.lblModule.TabIndex = 2;
            this.lblModule.Text = "功能模块：";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ControlToValidate = this.txtModule;
            this.requiredFieldValidator1.ErrorMessage = "功能模块不能为空";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ControlToValidate = this.cmbCategory;
            this.requiredFieldValidator2.ErrorMessage = "模块类别不能为空";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ControlToValidate = this.txtPriKey;
            this.requiredFieldValidator3.ErrorMessage = "授权Key不能为空";
            this.requiredFieldValidator3.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator3.Icon")));
            // 
            // FormModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 268);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModuleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRoleEdit";
            this.Load += new System.EventHandler(this.FormRoleEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblCategory;
        private Windows.Forms.BugsBoxFocusColorProvider bbfcRoleEdit;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriKey;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator1;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator2;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator3;
    }
}