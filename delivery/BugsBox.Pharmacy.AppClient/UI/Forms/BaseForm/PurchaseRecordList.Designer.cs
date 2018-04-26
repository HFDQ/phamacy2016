namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    partial class PurchaseRecordList
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
            this.ucPurchaseRecord1 = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucPurchaseRecord();
            this.SuspendLayout();
            // 
            // ucPurchaseRecord1
            // 
            this.ucPurchaseRecord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPurchaseRecord1.Location = new System.Drawing.Point(0, 0);
            this.ucPurchaseRecord1.Name = "ucPurchaseRecord1";
            this.ucPurchaseRecord1.Size = new System.Drawing.Size(817, 419);
            this.ucPurchaseRecord1.TabIndex = 0;
            // 
            // PurchaseRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 419);
            this.Controls.Add(this.ucPurchaseRecord1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PurchaseRecordList";
            this.Text = "采购记录";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucPurchaseRecord ucPurchaseRecord1;

    }
}