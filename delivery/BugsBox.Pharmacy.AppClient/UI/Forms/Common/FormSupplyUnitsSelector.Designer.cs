namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormSupplyUnitsSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPY = new System.Windows.Forms.TextBox();
            this.cbJYFW = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameSupply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salesman = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.salesmantel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleScope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHistorySuplyUnit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "拼音：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "经营范围：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(71, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtPY
            // 
            this.txtPY.Location = new System.Drawing.Point(213, 10);
            this.txtPY.Name = "txtPY";
            this.txtPY.Size = new System.Drawing.Size(100, 21);
            this.txtPY.TabIndex = 4;
            // 
            // cbJYFW
            // 
            this.cbJYFW.FormattingEnabled = true;
            this.cbJYFW.Location = new System.Drawing.Point(379, 10);
            this.cbJYFW.Name = "cbJYFW";
            this.cbJYFW.Size = new System.Drawing.Size(121, 20);
            this.cbJYFW.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameSupply,
            this.Code,
            this.Salesman,
            this.salesmantel,
            this.saleScope,
            this.id});
            this.dataGridView1.Location = new System.Drawing.Point(15, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(813, 229);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // NameSupply
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NameSupply.DefaultCellStyle = dataGridViewCellStyle1;
            this.NameSupply.HeaderText = "供货单位名称";
            this.NameSupply.Name = "NameSupply";
            // 
            // Code
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Code.DefaultCellStyle = dataGridViewCellStyle2;
            this.Code.HeaderText = "编码";
            this.Code.Name = "Code";
            // 
            // Salesman
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Salesman.DefaultCellStyle = dataGridViewCellStyle3;
            this.Salesman.HeaderText = "销售员";
            this.Salesman.Name = "Salesman";
            // 
            // salesmantel
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.salesmantel.DefaultCellStyle = dataGridViewCellStyle4;
            this.salesmantel.HeaderText = "销售员电话";
            this.salesmantel.Name = "salesmantel";
            this.salesmantel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salesmantel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // saleScope
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.saleScope.DefaultCellStyle = dataGridViewCellStyle5;
            this.saleScope.HeaderText = "销售范围";
            this.saleScope.Name = "saleScope";
            this.saleScope.ReadOnly = true;
            this.saleScope.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.saleScope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.saleScope.Width = 300;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // btnHistorySuplyUnit
            // 
            this.btnHistorySuplyUnit.Location = new System.Drawing.Point(620, 10);
            this.btnHistorySuplyUnit.Name = "btnHistorySuplyUnit";
            this.btnHistorySuplyUnit.Size = new System.Drawing.Size(105, 23);
            this.btnHistorySuplyUnit.TabIndex = 8;
            this.btnHistorySuplyUnit.Text = "查询历史供应商";
            this.btnHistorySuplyUnit.UseVisualStyleBackColor = true;
            this.btnHistorySuplyUnit.Click += new System.EventHandler(this.btnHistorySuplyUnit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(731, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "供方销售员";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormSupplyUnitsSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 278);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnHistorySuplyUnit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbJYFW);
            this.Controls.Add(this.txtPY);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormSupplyUnitsSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择供应商";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPY;
        private System.Windows.Forms.ComboBox cbJYFW;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnHistorySuplyUnit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameSupply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewComboBoxColumn Salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesmantel;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleScope;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}