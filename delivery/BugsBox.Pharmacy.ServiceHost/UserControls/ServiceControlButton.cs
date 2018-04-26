using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    public partial class ServiceControlButton : UserControl
    {
        public ServiceControlButton()
        {
            InitializeComponent();
        }

        private Status _status;

        protected Image StopImage = null;
        protected Image StartImage = null;

        [Browsable(false)]
        public Status Status
        {
            get { return _status; }
            set
            {
                if (DesignMode)
                    return;
                _status = value;
                this.DoAction(c =>
                {
                    pictureBox1.Image = (_status == Status.Start) ? StartImage : StopImage; //图片
                    buttonControlService.Text = (_status == Status.Start) ? "停止" : "开启"; //按钮 
                });


            }
        } 

        [Browsable(true)]
        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        private void wsnButtonStart_Click(object sender, EventArgs e)
        {
            if (StartFun == null || StopFun == null)
                return;
            var thread = new Thread(delegate()
            {
                using (var a = new ControlActionable(this.buttonControlService, c => c.Enabled = false, c => c.Enabled = true))
                {
                    Func<Status> action = null;
                    switch (Status)
                    {
                        case Status.Start:
                            action = StopFun;
                            break;
                        case Status.Stop:
                            action = StartFun;
                            break;
                    }
                    this.Status = action();
                }

            });
            thread.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                StopImage = new Bitmap(typeof(Program), "Resources.Images.stop.png");
                StartImage = new Bitmap(typeof(Program), "Resources.Images.run.png");
                Status = Status.Stop;
               

                //wsnButtonStart_Click(null, null);
            }

        }

        public Func<Status> StartFun = default(Func<Status>);
        public Func<Status> StopFun = default(Func<Status>);
    }

    public enum Status
    {
        /// <summary>
        /// 停止
        /// </summary>
        Stop,
        /// <summary>
        /// 启动
        /// </summary>
        Start,

    }
}
