namespace BugsBox.Pharmacy.AppClient.UI.Reports
{
    partial class FormPurchaseOrderReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.salesOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesOrderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSOrder";
            reportDataSource1.Value = this.salesOrderBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BugsBox.Pharmacy.AppClient.UI.Reports.RptPurchaseCheckingOrder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(849, 268);
            this.reportViewer1.TabIndex = 0;
            // 
            // salesOrderBindingSource
            // 
            this.salesOrderBindingSource.DataSource = typeof(BugsBox.Pharmacy.Models.SalesOrder);
            // 
            // salesOrderBindingSource1
            // 
            this.salesOrderBindingSource1.DataSource = typeof(BugsBox.Pharmacy.Models.SalesOrder);
            // 
            // FormPurchaseOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 292);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormPurchaseOrderReport";
            this.Text = "FormPurchaseOrderReport";
            this.Load += new System.EventHandler(this.FormPurchaseOrderReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource salesOrderBindingSource;
        private System.Windows.Forms.BindingSource salesOrderBindingSource1;
    }
}