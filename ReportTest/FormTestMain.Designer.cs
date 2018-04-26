namespace ReportTest
{
    partial class FormTestMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewWordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewWordToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewWordToolStripMenuItem
            // 
            this.viewWordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewWordToolStripMenuItem1,
            this.printWordToolStripMenuItem,
            this.exportWordToolStripMenuItem});
            this.viewWordToolStripMenuItem.Name = "viewWordToolStripMenuItem";
            this.viewWordToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.viewWordToolStripMenuItem.Text = "Basic";
            // 
            // viewWordToolStripMenuItem1
            // 
            this.viewWordToolStripMenuItem1.Name = "viewWordToolStripMenuItem1";
            this.viewWordToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.viewWordToolStripMenuItem1.Text = "ViewWord";
            this.viewWordToolStripMenuItem1.Click += new System.EventHandler(this.viewWordToolStripMenuItem1_Click);
            // 
            // printWordToolStripMenuItem
            // 
            this.printWordToolStripMenuItem.Name = "printWordToolStripMenuItem";
            this.printWordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printWordToolStripMenuItem.Text = "PrintWord";
            this.printWordToolStripMenuItem.Click += new System.EventHandler(this.printWordToolStripMenuItem_Click);
            // 
            // exportWordToolStripMenuItem
            // 
            this.exportWordToolStripMenuItem.Name = "exportWordToolStripMenuItem";
            this.exportWordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportWordToolStripMenuItem.Text = "ExportWord";
            this.exportWordToolStripMenuItem.Click += new System.EventHandler(this.exportWordToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // FormTestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTestMain";
            this.Text = "FormTestMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewWordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}