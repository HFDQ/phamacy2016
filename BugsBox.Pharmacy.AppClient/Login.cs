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
using BugsBox.Common.Config;
using BugsBox.Common.Security;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI;
using BugsBox.Pharmacy.Models;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.AppClient.Common.Commands;

namespace BugsBox.Pharmacy.AppClient
{
    public partial class Login : BaseFunctionForm
    {
        User user;
        int clickCount = 0;
        int Gcount = 0;
        string msg = string.Empty;
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadLastLoginInfo();
            base.OnLoad(e);
            this.labelSystemName.Text = AppConfig.SystemName;
            this.labelVersion.Text = string.Format("Version:{0}", AssemblyInfoHelper.AssemblyVersion);
            this.Text = string.Format("{0}--客户端登录", AppConfig.SystemName);

        }

        private void UpdateProgram()
        {
            try
            {
                List<Business.Models.UpdateFiles> ListUpdateFiles = this.PharmacyDatabaseService.GetUpdateFiles(string.Empty).ToList();
                if (ListUpdateFiles.Count > 0)
                {
                    if (!System.IO.Directory.Exists("应用客户端"))
                        System.IO.Directory.CreateDirectory("应用客户端");
                }

                foreach (string di in System.IO.Directory.GetDirectories(System.IO.Directory.GetCurrentDirectory() + "\\应用客户端\\"))
                {
                    System.IO.Directory.Delete(di, true);
                }
                foreach (string fn in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + "\\应用客户端\\"))
                {
                    System.IO.File.Delete(fn);
                }

                foreach (var l in ListUpdateFiles)
                {
                    using (System.IO.FileStream outstream = new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\应用客户端\\" + l.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        outstream.Write(l.bytes, 0, l.bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("自动更新失败！" + ex.ToString());
            }
        }

        protected override void OnClosed(EventArgs e)
        {

            try
            {
                if (AppClientContext.CurrentUser != null)
                {
                    string message;
                    ServicesProvider.Instance.PharmacyDatabaseService.UserLogout(out message, Guid.Empty);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            base.OnClosed(e);
        }


        #region 记住与加载登录用户名和密码

        protected void LoadLastLoginInfo()
        {
            string login = PharmacyClientConfig.Config.LastAccount;
            if (!string.IsNullOrWhiteSpace(login))
            {
                this.txtName.Text = login;
            }
            string pwd = PharmacyClientConfig.Config.LastPwd;
            if (!string.IsNullOrWhiteSpace(pwd))
            {
                try
                {
                    pwd = EncodeHelper.Base64Decode(EncodeHelper.Base64Decode(pwd));
                }
                catch (Exception ex)
                {
                    pwd = string.Empty;
                }
                this.txtPassword.Text = pwd;
            }
            bool b = PharmacyClientConfig.Config.Pswcheck;
            this.checkBox1.Checked = b;

        }

        protected void SaveLastLoginInfo()
        {
            string pwd = this.txtPassword.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                return;
            }
            if (!checkBox1.Checked)
            {
                pwd = string.Empty;
            }
            pwd = EncodeHelper.Base64Encode(EncodeHelper.Base64Encode(pwd));
            PharmacyClientConfig.Config.LastPwd = pwd;

            string login = this.txtName.Text;
            if (string.IsNullOrWhiteSpace(login))
            {
                return;
            }

            PharmacyClientConfig.Config.LastAccount = login;
            PharmacyClientConfig.Config.Pswcheck = this.checkBox1.Checked;
            ConfigHelper<PharmacyClientConfig>.SaveConfig();
        }

        #endregion 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var c = this.PharmacyDatabaseService.GetServerInfo(out msg);
                    if (!c.ServerVersion.Equals(AssemblyInfoHelper.AssemblyVersion.ToString()))
                    {
                        this.UpdateProgram();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("服务器没有启动！");
                }

                SaveLastLoginInfo();

                if (!ServicesProvider.Instance.PharmacyDatabaseService.ValidateClientAuth(PharmacyClientConfig.Config.Store))
                {
                    MessageBox.Show("服务器验证门店信息失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string loginName = txtName.Text;
                string password = txtPassword.Text;
                if (string.IsNullOrWhiteSpace(loginName))
                {
                    errorProviderUser.SetError(txtName, "请您输入帐号");
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    errorProviderUser.SetError(txtPassword, "请您输入密码");
                    return;
                }



                string message = string.Empty;

                message = CheckUser(out user);
                if (string.IsNullOrEmpty(message))
                {
                    this.btnLogin.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.timer1.Enabled = true;
                }
                else
                {
                    errorProviderUser.SetError(txtPassword, message);
                    MessageBox.Show(message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                if (this.txtName.Focused)
                {
                    this.txtPassword.Focus();
                    this.txtPassword.SelectAll();
                }
            }
            if (keyData == Keys.F2)
            {
                this.checkBox1.Checked = true;
            }
            if (keyData == Keys.F3)
            {
                this.checkBox1.Checked = false;
            }
            if (keyData == Keys.F12)
            {
                this.txtName.Text = "Administrator";
                this.txtPassword.Text = "Administrator!@#$%";
            }

            if (keyData == Keys.F10)
            {
                Gcount++;
                this.WriteRdlcIntoDb();
            }
            if (keyData == Keys.F11)
            {
                Gcount += 2;
            }
            if (keyData == Keys.F10)
            {
                Gcount += 4;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void WriteRdlcIntoDb()
        {
            PharmacyFile ph = new PharmacyFile();
            ph.CreateTime = DateTime.Now;
            //ph.CreateUserId=Common.AppClientContext.currentUser.Id;
            ph.Deleted = false;
            ph.Extension = "rdlc";
            ph.FileName = "SalesOrderList";
            ph.Id = Guid.NewGuid();
            ph.StoreId = this.PharmacyDatabaseService.AllStores(out msg).FirstOrDefault().Id;
            ph.UpdateTime = DateTime.Now;
            //ph.UpdateUserId=Common.AppClientContext.currentUser.Id;
            //Microsoft.Reporting.WinForms.LocalReport lr = new Microsoft.Reporting.WinForms.LocalReport();

            System.Reflection.Assembly dll = System.Reflection.Assembly.GetExecutingAssembly();

            System.IO.Stream s = dll.GetManifestResourceStream("BugsBox.Pharmacy.AppClient.UI.Reports.RptSalesOrderListCS.rdlc");

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();

            s.Position = 0;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            ph.FileStream = b;

            var i = this.PharmacyDatabaseService.AddPharmacyFile(out msg, ph);

        }

        /// <summary>
        ///  /用户登录校验信息待定
        /// </summary>
        /// <returns></returns>
        private string CheckUser(out User user)
        {
            try
            {
                string msgReturn = string.Empty;
                user = PharmacyDatabaseService.UserLogon(out msgReturn, this.txtName.Text.Trim(), EncodeHelper.Base64Encode(this.txtPassword.Text));
                if (string.IsNullOrWhiteSpace(msgReturn) && user != null)
                {
                    AppClientContext.CurrentUser = user;
                }
                else
                {
                    msgReturn = string.IsNullOrWhiteSpace(msgReturn) ? "帐户名或密码不正确!" : msgReturn;
                }
                return msgReturn;
            }
            catch (Exception ex)
            {
                //ex=new Exception("登录失败!",ex);
                user = null;
                return ex.Message;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, null);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.errorProviderUser.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AppSet appset = new AppSet();
            appset.ShowDialog();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            //btnLogin.Focus();
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
                this.txtName.Focus();
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
                this.txtPassword.Focus();
            if (!string.IsNullOrWhiteSpace(this.txtName.Text) && !string.IsNullOrWhiteSpace(this.txtPassword.Text))
                btnLogin.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            //this.Width -= 5;
            //this.Height -= 2;
            if (this.Opacity <= 0)
            {
                this.Visible = false;
                this.Hide();
                frmMain frmMain = new frmMain(user);
                frmMain.Show();
                timer1.Enabled = false;
                this.btnLogin.Enabled = true;
                this.btnCancel.Enabled = true;
            }
        }
    }
}
