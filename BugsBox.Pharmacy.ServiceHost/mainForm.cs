using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.ServiceHost.Forms;
using BugsBox.Pharmacy.ServiceHost.UserControls;
using BugsBox.Pharmacy.Services;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.ServiceHost
{

    public partial class mainForm : Form
    {
        WindowStateEventArgs ws = new WindowStateEventArgs();
        public mainForm()
        {
            InitializeComponent();

            //this.skinEngine1.SkinFile = "office2007.ssk";
            ws.OnWindowState += new EventHandler<WindowStateEventArgs>(mainForm_WindowStateChanged);

            this.FormClosing += mainForm_FormClosing;
            this.Load += mainForm_Load;
        }

        void mainForm_Load(object sender, EventArgs e)
        {
            runTimeLogsUserControl1.Log(LogLevel.Information, null, "开始初始化");
            Task.Factory.StartNew(() =>
            {
                serviceControl2.StartService();

            });
        }

        void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            serviceControl2.StopService();
            System.Environment.Exit(0);
        }



        void mainForm_WindowStateChanged(object sender, WindowStateEventArgs e)
        {
            notifyIcon1.Visible = !notifyIcon1.Visible;
            this.ShowInTaskbar = !this.ShowInTaskbar;
            this.Visible = !this.Visible;
            this.WindowState = this.Visible ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            InitControls();
            if (!DesignMode)
            {
                this.notifyIcon1.Text = this.Text;
            }
        }

        private void InitControls()
        {
            this.toolStripStatusLabelVersion.Font = new Font("宋体", 9);
            this.toolStripStatusLabelVersion.Text = string.Format("Version:{0}", AssemblyInfoHelper.AssemblyVersion);

            this.Text = string.Format("{0}--服务端", AppConfig.SystemName);
        }
        private bool NeedClose = false;

        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("您确定关闭服务吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (ServiceContext.Instance.ServiceStarted)
                    {
                        BusinessHandlerFactory.DisposeBusinessHandlerFactories();
                    }
                    string msg;
                    ServiceContext.Instance.StopService(out msg);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Instance.Error(ex);
                }
                NeedClose = true;
                e.Cancel = false;
                base.OnClosing(e);
            }
            else
            {
                NeedClose = false;
                e.Cancel = true;
            }

        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ws.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ws.WindowState = FormWindowState.Normal;
        }

        private void mainForm_Deactivate(object sender, EventArgs e)
        {
            ws.WindowState = this.WindowState;
        }

        private void serviceControl2_Load(object sender, EventArgs e)
        {

        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            serviceControl2.Focus();
        }

        private void 升级数据库版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定需要升级数据库？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            var re = ServiceContext.LoadConnectionStringSettings();
            try
            {
                System.Data.SqlClient.SqlConnection oleConnection = new System.Data.SqlClient.SqlConnection(re.ConnectionString);
                oleConnection.Open();

                string sql = "select * from __MigrationHistory";
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(sql, oleConnection);

                DataSet dsM = new DataSet();
                sda.Fill(dsM);

                DataTable dtM = dsM.Tables[0];

                Action<System.Data.SqlClient.SqlConnection, System.Data.SqlClient.SqlDataAdapter,
                    DataSet, DataTable> ReleaseDb = (a, b, c, d) =>
                    {
                        a.Close(); a.Dispose(); a = null;
                        b.Dispose(); b = null;
                        c.Dispose(); c = null;
                        d.Dispose(); d = null;
                    };

                var v = dtM.AsEnumerable().OrderBy(r => r.Field<string>(0)).LastOrDefault();
                DateTime DBMDT = DateTime.ParseExact(v.Field<string>(0).Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None);

                DateTime MDT = DateTime.ParseExact(DataBaseMigrationDataModel.MigrationKeys.MigrationId.Substring(0, 8), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None);

                if (MDT <= DBMDT)
                {
                    MessageBox.Show("数据库服务器已经是最新的版本！");

                    ReleaseDb(oleConnection, sda, dsM, dtM);
                    return;
                }
                System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
                System.Data.SqlClient.SqlTransaction sqltrans = oleConnection.BeginTransaction();
                sqlc.Connection = oleConnection;
                sqlc.Transaction = sqltrans;

                string ins = "INSERT INTO __MigrationHistory (MigrationId,ProductVersion,Model) VALUES('" + DataBaseMigrationDataModel.MigrationKeys.MigrationId + "','" + DataBaseMigrationDataModel.MigrationKeys.ProductVersion + "'," + DataBaseMigrationDataModel.MigrationKeys.Model + ")";

                sqlc.CommandText = ins;
                sqlc.ExecuteNonQuery();

                System.IO.StreamReader sr = new System.IO.StreamReader("pharmacy_Update3.publish.sql", Encoding.UTF8);
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@";Initial Catalog=\w+;");
                var Regdbname = reg.Match(re.ConnectionString).ToString();
                Regdbname = Regdbname.Substring(0, Regdbname.Length - 1);
                int idx = Regdbname.LastIndexOf("=");
                string DBName = Regdbname.Substring(idx + 1);
                sqlc.CommandText = string.Format("use [{0}] ", DBName);
                bool IsNote = false;
                while (sr.Peek() > -1)
                {
                    string s = sr.ReadLine();
                    if (string.IsNullOrEmpty(s.Trim())) continue;

                    if (s.StartsWith("/*"))
                        IsNote = true;

                    if (s.StartsWith("*/"))
                    {
                        IsNote = false;
                        continue;
                    }

                    if (s.Trim().Contains("GO"))
                    {
                        continue;
                    }

                    if (s.StartsWith(":"))
                    {
                        s = s.Substring(1);
                    }

                    if (s.Trim().Contains("USE [$(DatabaseName)]"))
                    {
                        continue;
                    }

                    if (s.Contains("PRINT"))
                    {
                        continue;
                    }

                    if (!IsNote)
                    {
                        sqlc.CommandText += s + "\r\n";
                    }
                }

                sqlc.ExecuteNonQuery();
                sqltrans.Commit();
                sqlc.Dispose();
                sqlc = null;

                ReleaseDb(oleConnection, sda, dsM, dtM);
                MessageBox.Show("数据库服务器升级完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }


        }


    }
    public class WindowStateEventArgs : EventArgs
    {
        public EventHandler<WindowStateEventArgs> OnWindowState;
        private FormWindowState _windowState;
        public FormWindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                if (value != _windowState)
                {
                    OnWindowState(this, new WindowStateEventArgs());
                }
                _windowState = value;
            }
        }
    }

    public class MigrationClass
    {
        public string MigrationId { get; set; }

        public string ContexKey { get; set; }

        public string Model { get; set; }

        public string ProductVersion { get; set; }
    }


}
