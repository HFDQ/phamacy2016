namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    partial class ServiceControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceControlButton = new BugsBox.Pharmacy.ServiceHost.UserControls.ServiceControlButton();
            this.SuspendLayout();
            // 
            // serviceControlButton
            // 
            this.serviceControlButton.BackColor = System.Drawing.SystemColors.Control;
            this.serviceControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceControlButton.Location = new System.Drawing.Point(0, 0);
            this.serviceControlButton.Name = "serviceControlButton";
            this.serviceControlButton.Size = new System.Drawing.Size(160, 45);
            this.serviceControlButton.Status = BugsBox.Pharmacy.ServiceHost.UserControls.Status.Stop;
            this.serviceControlButton.TabIndex = 0;
            this.serviceControlButton.Title = "Title";
            this.serviceControlButton.Load += new System.EventHandler(this.serviceControlButton_Load);
            // 
            // ServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.serviceControlButton);
            this.Name = "ServiceControl";
            this.Size = new System.Drawing.Size(160, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceControlButton serviceControlButton;
    }
}
