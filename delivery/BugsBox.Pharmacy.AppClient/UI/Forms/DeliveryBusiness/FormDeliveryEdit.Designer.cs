namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{
    partial class FormDeliveryEdit
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSubmit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOuted = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSigned = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOrderReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gbEntrust = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTransportCompany = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtPrincipalPhone = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTransportMethod = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.userControlBillDocumentCode1 = new BugsBox.Pharmacy.UI.Common.UserControls.UserControlBillDocumentCode();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblManifestNumber = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDrugCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblsign = new System.Windows.Forms.Label();
            this.signdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.gbEntrust.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSubmit,
            this.tsbtnCancel,
            this.tsbtnOuted,
            this.tsbtnSigned,
            this.tsbtnOrderReturn,
            this.toolStripSeparator3,
            this.tsbtnPrint,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(653, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSubmit
            // 
            this.tsbtnSubmit.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Save1;
            this.tsbtnSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSubmit.Name = "tsbtnSubmit";
            this.tsbtnSubmit.Size = new System.Drawing.Size(52, 22);
            this.tsbtnSubmit.Text = "提交";
            this.tsbtnSubmit.Click += new System.EventHandler(this.tsbtnSubmit_Click);
            // 
            // tsbtnCancel
            // 
            this.tsbtnCancel.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Cancel;
            this.tsbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancel.Name = "tsbtnCancel";
            this.tsbtnCancel.Size = new System.Drawing.Size(52, 22);
            this.tsbtnCancel.Text = "取消";
            this.tsbtnCancel.Click += new System.EventHandler(this.tsbtnCancel_Click);
            // 
            // tsbtnOuted
            // 
            this.tsbtnOuted.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Cart_Ok;
            this.tsbtnOuted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOuted.Name = "tsbtnOuted";
            this.tsbtnOuted.Size = new System.Drawing.Size(52, 22);
            this.tsbtnOuted.Text = "出库";
            this.tsbtnOuted.Click += new System.EventHandler(this.tsbtnOuted_Click);
            // 
            // tsbtnSigned
            // 
            this.tsbtnSigned.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Note_Ok;
            this.tsbtnSigned.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSigned.Name = "tsbtnSigned";
            this.tsbtnSigned.Size = new System.Drawing.Size(52, 22);
            this.tsbtnSigned.Text = "签收";
            this.tsbtnSigned.Click += new System.EventHandler(this.tsbtnSigned_Click);
            // 
            // tsbtnOrderReturn
            // 
            this.tsbtnOrderReturn.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Comments;
            this.tsbtnOrderReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOrderReturn.Name = "tsbtnOrderReturn";
            this.tsbtnOrderReturn.Size = new System.Drawing.Size(124, 22);
            this.tsbtnOrderReturn.Text = "配送出库退货申请";
            this.tsbtnOrderReturn.Visible = false;
            this.tsbtnOrderReturn.Click += new System.EventHandler(this.tsbtnOrderReturn_Click);
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
            this.tsbtnPrint.Size = new System.Drawing.Size(52, 22);
            this.tsbtnPrint.Text = "打印";
            this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gbEntrust
            // 
            this.gbEntrust.Controls.Add(this.label21);
            this.gbEntrust.Controls.Add(this.cmbVehicle);
            this.gbEntrust.Controls.Add(this.label17);
            this.gbEntrust.Controls.Add(this.txtTransportCompany);
            this.gbEntrust.Controls.Add(this.label16);
            this.gbEntrust.Controls.Add(this.textBox1);
            this.gbEntrust.Controls.Add(this.txtPrincipalPhone);
            this.gbEntrust.Controls.Add(this.label15);
            this.gbEntrust.Controls.Add(this.txtPrincipal);
            this.gbEntrust.Controls.Add(this.label14);
            this.gbEntrust.Controls.Add(this.cmbTransportMethod);
            this.gbEntrust.Controls.Add(this.label9);
            this.gbEntrust.Controls.Add(this.label13);
            this.gbEntrust.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbEntrust.Location = new System.Drawing.Point(0, 338);
            this.gbEntrust.Name = "gbEntrust";
            this.gbEntrust.Size = new System.Drawing.Size(653, 156);
            this.gbEntrust.TabIndex = 78;
            this.gbEntrust.TabStop = false;
            this.gbEntrust.Text = "委托配送";
            this.gbEntrust.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(74, 134);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(311, 12);
            this.label21.TabIndex = 83;
            this.label21.Text = "﹡运输工具信息包括(运输工具类型,容积,牌号,补充信息)";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(77, 107);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(554, 20);
            this.cmbVehicle.TabIndex = 87;
            this.cmbVehicle.SelectedIndexChanged += new System.EventHandler(this.cmbVehicle_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 111);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 86;
            this.label17.Text = "运输工具：";
            // 
            // txtTransportCompany
            // 
            this.txtTransportCompany.Location = new System.Drawing.Point(77, 80);
            this.txtTransportCompany.MaxLength = 20;
            this.txtTransportCompany.Name = "txtTransportCompany";
            this.txtTransportCompany.Size = new System.Drawing.Size(331, 21);
            this.txtTransportCompany.TabIndex = 83;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 84);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 84;
            this.label16.Text = "运输公司：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 23);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 21);
            this.textBox1.TabIndex = 81;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPrincipalPhone
            // 
            this.txtPrincipalPhone.Location = new System.Drawing.Point(287, 53);
            this.txtPrincipalPhone.MaxLength = 20;
            this.txtPrincipalPhone.Name = "txtPrincipalPhone";
            this.txtPrincipalPhone.Size = new System.Drawing.Size(121, 21);
            this.txtPrincipalPhone.TabIndex = 81;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(205, 57);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 82;
            this.label15.Text = "委托人电话：";
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.Location = new System.Drawing.Point(77, 53);
            this.txtPrincipal.MaxLength = 20;
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(121, 21);
            this.txtPrincipal.TabIndex = 79;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 57);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 80;
            this.label14.Text = "委托人：";
            // 
            // cmbTransportMethod
            // 
            this.cmbTransportMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportMethod.Enabled = false;
            this.cmbTransportMethod.FormattingEnabled = true;
            this.cmbTransportMethod.Location = new System.Drawing.Point(77, 24);
            this.cmbTransportMethod.Name = "cmbTransportMethod";
            this.cmbTransportMethod.Size = new System.Drawing.Size(121, 20);
            this.cmbTransportMethod.TabIndex = 79;
            this.cmbTransportMethod.SelectedValueChanged += new System.EventHandler(this.cmbTransportMethod_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 79;
            this.label9.Text = "委托车辆查询：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 79;
            this.label13.Text = "运输方式：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 71);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自有车辆配送";
            this.groupBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(75, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "﹡运输工具信息包括(运输工具类型,容积,牌号,补充信息)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(554, 20);
            this.comboBox1.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 86;
            this.label3.Text = "车辆信息：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 242);
            this.groupBox2.TabIndex = 86;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配送情报";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblsign);
            this.groupBox4.Controls.Add(this.signdateTimePicker1);
            this.groupBox4.Controls.Add(this.dtDeliveryDate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtMemo);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtDeliveryAddress);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cmbDeliveryMethod);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtShippingAddress);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 222);
            this.groupBox4.TabIndex = 107;
            this.groupBox4.TabStop = false;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(80, 112);
            this.txtMemo.MaxLength = 100;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(267, 26);
            this.txtMemo.TabIndex = 114;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(35, 119);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 113;
            this.label20.Text = "备注：";
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Location = new System.Drawing.Point(80, 82);
            this.txtDeliveryAddress.MaxLength = 100;
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(267, 21);
            this.txtDeliveryAddress.TabIndex = 112;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 111;
            this.label8.Text = "收货地址：";
            // 
            // cmbDeliveryMethod
            // 
            this.cmbDeliveryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMethod.FormattingEnabled = true;
            this.cmbDeliveryMethod.Items.AddRange(new object[] {
            "客户自理",
            "自有运输工具",
            "委托运输"});
            this.cmbDeliveryMethod.Location = new System.Drawing.Point(80, 21);
            this.cmbDeliveryMethod.Name = "cmbDeliveryMethod";
            this.cmbDeliveryMethod.Size = new System.Drawing.Size(266, 20);
            this.cmbDeliveryMethod.TabIndex = 110;
            this.cmbDeliveryMethod.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveryMethod_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 109;
            this.label6.Text = "配送方式：";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(80, 51);
            this.txtShippingAddress.MaxLength = 100;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(267, 21);
            this.txtShippingAddress.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 107;
            this.label4.Text = "发货地址：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.userControlBillDocumentCode1);
            this.groupBox3.Controls.Add(this.lblCompanyName);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblManifestNumber);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblDrugCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblOrderID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(358, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 222);
            this.groupBox3.TabIndex = 106;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "订单信息";
            // 
            // userControlBillDocumentCode1
            // 
            this.userControlBillDocumentCode1.BackColor = System.Drawing.Color.Transparent;
            this.userControlBillDocumentCode1.Location = new System.Drawing.Point(169, 29);
            this.userControlBillDocumentCode1.Name = "userControlBillDocumentCode1";
            this.userControlBillDocumentCode1.Size = new System.Drawing.Size(120, 20);
            this.userControlBillDocumentCode1.TabIndex = 115;
            this.userControlBillDocumentCode1.Type = BugsBox.Pharmacy.Models.BillDocumentType.Test;
            this.userControlBillDocumentCode1.ViewMode = false;
            this.userControlBillDocumentCode1.Visible = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(72, 99);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(65, 12);
            this.lblCompanyName.TabIndex = 114;
            this.lblCompanyName.Text = "某某某公司";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 99);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 113;
            this.label18.Text = "收货公司：";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(72, 41);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 12);
            this.lblStatus.TabIndex = 112;
            this.lblStatus.Text = "配送预约";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 111;
            this.label11.Text = "配送状态：";
            // 
            // lblManifestNumber
            // 
            this.lblManifestNumber.AutoSize = true;
            this.lblManifestNumber.Location = new System.Drawing.Point(72, 22);
            this.lblManifestNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManifestNumber.Name = "lblManifestNumber";
            this.lblManifestNumber.Size = new System.Drawing.Size(59, 12);
            this.lblManifestNumber.TabIndex = 110;
            this.lblManifestNumber.Text = "xxxx-xxxx";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 109;
            this.label10.Text = "货单号：";
            // 
            // lblDrugCount
            // 
            this.lblDrugCount.AutoSize = true;
            this.lblDrugCount.Location = new System.Drawing.Point(72, 80);
            this.lblDrugCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDrugCount.Name = "lblDrugCount";
            this.lblDrugCount.Size = new System.Drawing.Size(29, 12);
            this.lblDrugCount.TabIndex = 108;
            this.lblDrugCount.Text = "20箱";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 107;
            this.label5.Text = "药品数量：";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(72, 61);
            this.lblOrderID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(59, 12);
            this.lblOrderID.TabIndex = 106;
            this.lblOrderID.Text = "xxxx-xxxx";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 105;
            this.label7.Text = "订单号：";
            // 
            // lblsign
            // 
            this.lblsign.AutoSize = true;
            this.lblsign.Location = new System.Drawing.Point(11, 180);
            this.lblsign.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsign.Name = "lblsign";
            this.lblsign.Size = new System.Drawing.Size(65, 12);
            this.lblsign.TabIndex = 121;
            this.lblsign.Text = "签收时间：";
            // 
            // signdateTimePicker1
            // 
            this.signdateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.signdateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.signdateTimePicker1.Location = new System.Drawing.Point(81, 180);
            this.signdateTimePicker1.Name = "signdateTimePicker1";
            this.signdateTimePicker1.ShowUpDown = true;
            this.signdateTimePicker1.Size = new System.Drawing.Size(266, 21);
            this.signdateTimePicker1.TabIndex = 120;
            // 
            // dtDeliveryDate
            // 
            this.dtDeliveryDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeliveryDate.Location = new System.Drawing.Point(79, 146);
            this.dtDeliveryDate.Name = "dtDeliveryDate";
            this.dtDeliveryDate.ShowUpDown = true;
            this.dtDeliveryDate.Size = new System.Drawing.Size(267, 21);
            this.dtDeliveryDate.TabIndex = 119;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 118;
            this.label2.Text = "配送时间：";
            // 
            // FormDeliveryEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(653, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbEntrust);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeliveryEdit";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配送情报编辑";
            this.Load += new System.EventHandler(this.FormDeliveryEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbEntrust.ResumeLayout(false);
            this.gbEntrust.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSubmit;
        private System.Windows.Forms.ToolStripButton tsbtnCancel;
        private System.Windows.Forms.ToolStripButton tsbtnOuted;
        private System.Windows.Forms.ToolStripButton tsbtnSigned;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnPrint;
        private System.Windows.Forms.GroupBox gbEntrust;
        private System.Windows.Forms.ComboBox cmbTransportMethod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrincipalPhone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTransportCompany;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripButton tsbtnOrderReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDeliveryMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private Pharmacy.UI.Common.UserControls.UserControlBillDocumentCode userControlBillDocumentCode1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblManifestNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDrugCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblsign;
        private System.Windows.Forms.DateTimePicker signdateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtDeliveryDate;
        private System.Windows.Forms.Label label2;
    }
}