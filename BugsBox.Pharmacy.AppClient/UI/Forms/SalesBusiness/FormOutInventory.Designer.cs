namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormOutInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOutInventory));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSubmit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAccept = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOrderReturn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabContorl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.tabContorl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubmit,
            this.tsbtnAccept,
            this.tsbtnPrint,
            this.tsbtnOrderReturn,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1312, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Cart_Ok;
            this.btnSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(74, 28);
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tsbtnAccept
            // 
            this.tsbtnAccept.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Doc_Lock;
            this.tsbtnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAccept.Name = "tsbtnAccept";
            this.tsbtnAccept.Size = new System.Drawing.Size(110, 28);
            this.tsbtnAccept.Text = "出库复核";
            this.tsbtnAccept.Click += new System.EventHandler(this.tsbtnAccept_Click);
            // 
            // tsbtnPrint
            // 
            this.tsbtnPrint.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.PrintHS;
            this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrint.Name = "tsbtnPrint";
            this.tsbtnPrint.Size = new System.Drawing.Size(74, 28);
            this.tsbtnPrint.Text = "打印";
            this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
            // 
            // tsbtnOrderReturn
            // 
            this.tsbtnOrderReturn.Image = global::BugsBox.Pharmacy.AppClient.Properties.Resources.Cart_Del;
            this.tsbtnOrderReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOrderReturn.Name = "tsbtnOrderReturn";
            this.tsbtnOrderReturn.Size = new System.Drawing.Size(146, 28);
            this.tsbtnOrderReturn.Text = "库内销退申请";
            this.tsbtnOrderReturn.Visible = false;
            this.tsbtnOrderReturn.Click += new System.EventHandler(this.tsbtnOrderReturn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tabContorl
            // 
            this.tabContorl.Controls.Add(this.tabPage1);
            this.tabContorl.Controls.Add(this.tabPage2);
            this.tabContorl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContorl.Location = new System.Drawing.Point(0, 31);
            this.tabContorl.Margin = new System.Windows.Forms.Padding(4);
            this.tabContorl.Name = "tabContorl";
            this.tabContorl.SelectedIndex = 0;
            this.tabContorl.Size = new System.Drawing.Size(1312, 715);
            this.tabContorl.TabIndex = 6;
            this.tabContorl.SelectedIndexChanged += new System.EventHandler(this.tabContorl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1304, 683);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "拣货单1(审核中)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1304, 683);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "拣货单(审核中)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(122, 28);
            this.toolStripButton1.Text = "电子标签显示";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // FormOutInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 746);
            this.Controls.Add(this.tabContorl);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormOutInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品拣货编辑画面";
            this.Load += new System.EventHandler(this.FormOutInventory_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabContorl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSubmit;
        private System.Windows.Forms.ToolStripButton tsbtnAccept;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnPrint;
        private System.Windows.Forms.TabControl tabContorl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UCOutInventory ucOutInventory1;
        private UCOutInventory ucOutInventory2;
        private System.Windows.Forms.ToolStripButton tsbtnOrderReturn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}