namespace BugsBox.Pharmacy.UI.Common.UserControls
{
    partial class UserControlBillDocumentCode
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCode
            // 
            this.labelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCode.Location = new System.Drawing.Point(0, 0);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(120, 20);
            this.labelCode.TabIndex = 0;
            this.labelCode.Text = "labelCode";
            this.labelCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlBillDocumentCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCode);
            this.Name = "UserControlBillDocumentCode";
            this.Size = new System.Drawing.Size(120, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCode;
    }
}
