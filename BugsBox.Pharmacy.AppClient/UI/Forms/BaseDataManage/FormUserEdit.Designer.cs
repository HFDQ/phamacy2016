namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    partial class FormUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserEdit));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdEableN = new System.Windows.Forms.RadioButton();
            this.rdEnableY = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmployeeN0 = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccout = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regularExpressionValidator1 = new CustomValidatorsLibrary.RegularExpressionValidator();
            this.requiredFieldValidator1 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.requiredFieldValidator2 = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.bugsBoxFocusColorProvider1 = new BugsBox.Windows.Forms.BugsBoxFocusColorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 191);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 24);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEmployeeN0);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtAccout);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 155);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdEableN);
            this.panel3.Controls.Add(this.rdEnableY);
            this.panel3.Location = new System.Drawing.Point(89, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 33);
            this.panel3.TabIndex = 26;
            // 
            // rdEableN
            // 
            this.rdEableN.AutoSize = true;
            this.rdEableN.Location = new System.Drawing.Point(59, 9);
            this.rdEableN.Name = "rdEableN";
            this.rdEableN.Size = new System.Drawing.Size(29, 16);
            this.rdEableN.TabIndex = 27;
            this.rdEableN.TabStop = true;
            this.rdEableN.Text = "N";
            this.rdEableN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdEableN.UseVisualStyleBackColor = true;
            // 
            // rdEnableY
            // 
            this.rdEnableY.AutoSize = true;
            this.rdEnableY.Location = new System.Drawing.Point(3, 9);
            this.rdEnableY.Name = "rdEnableY";
            this.rdEnableY.Size = new System.Drawing.Size(29, 16);
            this.rdEnableY.TabIndex = 26;
            this.rdEnableY.TabStop = true;
            this.rdEnableY.Text = "Y";
            this.rdEnableY.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "是否启用：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmployeeN0
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.txtEmployeeN0, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.txtEmployeeN0, System.Drawing.Color.White);
            this.txtEmployeeN0.Location = new System.Drawing.Point(89, 112);
            this.txtEmployeeN0.Name = "txtEmployeeN0";
            this.txtEmployeeN0.Size = new System.Drawing.Size(282, 21);
            this.txtEmployeeN0.TabIndex = 17;
            this.txtEmployeeN0.Visible = false;
            // 
            // txtPassword
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.txtPassword, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.txtPassword, System.Drawing.Color.White);
            this.txtPassword.Location = new System.Drawing.Point(90, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(282, 21);
            this.txtPassword.TabIndex = 13;
            // 
            // txtAccout
            // 
            this.bugsBoxFocusColorProvider1.SetFocusBackColor(this.txtAccout, System.Drawing.Color.MediumBlue);
            this.bugsBoxFocusColorProvider1.SetFocusForeColor(this.txtAccout, System.Drawing.Color.White);
            this.txtAccout.Location = new System.Drawing.Point(89, 3);
            this.txtAccout.MaxLength = 16;
            this.txtAccout.Name = "txtAccout";
            this.txtAccout.Size = new System.Drawing.Size(282, 21);
            this.txtAccout.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "员工号：";
            this.label8.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户账号：";
            // 
            // regularExpressionValidator1
            // 
            this.regularExpressionValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("regularExpressionValidator1.Icon")));
            this.regularExpressionValidator1.ValidationExpression = "[\\w-]+@([\\w-]+\\.)+[\\w-]+";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ControlToValidate = this.txtAccout;
            this.requiredFieldValidator1.ErrorMessage = "登录账户不能为空";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ControlToValidate = this.txtPassword;
            this.requiredFieldValidator2.ErrorMessage = "登录密码不能为空";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // FormUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 191);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormUserEdit";
            this.Load += new System.EventHandler(this.FormUserEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccout;
        private System.Windows.Forms.TextBox txtEmployeeN0;
        private System.Windows.Forms.Label label6;
        private CustomValidatorsLibrary.RegularExpressionValidator regularExpressionValidator1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdEableN;
        private System.Windows.Forms.RadioButton rdEnableY;
        private Windows.Forms.BugsBoxFocusColorProvider bugsBoxFocusColorProvider1;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator1;
        private CustomValidatorsLibrary.RequiredFieldValidator requiredFieldValidator2;
    }
}