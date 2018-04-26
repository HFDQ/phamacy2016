using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Services;

namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    public partial class ServiceControl : UserControl
    {
        private ServiceContext context = null;

        public ServiceControl()
        {

            InitializeComponent();
            if (!DesignMode)
            {
                context = ServiceContext.Instance;
                InitControls();
            }
        }

        protected void InitControls()
        {
            this.serviceControlButton.Title = "服务";
            this.serviceControlButton.BackColor = Color.FromArgb(223, 233, 246);
            this.serviceControlButton.StartFun = StartService;
            this.serviceControlButton.StopFun = StopService;
            this.serviceControlButton.Status = context.ServiceStarted ? Status.Start : Status.Stop;
        }

        public Status StartService()
        {
            try
            {
                string message = string.Empty;
                context.StartService(out message);
                Status status = (context.ServiceStarted) ? Status.Start : Status.Stop;
                if (context.ServiceStarted)
                {
                    //MessageBox.Show("启动服务成功！", "服务控制",MessageBoxButtons.OK,MessageBoxIcon.Information);  
                }
                else
                {
                    MessageBox.Show("启动服务失败！", "服务控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动服务失败！", "服务控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Status.Stop;
            }

        }
        public Status StopService()
        {
            try
            {
                string message = string.Empty;
                context.StopService(out message);
                Status status = context.ServiceStarted ? Status.Start : Status.Stop;
                if (!context.ServiceStarted)
                {
                    //MessageBox.Show("停止服务成功！", "服务控制", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                }
                else
                {
                    MessageBox.Show("停止服务失败！", "服务控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("停止服务失败！", "服务控制", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Status.Stop;
            }
        }

        internal void ShowServiceStatus()
        {
            this.serviceControlButton.Status = context.ServiceStarted ? Status.Start : Status.Stop;
        }

        private void serviceControlButton_Load(object sender, EventArgs e)
        {

        }
    }
}
