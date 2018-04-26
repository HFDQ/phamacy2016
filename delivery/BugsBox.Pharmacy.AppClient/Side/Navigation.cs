using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UserControls;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Common;

namespace BugsBox.Pharmacy.AppClient.Side
{
    public partial class Navigation : DockContent
    {
        private frmMain _formMain;

        public Navigation()
        {
            InitializeComponent();
        }


        public Navigation(frmMain formMain, string moduleCategory)
        {

            InitializeComponent();
            NavBar navBarMain = new NavBar(moduleCategory);
            navBarMain.Name = "navBarMain";
            navBarMain.Dock = DockStyle.Left;
            navBarMain.ImageButtonClick += new NavBar.ButtonClickHander(NavBar_ImageButtonClick);
            navBarMain.QuitSystemClick += new EventHandler(NavBar_QuitSystemClick);
            this.Controls.Add(navBarMain);
            _formMain = formMain;
            this.Width = 160;
        }

        /// <summary>
        /// 用户单击窗体左侧“导航栏”中按钮时的事件处理方法。
        /// </summary>
        private void NavBar_ImageButtonClick(object sender, UIForm targetModule)
        {

            try
            {
                Type type = Type.GetType(System.Configuration.ConfigurationManager.AppSettings["AppNameSpace"].ToString() + "." + targetModule.FormName);
                DockContent form = null;

                if (targetModule.FormParams != null && targetModule.FormParams.Count > 0)
                {
                    int arrSize = targetModule.FormParams.Count;
                    List<object> paramList = new List<object>();
                    for (int i = 0; i < arrSize; i++)
                        paramList.Add((object)targetModule.FormParams[i]);                     
                    form = (DockContent)Activator.CreateInstance(type,paramList.ToArray());
                }
                else
                    form = (DockContent)Activator.CreateInstance(type);

                if (targetModule.FormPosition.Length == 0)
                    _formMain.ShowForm(form);
                else
                {
                    switch (targetModule.FormPosition.ToLower())
                    {
                        case "left":
                            _formMain.ShowForm(form, DockState.DockLeft);
                            break;
                        case "right":
                            _formMain.ShowForm(form, DockState.DockRight);
                            break;
                        case "top":
                            _formMain.ShowForm(form, DockState.DockTop);
                            break;
                        case "bottom":
                            _formMain.ShowForm(form, DockState.DockBottom);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show("窗口启动失败！！！", "系统错误");
            }
        }

        /// <summary>
        /// 用户单击窗体左侧“导航栏”中“退出系统”导航条时的事件处理方法。
        /// </summary>
        private void NavBar_QuitSystemClick(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
