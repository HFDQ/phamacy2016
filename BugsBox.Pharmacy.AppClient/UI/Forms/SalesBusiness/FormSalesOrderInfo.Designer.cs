namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    partial class FormSalesOrderInfo
    {
        /// <summary>
        /// Required designer variable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalesOrderInfo));
            this.usSOInfo = new BugsBox.Pharmacy.AppClient.UI.UserControls.usSalesOrder();
            this.SuspendLayout();
            // 
            // usSOInfo
            // 
            this.usSOInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usSOInfo.Location = new System.Drawing.Point(0, 0);
            this.usSOInfo.Name = "usSOInfo";
            this.usSOInfo.SalesOrder = ((BugsBox.Pharmacy.AppClient.PS.SalesOrder)(resources.GetObject("usSOInfo.SalesOrder")));
            this.usSOInfo.Size = new System.Drawing.Size(693, 255);
            this.usSOInfo.TabIndex = 0;
            this.usSOInfo.TitleName = null;
            // 
            // FormSalesOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 255);
            this.Controls.Add(this.usSOInfo);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSalesOrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单信息";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.usSalesOrder usSOInfo;
    }
}