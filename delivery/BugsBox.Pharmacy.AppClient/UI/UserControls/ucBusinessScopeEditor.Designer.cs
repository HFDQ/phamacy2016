namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    partial class ucBusinessScopeEditor
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
            this.checkedListBoxBusinessScopes = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxBusinessScopes
            // 
            this.checkedListBoxBusinessScopes.CausesValidation = false;
            this.checkedListBoxBusinessScopes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxBusinessScopes.FormattingEnabled = true;
            this.checkedListBoxBusinessScopes.HorizontalExtent = 2;
            this.checkedListBoxBusinessScopes.HorizontalScrollbar = true;
            this.checkedListBoxBusinessScopes.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxBusinessScopes.MultiColumn = true;
            this.checkedListBoxBusinessScopes.Name = "checkedListBoxBusinessScopes";
            this.checkedListBoxBusinessScopes.ScrollAlwaysVisible = true;
            this.checkedListBoxBusinessScopes.Size = new System.Drawing.Size(338, 262);
            this.checkedListBoxBusinessScopes.TabIndex = 92;
            // 
            // ucBusinessScopeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkedListBoxBusinessScopes);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucBusinessScopeEditor";
            this.Size = new System.Drawing.Size(338, 262);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxBusinessScopes;

    }
}
