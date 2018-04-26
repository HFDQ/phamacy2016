namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    partial class FormCashOrder
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PurchaseOrderDocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerMethodValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentAmount = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCash = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPayment = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnCash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn1 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn2 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewCalendarColumn3 = new BugsBox.Windows.Forms.DataGridViewCalendarColumn();
            this.dataGridViewNumericUpDownColumn1 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn2 = new BugsBox.Windows.Forms.DataGridViewNumericUpDownColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseOrderDocumentNumber,
            this.DealerMethodValue,
            this.TotalAmount,
            this.PaymentedAmount,
            this.PaymentingAmount,
            this.PaymentAmount});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(860, 277);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // PurchaseOrderDocumentNumber
            // 
            this.PurchaseOrderDocumentNumber.DataPropertyName = "PurchaseOrderDocumentNumber";
            this.PurchaseOrderDocumentNumber.HeaderText = "采购单号";
            this.PurchaseOrderDocumentNumber.Name = "PurchaseOrderDocumentNumber";
            this.PurchaseOrderDocumentNumber.ReadOnly = true;
            // 
            // DealerMethodValue
            // 
            this.DealerMethodValue.DataPropertyName = "DealerMethodValue";
            this.DealerMethodValue.HeaderText = "经销方式";
            this.DealerMethodValue.Name = "DealerMethodValue";
            this.DealerMethodValue.ReadOnly = true;
            this.DealerMethodValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DealerMethodValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = " 单据金额";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // PaymentedAmount
            // 
            this.PaymentedAmount.DataPropertyName = "PaymentedAmount";
            this.PaymentedAmount.HeaderText = "已付金额";
            this.PaymentedAmount.Name = "PaymentedAmount";
            this.PaymentedAmount.ReadOnly = true;
            // 
            // PaymentingAmount
            // 
            this.PaymentingAmount.DataPropertyName = "PaymentingAmount";
            this.PaymentingAmount.HeaderText = "本次应付金额";
            this.PaymentingAmount.Name = "PaymentingAmount";
            this.PaymentingAmount.ReadOnly = true;
            this.PaymentingAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PaymentAmount
            // 
            this.PaymentAmount.DataPropertyName = "PaymentAmount";
            this.PaymentAmount.DecimalPlaces = 0;
            this.PaymentAmount.HeaderText = "本次付款金额";
            this.PaymentAmount.Name = "PaymentAmount";
            this.PaymentAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCash);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.lblOrderNo);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.lblCreateDate);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePickerPayment);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 133);
            this.panel1.TabIndex = 7;
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCash.Location = new System.Drawing.Point(688, 86);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(97, 31);
            this.btnCash.TabIndex = 82;
            this.btnCash.Text = "结  算";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(685, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 79;
            this.label6.Text = "供货单位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "备注：";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(283, 50);
            this.textBoxDescription.MaxLength = 200;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(261, 51);
            this.textBoxDescription.TabIndex = 69;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(757, 10);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(47, 13);
            this.lblOrderNo.TabIndex = 64;
            this.lblOrderNo.Text = "xxxxxxxx";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(685, 11);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 13);
            this.label.TabIndex = 63;
            this.label.Text = "结算单号：";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(756, 28);
            this.lblCreateDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(79, 13);
            this.lblCreateDate.TabIndex = 59;
            this.lblCreateDate.Text = "2013年8月7日";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(685, 30);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 13);
            this.label22.TabIndex = 57;
            this.label22.Text = "结算日期：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(342, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "采购结算单";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "付款方式：";
            // 
            // dateTimePickerPayment
            // 
            this.dateTimePickerPayment.Enabled = false;
            this.dateTimePickerPayment.Location = new System.Drawing.Point(78, 48);
            this.dateTimePickerPayment.Name = "dateTimePickerPayment";
            this.dateTimePickerPayment.Size = new System.Drawing.Size(122, 20);
            this.dateTimePickerPayment.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "付款日期：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCash,
            this.toolStripSeparator3,
            this.tsbtnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(860, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnCash
            // 
            this.tsbtnCash.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Cart_Ok;
            this.tsbtnCash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCash.Name = "tsbtnCash";
            this.tsbtnCash.Size = new System.Drawing.Size(49, 22);
            this.tsbtnCash.Text = "结算";
            this.tsbtnCash.ToolTipText = "结算";
            this.tsbtnCash.Click += new System.EventHandler(this.tsbtnAccept_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnPrint
            // 
            this.tsbtnPrint.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.PrintHS;
            this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrint.Name = "tsbtnPrint";
            this.tsbtnPrint.Size = new System.Drawing.Size(49, 22);
            this.tsbtnPrint.Text = "打印";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "单据编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductGeneralName";
            this.dataGridViewTextBoxColumn2.HeaderText = "药品通用名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.HeaderText = "到货日期";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.ReadOnly = true;
            this.dataGridViewCalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "生产批号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCalendarColumn2
            // 
            dataGridViewCellStyle1.Format = "d";
            this.dataGridViewCalendarColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCalendarColumn2.HeaderText = "生产日期";
            this.dataGridViewCalendarColumn2.Name = "dataGridViewCalendarColumn2";
            this.dataGridViewCalendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewCalendarColumn3
            // 
            dataGridViewCellStyle2.Format = "d";
            this.dataGridViewCalendarColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCalendarColumn3.HeaderText = "有效期至";
            this.dataGridViewCalendarColumn3.Name = "dataGridViewCalendarColumn3";
            this.dataGridViewCalendarColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.DecimalPlaces = 0;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewNumericUpDownColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewNumericUpDownColumn1.HeaderText = "到货数量";
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewNumericUpDownColumn2
            // 
            this.dataGridViewNumericUpDownColumn2.DecimalPlaces = 0;
            dataGridViewCellStyle4.Format = "N0";
            this.dataGridViewNumericUpDownColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewNumericUpDownColumn2.HeaderText = "验收合格数量";
            this.dataGridViewNumericUpDownColumn2.Name = "dataGridViewNumericUpDownColumn2";
            this.dataGridViewNumericUpDownColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "备注(注明不合格事项及处置措施)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // FormCashOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 435);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormCashOrder";
            this.ShowInTaskbar = false;
            this.Text = "采购结算单";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnCash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn2;
        private Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn3;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private Windows.Forms.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseOrderDocumentNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn DealerMethodValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentingAmount;
        private Windows.Forms.DataGridViewNumericUpDownColumn PaymentAmount;
        private System.Windows.Forms.Button btnCash;
    }
}