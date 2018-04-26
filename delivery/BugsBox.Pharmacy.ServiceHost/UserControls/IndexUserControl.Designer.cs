namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    partial class IndexUserControl
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
            this.buttonModifyCreateDataAuto = new System.Windows.Forms.Button();
            this.serviceControl1 = new BugsBox.Pharmacy.ServiceHost.UserControls.ServiceControl();
            this.SuspendLayout();
            // 
            // buttonModifyCreateDataAuto
            // 
            this.buttonModifyCreateDataAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModifyCreateDataAuto.Location = new System.Drawing.Point(84, 179);
            this.buttonModifyCreateDataAuto.Name = "buttonModifyCreateDataAuto";
            this.buttonModifyCreateDataAuto.Size = new System.Drawing.Size(196, 23);
            this.buttonModifyCreateDataAuto.TabIndex = 1;
            this.buttonModifyCreateDataAuto.Text = "修改自动创建数据库配置为True";
            this.buttonModifyCreateDataAuto.UseVisualStyleBackColor = true;
            this.buttonModifyCreateDataAuto.Visible = false;
            this.buttonModifyCreateDataAuto.Click += new System.EventHandler(this.buttonModifyCreateDataAuto_Click);
            // 
            // serviceControl1
            // 
            this.serviceControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceControl1.Location = new System.Drawing.Point(107, 208);
            this.serviceControl1.Name = "serviceControl1";
            this.serviceControl1.Size = new System.Drawing.Size(173, 49);
            this.serviceControl1.TabIndex = 0;
            // 
            // IndexUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
         
            this.Controls.Add(this.buttonModifyCreateDataAuto);
            this.Controls.Add(this.serviceControl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        
            this.Name = "IndexUserControl";
            this.Text = "首页";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IndexUserControl_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IndexUserControl_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceControl serviceControl1;
        private System.Windows.Forms.Button buttonModifyCreateDataAuto;
    }
}
