using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;
using System.IO;
using System.Xml;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Application.Core;
using BugsBox.Common;
using System.Threading;
using BugsBox.Pharmacy.Models;
using Amib.Threading;

namespace BugsBox.Pharmacy.AppClient
{
    public partial class frmMain : Form    
    {
        string msg = string.Empty;   

        private bool m_bSaveLayout = true;
        public Menu menu;
        private DeserializeDockContent m_deserializeDockContent;
        public delegate void ShowFormForMenuHasState(DockContent form, DockState state);
        public delegate void ShowFormForMenu(DockContent form);
        List<Business.Models.QualityFilesWarningModel> ListWarningModel = null;

        readonly static SmartThreadPool smartThreadPool = new SmartThreadPool();
        
        //存放登陆用户信息
        private User _user = new User();
        
        public void ShowForm(DockContent form, DockState? state)
        {

            if (state != null)
            {
                ShowFormForMenuHasState sffm = new ShowFormForMenuHasState(ShowForm);
                sffm(form, (DockState)state);
            }
            else
            {
                ShowFormForMenu sffm = new ShowFormForMenu(ShowForm);
                sffm(form);
            }

            
        } 
        /// <summary>
        /// 设置Styles
        /// </summary>
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }

        public frmMain(User user)
        {
            InitializeComponent();
            
            _user = user;
            
            if (!DesignMode)
            {
                SetStyles();
                #region 通知事件处理

                ServicesProvider.Instance.PharmacyNotificationCallback.UserOnLined += PharmacyNotificationCallback_UserOnLined;

                #endregion 通知事件处理
            }
            try
            {
                m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载"+ex.Message,"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }

        void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(this.Text+"您确定关闭吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK; 
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
                        
            string configFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(configFile))
            {
                dcMainPanel.LoadFromXml(configFile, m_deserializeDockContent);
            }
            this.tssbUser.Text = string.Format("用户：{0},员工：{1},岗位：{2}", _user.Account, _user.Employee.Name, _user.Employee.Duty);
            this.ssMain.Items.Insert(1, new ToolStripSeparator());

            //获取分店方法待定？
            this.tssbSubCompany.Text = PharmacyClientConfig.Config.Store.Name;
            this.Text = string.Format("{0}--客户端", AppConfig.SystemName);
            // this.ssMain.Items.Insert(3, new ToolStripSeparator());
            this.tssbTime.Text = "当前时间： " + string.Format("{0:F}", DateTime.Now);
            //this.ssMain.Items.Insert(5, new ToolStripSeparator());
            // 获取版本号方法待定？
            this.tssbVersion.Text = string.Format("Version:{0}", AssemblyInfoHelper.AssemblyVersion);
            this.ssMain.Items.Insert(5, new ToolStripSeparator());
            ShowForm(new Welcome());
            
            dcMainPanel.Left = 20;

            #region 状态栏时间刷新
            //实例化Timer类，设置间隔时间为10000毫秒； 
            System.Timers.Timer tCurrTime = new System.Timers.Timer(1000);
            tCurrTime.Elapsed += new System.Timers.ElapsedEventHandler(tCurrTime_Tick);
            tCurrTime.AutoReset = true;
            tCurrTime.Enabled = true;
            #endregion.

            //固定左边导航栏的宽度为240适应不同的分辨率
            if (Screen.PrimaryScreen.Bounds.Width > 0)
                dcMainPanel.DockLeftPortion = Math.Round(240 / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width), 2);
            menu = new Menu(this);
            ShowForm(menu, DockState.DockLeft);
            //固定右边导航栏的宽度为200适应不同的分辨率
            if (Screen.PrimaryScreen.Bounds.Width > 0)
                dcMainPanel.DockRightPortion = Math.Round(200 / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width), 2);
            ShowForm(new Side.Warn(), DockState.DockRight);

            LoadMainMenu(msMain);

            #region 预警资质
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval=40,
                 Enabled=true
            };
            timer.Tick += (s, ex) =>
            {
                
                this.linkLabel5.Left = this.linkLabel5.Left >= this.panel1.Width ? -this.linkLabel5.Width-this.linkLabel1.Width-10 : this.linkLabel5.Left + 1;
                this.linkLabel1.Left = this.linkLabel5.Left+this.linkLabel5.Width + 10;
            };

            this.linkLabel5.MouseEnter += (s, ex) =>
            {
                timer.Enabled = false;
            };
            this.linkLabel1.MouseEnter += (s, ex) =>
            {
                timer.Enabled = false;
            };
            this.linkLabel1.MouseLeave += (s, ex) =>
            {
                timer.Enabled = true;
            };
            this.linkLabel5.MouseLeave += (s, ex) =>
            {
                timer.Enabled = true;
            };

            this.GetWarningData();

            this.linkLabel5.DoubleClick += (s, ex) =>
            {
                if (this.ListWarningModel == null)
                {
                    MessageBox.Show("无预警信息！"); return;
                }
                UI.Forms.BaseDataManage.Form_WarningListShow frm = new UI.Forms.BaseDataManage.Form_WarningListShow(this.ListWarningModel);
                {
                    frm.Show(this);
                    frm.WarningSetupChanged += frm_WarningSetupChanged;
                }
            };
            this.linkLabel1.Click += linkLabel1_Click;
            #endregion
        }
        //查看近效期库存品种
        void linkLabel1_Click(object sender, EventArgs e)
        {
            UI.Forms.DrugMaintain.SignDrugAsSpecial frm = new UI.Forms.DrugMaintain.SignDrugAsSpecial();
            frm.ShowDialog();
            
        }

        void frm_WarningSetupChanged()
        {
            this.GetWarningData();
        }

        /// <summary>
        /// 获取查询预警信息
        /// </summary>
        private void GetWarningData()
        {
            using (BugsBox.Pharmacy.UI.Common.BaseFunctionUserControl bc = new Pharmacy.UI.Common.BaseFunctionUserControl())
            {
                var c = bc.PharmacyDatabaseService.GetQualifyFilesCount(UI.SerialFile.csf.o, out msg);
                this.ListWarningModel = c;
                int SupplyQualityFiles = c.Where(r => r.QualityFileWarningTypeValue == (int)Business.Models.QualityFileWarningType.供货单位).Count();
                int PurchaseQualityFiles = c.Where(r => r.QualityFileWarningTypeValue == (int)Business.Models.QualityFileWarningType.客户单位).Count();
                int DrugQualityFiles=c.Where(r => r.QualityFileWarningTypeValue == (int)Business.Models.QualityFileWarningType.品种许可有效期).Count();
                
                this.linkLabel5.Text = string.Format("预警信息：有{0}个供货单位,{1}客户单位,{2}个品种资质即将到期！双击查看", SupplyQualityFiles,PurchaseQualityFiles,DrugQualityFiles);

                int DrugInventoryNear=c.Where(r=>r.QualityFileWarningTypeValue == (int)Business.Models.QualityFileWarningType.库存品种近效期).Count();
                this.linkLabel1.Text = string.Format("库存品种预警信息：{0}个品种即将到期！", DrugInventoryNear);
                this.linkLabel1.Left = this.linkLabel5.Left + this.linkLabel5.Width + 2;
                
            }
        }

        void PharmacyNotificationCallback_UserOnLined(object sender, EventArgs<User> e)
        {
            try
            {

                this.tssbBlank.Text = string.Format("员工[{0}]以[{1}]用户上线.", e.Value.Employee.Name,e.Value.Account);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
           
        }

        /// <summary>
        /// 状态栏时间刷新
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void tCurrTime_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                smartThreadPool
                    .QueueWorkItem(
                    () =>{ 
                            this.tssbTime.Text = "当前时间： " + string.Format("{0:F}", DateTime.Now); 
                         }
                    );//线程通知
               
            }
            catch (Exception ex)
            {
                // 该Error 记录log
            }
        }

        #region 显示窗体

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="form"></param>
        /// <param name="state"></param>
        public void ShowForm(DockContent form)
        {
            try
            {
                DockContent hasDockContent = FindDocument(form.Text);
                if (hasDockContent == null)
                    form.Show(dcMainPanel);
                else
                    hasDockContent.Show(dcMainPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载"+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="form"></param>
        /// <param name="state"></param>
        public void ShowForm(DockContent form, DockState state)
        {
            try
            {
                DockContent hasDockContent = FindDocument(form.Text);
                if (hasDockContent != null)
                {
                    hasDockContent.Show(dcMainPanel, state);
                }
                else
                {
                    form.Show(dcMainPanel, state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载"+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DockContent FindDocument(string text)
        {
            if (dcMainPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form m = MdiChildren.Where(p => p.Text.Equals(text)).FirstOrDefault();

                return m == null ? null : m as DockContent;
            }
            else
            {
                foreach (DockContent content in dcMainPanel.Contents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        return content;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="form"></param>
        private void CloseForm(DockContent form)
        {
            DockContent hasDockContent = FindDocument(form.Text);
            if (hasDockContent != null)
                hasDockContent.Hide();
        }

        #endregion

        private IDockContent GetContentFromPersistString(string persistString)
        {
            return null;
        }

        /// <summary>
        ///  exit click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体关闭"+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string msg = string.Empty;
            
            var c =new BugsBox.Pharmacy.AppClient.UI.BaseFunctionForm().PharmacyDatabaseService.GetServerInfo(out msg);
            if (!c.ServerVersion.Equals(AssemblyInfoHelper.AssemblyVersion.ToString()))
            {
                MessageBox.Show("您当前版本号为：" + AssemblyInfoHelper.AssemblyVersion.ToString()+"\r\n"+"请稍候，系统将更新到最新版本："+c.ServerVersion);
                (new BugsBox.Pharmacy.AppClient.UI.BaseFunctionForm()).PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行系统升级操作，版本号：" + c.ServerVersion);
                System.Diagnostics.Process.Start("UpdateBugBox.exe");
            }
            //关闭
            string configFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dcMainPanel.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);
            ServicesProvider.Instance.DisconnectServer();
            
            smartThreadPool.Shutdown();
            System.Windows.Forms.Application.Exit();

        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                menu.ExpandNode = tsmi.Tag.ToString();
                //DockContent hasDockContent = FindDocument(NAVIGATION);
                //if (hasDockContent != null)
                //    hasDockContent.Close();
                //ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                //string moduleCaption = string.Empty;
                //if (tsmi.Tag == null)
                //{
                //    MessageBox.Show("菜单的Tag属性不能为空！！！", "窗体加载", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //moduleCaption = tsmi.Tag.ToString();
                //ShowForm(new Side.Navigation(this, moduleCaption), DockState.DockLeft);
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载"+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadMainMenu(MenuStrip menuStrip)
        {
            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["Menu"].ToString()))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Configuration.ConfigurationManager.AppSettings["Menu"].ToString());

                foreach (XmlNode node in doc.SelectNodes("/MenusGroup/Menu")[0].ChildNodes)
                {
                    if (CheckHasPermission(node))
                    {
                        ToolStripMenuItem toolItem = new ToolStripMenuItem();
                        toolItem.Name = "tsmi" + node.Attributes["id"].Value;
                        //获取属性TITLE值
                        string text = node.Attributes["Title"].Value;
                        string hotKeys = string.Empty;
                        if (node.Attributes["Hotkeys"].Value != null)
                            hotKeys = node.Attributes["Hotkeys"].Value;
                        if (hotKeys.Length > 0)
                            text = text + "(&" + hotKeys + ")";
                        toolItem.Text = text;
                        toolItem.Tag = node.Attributes["id"].Value;

                        //动态添加一项菜单
                        menuStrip.Items.Add(toolItem);
                        toolItem.Click += new EventHandler(ToolStripMenuItem_Click);
                    }
                }

                ////读取XML配置文件
                //XmlTextReader xmlReader = new XmlTextReader(MENU_PATH);
                //while (xmlReader.Read())
                //{
                //    //判断是否循环到MainMenu节点
                //    if (!xmlReader.IsEmptyElement && xmlReader.Name == "MenuType")
                //    {
                //        if (xmlReader.HasAttributes)
                //        {
                //            //创建一级菜单项
                //            ToolStripMenuItem toolItem = new ToolStripMenuItem();
                //            //获取属性ID值
                //            string id = xmlReader.GetAttribute("id");
                //            toolItem.Name = "tsmi" + id;
                //            //获取属性TITLE值
                //            string text = xmlReader.GetAttribute("title");
                //            string hotKeys = string.Empty;
                //            if (xmlReader.GetAttribute("Hotkeys") != null)
                //                hotKeys = xmlReader.GetAttribute("Hotkeys");
                //            if (hotKeys.Length > 0)
                //                text = text + "(&" + hotKeys + ")";
                //            toolItem.Text = text;
                //            toolItem.Tag = id.ToString();
                //            if (text != null && text.Length > 1)
                //            {
                //                //动态添加一项菜单
                //                menuStrip.Items.Add(toolItem);
                //                toolItem.Click += new EventHandler(ToolStripMenuItem_Click);
                //            }
                //        }
                //    }
                //}
            }
        }

        public bool CheckHasPermission(XmlNode node)
        {
            bool result = false;
            if (this.Authorize(node.Attributes["ModuleKey"].Value))
                return true;

            foreach (XmlNode son in node.ChildNodes)
            {
                if (CheckHasPermission(son))
                {
                    return true;
                }
            }
            return result;
        }

        private void tsmkLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ToolStripMenuItemLogout_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //login.ShowDialog();
            //this.Hide();
            if (MessageBox.Show("您确定要注销登录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //isRestart = true;
                System.Windows.Forms.Application.ExitThread();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 更新报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Pharmacy.UI.Common.BaseFunctionUserControl uc = new Pharmacy.UI.Common.BaseFunctionUserControl())
            {
                var ListUpdateFiles = uc.PharmacyDatabaseService.GetUpdateFiles("Reports").ToList();
                if (ListUpdateFiles.Count > 0)
                {
                    if (System.IO.Directory.Exists("Reports"))
                        System.IO.Directory.Delete("Reports",true);
                }
                
                {
                 //   if (!System.IO.Directory.Exists("Reports"))
                        System.IO.Directory.CreateDirectory("Reports");
                }

                foreach (var l in ListUpdateFiles)
                {
                    using (System.IO.FileStream outstream = new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\Reports\\" + l.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
                    {
                        outstream.Write(l.bytes, 0, l.bytes.Length);
                    }
                }
                MessageBox.Show("更新成功！");
            }
        }

    }
}
