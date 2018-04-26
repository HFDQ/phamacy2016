namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    partial class FormGoodsAdditionalProperty
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
            this.ucGoodsAdditionalProperty1 = new BugsBox.Pharmacy.AppClient.UI.UserControls.ucGoodsAdditionalProperty();
            this.SuspendLayout();
            // 
            // ucGoodsAdditionalProperty1
            // 
            this.ucGoodsAdditionalProperty1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGoodsAdditionalProperty1.DrugInfo = null;
            this.ucGoodsAdditionalProperty1.GoodsAdditional = null;
            this.ucGoodsAdditionalProperty1.Location = new System.Drawing.Point(0, 0);
            this.ucGoodsAdditionalProperty1.Name = "ucGoodsAdditionalProperty1";
            this.ucGoodsAdditionalProperty1.RunMode = BugsBox.Pharmacy.UI.Common.FormRunMode.Add;
            this.ucGoodsAdditionalProperty1.Size = new System.Drawing.Size(606, 334);
            this.ucGoodsAdditionalProperty1.TabIndex = 0;
            // 
            // FormGoodsAdditionalProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 334);
            this.Controls.Add(this.ucGoodsAdditionalProperty1);
            this.Name = "FormGoodsAdditionalProperty";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGoodsAdditionalProperty";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGoodsAdditionalProperty_FormClosed);
            this.Load += new System.EventHandler(this.FormGoodsAdditionalProperty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucGoodsAdditionalProperty ucGoodsAdditionalProperty1;

    }
}