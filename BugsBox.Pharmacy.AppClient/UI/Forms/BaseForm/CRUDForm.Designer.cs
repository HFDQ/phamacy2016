namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    partial class CRUDForm
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
            this.crudControl1 = new BugsBox.Pharmacy.UI.Common.CRUDControl();
            this.SuspendLayout();
            // 
            // crudControl1
            // 
            this.crudControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crudControl1.EditId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.crudControl1.Location = new System.Drawing.Point(0, 0);
            this.crudControl1.Name = "crudControl1";
            this.crudControl1.SearchFields = null;
            this.crudControl1.Size = new System.Drawing.Size(634, 369);
            this.crudControl1.TabIndex = 0;
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 369);
            this.Controls.Add(this.crudControl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CRUDForm";
            this.Text = "CRUDForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Pharmacy.UI.Common.CRUDControl crudControl1;
    }
}