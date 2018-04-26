using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using Amib.Threading;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.Common;
using Omu.ValueInjecter;
using BugsBox.Common.Config;
namespace BugsBox.Pharmacy.AppClient
{
    public partial class AppSet : Form
    {
        readonly SmartThreadPool smartThreadPool = new SmartThreadPool();
        protected Image StopImage = null;
        protected Image StartImage = null;

        public AppSet()
        {
            InitializeComponent();
            //this.skinEngine1.SkinFile = "office2007.ssk";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ok=ServicesProvider.SetServiceHost(this.textBoxHost.Text.Trim()); 
                if (ok)
                {
                    string message = string.Empty;
                    var serverStores = ServicesProvider.Instance.PharmacyDatabaseService.AllStores(out message);
                    if (serverStores.Count() > 0)
                    {
                        PharmacyClientConfig.Config.ClientType = Models.StoreType.Branch; 
                        var serviceStore=serverStores.FirstOrDefault();
                        PharmacyClientConfig.Config.Store = serviceStore;
                        ConfigHelper<PharmacyClientConfig>.SaveConfig();
                        MessageBox.Show(this.Text+"保存设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show(this.Text+"服务端门店信息","提示" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(this.Text+"保存设置失败","错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show(this.Text+ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppSet_Load(object sender, EventArgs e)
        {
            StopImage = new Bitmap(typeof(Program), "Resources.stop.png");
            StartImage = new Bitmap(typeof(Program), "Resources.run.png");
            pictureBox1.Image = StopImage;
            BindServiceHost();
            TestContection();
        }

        private void BindServiceHost()
        {
            this.textBoxHost.Text = ServicesProvider.LoadServiceHost();
        }

        private void BindClientInfo()
        {
        }

        private void TestContection()
        {
            smartThreadPool.QueueWorkItem(()=>{

                using (var a = new ControlActionable(this.buttonTestConnection, c => c.Enabled = false, c => c.Enabled = true))
                {
                    try
                    {
                        bool ok = ServicesProvider.TestServiceConnection(this.textBoxHost.Text);
                        if (ok)
                        {
                            pictureBox1.Image = StartImage;
                        }
                        else
                        {
                            pictureBox1.Image = StopImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        LoggerHelper.Instance.Error(ex);
                        pictureBox1.Image = StopImage;
                    }
                 
                } 
            
            });
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            TestContection();
        }
    }

    // class AppConfigHelp
    //{
    //    private XmlDocument Doc = new XmlDocument();
    //    private AppDomain Ad = AppDomain.CurrentDomain;
    //    public AppConfigHelp() 
    //    {
    //        Doc.Load(Ad.SetupInformation.ConfigurationFile); 
    //    } 
    //    public void LoadAppConfig() 
    //    {
    //        Doc.Load(Ad.SetupInformation.ConfigurationFile); 
    //    }
    //    public void SetAppValue(string newValue) 
    //    {
    //        string newaddr = "net.tcp://" + newValue + ":5561/PharmacyDatabaseService";
    //        string newaddr1 = "net.tcp://" + newValue + ":5571/PharmacyNotificationService";
    //        XmlNodeList list = Doc.SelectNodes("/configuration/system.serviceModel/client/endpoint");
    //        list[0].Attributes["address"].Value = newaddr;
    //        list[1].Attributes["address"].Value = newaddr1; 
            
    //    }
    //    public void SaveAppConfig()
    //    {
    //        Doc.Save(Ad.SetupInformation.ConfigurationFile); 
    //        Doc.Load(Ad.SetupInformation.ConfigurationFile); 
    //    }

    //    public string GetWcfValue()
    //    {
    //        string address = Doc.SelectSingleNode("/configuration/system.serviceModel/client/endpoint").Attributes["address"].Value;
    //        Regex regPid = new Regex(@"net.tcp://(.*):5561/PharmacyDatabaseService", RegexOptions.IgnoreCase);                
    //        Match matches = regPid.Match(address);
    //        if (matches.Success)
    //        {
    //            return matches.Groups[1].ToString();
    //        }
    //        else
    //        {
    //            return "";
    //        }
    //    }
    //}
}
