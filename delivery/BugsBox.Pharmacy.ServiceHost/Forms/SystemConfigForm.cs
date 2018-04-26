using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using BugsBox.Pharmacy.Services;
using BugsBox.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Config;
using BugsBox.Common.Config;
using BugsBox.Pharmacy.Repository;
using System.Data.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using Microsoft.Data.ConnectionUI;
using System.Configuration;
using System.Xml;
using System.Text.RegularExpressions;
 

namespace BugsBox.Pharmacy.ServiceHost.Forms
{
    /// <summary>
    /// 系统配置
    /// 常规配置
    /// 数据库类型配置
    /// 数据库连接字符串配置
    /// 要操作app.config文件以及Config目录中的相关信息
    /// 提供创建默认数据库以及表功能
    /// </summary>
    public partial class SystemConfigForm : UserControl
    {
        public SystemConfigForm()
        {
            InitializeComponent();
        }

         

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ok = ServiceContext.SetServiceHost(this.textBoxHost.Text.Trim());
                if (ok)
                {
                    MessageBox.Show("保存服务地址成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("保存服务地址失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(DesignMode)return; 
            bindConStr();
            BindStore();
        }

        private void bindConStr()
        {
            string[] str = GetConfigConStr();
            textBoxHost.Text = str[1];
            tbname.Text = str[2];
            tbid.Text = str[3];
            tbpw.Text = str[4];
            switch (str[0])
            {
                case "SqlClient":
                    radioButton1.Checked = true;
                    break;
                case "MySqlClient":
                    radioButton2.Checked = true;
                    break;
                case "Oracle":
                    radioButton3.Checked = true;
                    break;
            }
        }

        private string[] GetConfigConStr()
        {
            string[] result = new string[5] { "", "", "", "", "" };
            XmlDocument Doc = new XmlDocument();
            Doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            XmlNode node = Doc.SelectSingleNode("/configuration/connectionStrings/add[@name=\"Db\"]");
            string dbtype = node.Attributes["providerName"].Value;
            string constr = node.Attributes["connectionString"].Value;
            Regex regPid=new Regex("");
            Match matches;
            switch (dbtype)
            {
                case "System.Data.SqlClient":
                    result[0] = "SqlClient";
                    regPid = new Regex(@"Data Source=(.*);Initial Catalog=(.*);User ID=(.*);Password=(.*)", RegexOptions.IgnoreCase);
                    matches = regPid.Match(constr);
            if (matches.Success)
            {
                result[1] = matches.Groups[1].ToString();
                result[2] = matches.Groups[2].ToString();
                result[3] = matches.Groups[3].ToString();
                result[4] = matches.Groups[4].ToString();
            }
                    break;
                case "MySql.Data.MySqlClient":
                    result[0] = "MySqlClient";
                    regPid = new Regex(@"Datasource=(.*);Database=(.*);uid=(.*);pwd=(.*)", RegexOptions.IgnoreCase);
                    matches = regPid.Match(constr);
            if (matches.Success)
            {
                result[1] = matches.Groups[1].ToString();
                result[2] = matches.Groups[2].ToString();
                result[3] = matches.Groups[3].ToString();
                result[4] = matches.Groups[4].ToString();
            }
                    break;
                case "Oracle.DataAccess.Client":
                    result[0] = "Oracle";
                    regPid = new Regex(@"DATA SOURCE=(.*);PERSIST SECURITY INFO=True;USER ID=(.*);PASSWORD=(.*);", RegexOptions.IgnoreCase);
                    matches = regPid.Match(constr);
            if (matches.Success)
            {
                result[1] = matches.Groups[1].ToString();
                result[2] = "";
                result[3] = matches.Groups[2].ToString();
                result[4] = matches.Groups[3].ToString();
            }
                    break;
            }
            
            return result;
        }
        

        private void BindStore()
        {
            this.propertyGrid1.SelectedObject = PharmacyServiceConfig.Config.CurrentStore;
        }

        private void buttonSaveStore_Click(object sender, EventArgs e)
        {
            try
            {
                var store = propertyGrid1.SelectedObject as Store;
                if (store != null)
                {
                    PharmacyServiceConfig.Config.CurrentStore = store;
                    ConfigHelper<PharmacyServiceConfig>.SaveConfig();
                    Db db = null;
                    bool dbConntected = false;
                    try
                    {
                        db = new Db();
                        DbConnection connection = db.Database.Connection;
                        
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        dbConntected = connection.State == ConnectionState.Open;
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                        db = null;
                        dbConntected = false;
                    }
                    if (dbConntected)
                    {
                        db.Database.Connection.Close();
                        var dbStore = db.Stores.FirstOrDefault(s => s.Id == store.Id);
                        if (dbStore != null)
                        {
                            StoreBusinessHandler storeBusinessHandler = new StoreBusinessHandler(new RepositoryProvider(new Db()), null);
                            storeBusinessHandler.Save(store);
                            storeBusinessHandler.Save();
                            MessageBox.Show("保存配置成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            storeBusinessHandler.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("数据库中店配置有问题", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据库无法连接", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBoxConntection_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "", dataProvider = "";
            if (radioButton1.Checked)
            {
                dataProvider = "System.Data.SqlClient";
                constr = "Data Source=" + textBoxHost.Text + ";Initial Catalog=" + tbname.Text + ";User ID=" + tbid.Text + ";Password=" + tbpw.Text + "";
            }
            if (radioButton2.Checked)
            { dataProvider = "MySql.Data.MySqlClient";
            constr = "Datasource=" + textBoxHost.Text + ";Database=" + tbname.Text + ";uid=" + tbid.Text + ";pwd=" + tbpw.Text + "";
            }
            if (radioButton3.Checked)
            { dataProvider = "Oracle.DataAccess.Client";
            constr = "DATA SOURCE=" + textBoxHost.Text + ";PERSIST SECURITY INFO=True;USER ID=" + tbid.Text + ";PASSWORD=" + tbpw.Text + ";";
            }
            ConnectionStringSettings settings = null;
            settings = new ConnectionStringSettings("Db", constr, dataProvider);
            ServiceContext.SetConnectionStringSettings(settings);
            MessageBox.Show("保存成功");
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.Environment.Exit(0);
        }

        //private void textBoxConntection_DoubleClick(object sender, EventArgs e)
        //{
        //    DataConnectionDialog connDlg = new DataConnectionDialog();
        //    Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(connDlg);
        //    connDlg.SelectedDataSource = DataSource.SqlDataSource;
        //    connDlg.SelectedDataProvider = DataProvider.SqlDataProvider;
        //    connDlg.ConnectionString = this.textBoxConntection.Text;

        //    if (DataConnectionDialog.Show(connDlg, this) == DialogResult.OK)
        //    {
        //        this.textBoxConntection.Text = connDlg.ConnectionString;
        //        this.textBoxDataProvider.Text = connDlg.SelectedDataProvider.Name;
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ConnectionStringSettings settings = null; 
        //    settings = new ConnectionStringSettings("Db", this.textBoxConntection.Text, this.textBoxDataProvider.Text);
        //    ServiceContext.SetConnectionStringSettings(settings); 
        //}


    }
}
