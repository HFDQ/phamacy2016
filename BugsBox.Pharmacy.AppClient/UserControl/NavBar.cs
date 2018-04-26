﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.Properties;


namespace BugsBox.Pharmacy.AppClient.UserControls
{
    /// <summary>
    /// 对象名称：导航栏类
    /// 对象说明：主要显示系统左侧的导航栏。
    /// </summary>
    public partial class NavBar : UserControl
    {
        /// <summary>
        /// 导航栏类的默认实例化方法，该方法在控件正式显示之前执行，
        /// 可以根据需要在此方法中对 NavButtonGroup列表进行重新定义。
        /// </summary>

        private string _moduleCategory="";
        public string ModuleCategory 
        {  get { return _moduleCategory; }
            set { _moduleCategory = value; }
        }

        public NavBar()
        {
            InitializeComponent();
            InitButtonGroup();
            // 初始化导航栏，该方法必须在NavButtonGroup重新调整后执行
            InitNavBar(); 
        }


        public NavBar(string modulecategory)
        {
            InitializeComponent();
            _moduleCategory = modulecategory;
            InitButtonGroup();
            // 初始化导航栏，该方法必须在NavButtonGroup重新调整后执行
            InitNavBar();
        }

        /// <summary>
        /// 说明：导航栏初始的功能模块列表，可以通过定义此列表设置导航栏中的导航条及图片按扭。
        /// 注意：这里定义的是一个私有的List类型变量NavButtonGroup，并不是一个私有的函数方法。
        /// </summary>
        private List<NavBar.ButtonGroup> _navButtonGroup = new List<NavBar.ButtonGroup>();

        private  void InitButtonGroup()
        {


            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["Menu"].ToString()))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Configuration.ConfigurationManager.AppSettings["Menu"].ToString()); 
                XmlNode mainNodes = doc.DocumentElement.SelectSingleNode("//MenusGroup//MenuType[@id='"+_moduleCategory+"']");
                foreach (XmlNode nodes in mainNodes.ChildNodes)
                {
                    //获取属性ID值
                    if (nodes.Attributes.Count>0)
                    {
                        ButtonGroup btGroups= new ButtonGroup(nodes.Attributes["title"].Value.ToString());
                        foreach (XmlNode node in nodes.ChildNodes)
                        {
                            if (node.Attributes.Count > 0) 
                            {
                               string title = node["Title"].InnerText;
                               string formName =node["Name"].InnerText;
                               UIForm targetForm = new UIForm();
                               Image  image = (Image)Resources.ResourceManager.GetObject(node["Image"].InnerText);
                               string formPosition = string.Empty;
                               if(node["Position"]!=null)
                                    formPosition = node["Position"].InnerText;
                               List<string> listParams = new List<string>();
                               if (node["Params"] != null) 
                               {
                                   string strParams = node["Params"].InnerText;
                                   if (strParams.IndexOf(",") >= 0)
                                       listParams = strParams.Split(new char[1] { ',' }).ToList();
                                   else
                                       listParams.Add(strParams);
                               }
                               targetForm.FormName = formName;
                               targetForm.FormPosition = formPosition;
                               targetForm.FormParams = listParams; ;

                               ImageButton ImageButton = new ImageButton(title, targetForm,image);

                               btGroups.ImageButtons.Add(ImageButton);
                            }

                        }
                        _navButtonGroup.Add(btGroups);
                    }
                }
            }
           
        }
    

        #region 导航栏类中的相关属性与方法

        public delegate void ButtonClickHander(object sender, UIForm targetModule);
        public event EventHandler QuitSystemClick;
        public event ButtonClickHander ImageButtonClick;

        /// <summary>
        /// 初始化导航栏
        /// </summary>
        private void InitNavBar()
        {
            this.Dock = DockStyle.Fill;
            int barHeight = 22;
            for (int n = 0; n < _navButtonGroup.Count; n++)
            {
                ButtonGroup buttonGroup = _navButtonGroup[n];
                buttonGroup.Left = 2;
                buttonGroup.Tag = n;
                buttonGroup.TitleBarClick += new EventHandler(TitleBar_Click);
                buttonGroup.ImageButtonClick += new ButtonClickHander(ImageButton_Click);
                buttonGroup.InitImageButtons();
                PnlBackGround.Controls.Add(buttonGroup);
            }
            PnlBottomLine.Top = PnlBackGround.Height - (_navButtonGroup.Count - CurrentGroupIndex - 1) * barHeight;
            ResetNavBar();
        }


        /// <summary>
        /// 重新设置导航栏的布局。
        /// </summary>
        private void ResetNavBar()
        {
            int barHeight = 22;
            for (int n = 0; n < _navButtonGroup.Count; n++)
            {
                ButtonGroup buttonGroup = _navButtonGroup[n];
                if (n <= CurrentGroupIndex)
                {
                    buttonGroup.Top = 1 + n * barHeight;
                }
                else
                {
                    buttonGroup.Top = PnlBackGround.Height - (_navButtonGroup.Count - n) * barHeight;
                }
                if (n == CurrentGroupIndex)
                {
                    buttonGroup.Height = PnlBackGround.Height - (_navButtonGroup.Count - 1) * barHeight;
                }
                else
                {
                    buttonGroup.Height = barHeight;
                }
            }
            PnlBottomLine.Top = PnlBackGround.Height - (_navButtonGroup.Count - CurrentGroupIndex - 1) * barHeight - 1;
        }


        /// <summary>
        /// 导航条大小发生变更时，重新设置导航条的布局。
        /// </summary>
        private void NavBar_SizeChanged(object sender, EventArgs e)
        {
            ResetNavBar();
        }


        /// <summary>
        /// 当前导航栏中选中的导航条编号
        /// </summary>
        private int CurrentGroupIndex = 0;


        /// <summary>
        /// 导航栏中的导航条单击事件处理
        /// </summary>
        private void TitleBar_Click(object sender, EventArgs e)
        {
            if (sender is ButtonGroup)
            {
                ButtonGroup buttonGroup = (ButtonGroup)sender;
                if (buttonGroup.Text == "退出系统")
                {
                    if (QuitSystemClick != null)
                    {
                        QuitSystemClick(buttonGroup, e);
                    }
                    return;
                }
                CurrentGroupIndex = (int)buttonGroup.Tag;
                ResetNavBar();
            }
        }


        /// <summary>
        /// 导航栏中的图片按钮单击事件处理
        /// </summary>
        private void ImageButton_Click(object sender, UIForm targetModule)
        {
            if (ImageButtonClick != null)
            {
                ImageButtonClick(sender, targetModule);
            }
        }

        #endregion

        #region 导航栏类中所定义使用的对象

        /// <summary>
        /// 导航栏中的导航条
        /// </summary>
        public class ButtonGroup : UserControl
        {
            public event EventHandler TitleBarClick;
            public event ButtonClickHander ImageButtonClick;

            public ButtonGroup(string text)
            {
                Text = text;
                InitializeControl();
            }

            /// <summary>
            /// 初始化导航条
            /// </summary>
            private void InitializeControl()
            {
                //
                // 导航条上的标题栏
                //
                TitleBar.Cursor = Cursors.Hand;
                TitleBar.TextAlign = ContentAlignment.MiddleLeft;
                TitleBar.ForeColor = Color.FromArgb(102, 102, 102);
                TitleBar.Location = new Point(0, 0);
                TitleBar.Size = new Size(153, 22);
                TitleBar.BackgroundImage = Resources.NavBarBG01;
                TitleBar.MouseMove += new MouseEventHandler(TitleBar_MouseMove);
                TitleBar.MouseLeave += new EventHandler(TitleBar_MouseLeave);
                TitleBar.Click += new EventHandler(TitleBar_Click);
                //
                //ButtonGroup导航条 
                //
                Width = 153;
                Height = 22;
                this.Controls.Add(TitleBar);
                this.Controls.Add(ButtonArea);
            }

            /// <summary>
            /// 初始化导航条所包含或关联的图片按钮
            /// </summary>
            public void InitImageButtons()
            {
                int imageButtonHeight = 30;
                //
                // 导航条上的按钮区域（Panel)
                //
                ButtonArea.Location = new Point(0, 22);
                ButtonArea.Size = new Size(153, imageButtonHeight * ImageButtons.Count);
                //
                // 导航条上的图片按钮
                //
                for (int n = 0; n < ImageButtons.Count; n++)
                {
                    ImageButton imageButton = ImageButtons[n];
                    imageButton.Left = 0;
                    imageButton.Top = n * imageButtonHeight;
                    imageButton.ImageButtonClick += new ButtonClickHander(ImageButton_Click);
                    ButtonArea.Controls.Add(imageButton);
                }
            }

            private System.Windows.Forms.Label TitleBar = new System.Windows.Forms.Label();
            private Panel ButtonArea = new Panel();

            /// <summary>
            /// 导航条上的标题栏的文字
            /// </summary>
            public new String Text
            {
                get
                {
                    return TitleBar.Text;
                }
                set
                {
                    TitleBar.Text = value;
                }
            }

            private List<ImageButton> _ImageButtons = new List<ImageButton>();

            /// <summary>
            /// 导航条所包含或关联的图片按钮
            /// </summary>
            public List<ImageButton> ImageButtons
            {
                get { return _ImageButtons; }
                set
                {
                    _ImageButtons = value;
                }
            }

            /// <summary>
            /// 鼠标从导航条上的标题上移开时事件处理
            /// </summary>
            private void TitleBar_MouseLeave(object sender, EventArgs e)
            {
                if (sender is System.Windows.Forms.Label)
                {
                    System.Windows.Forms.Label tmpLabel = (System.Windows.Forms.Label)sender;
                    tmpLabel.BackgroundImage = Resources.NavBarBG01;
                }
            }

            /// <summary>
            /// 鼠标移动到导航条上的标题上时事件处理
            /// </summary>
            private void TitleBar_MouseMove(object sender, MouseEventArgs e)
            {
                if (sender is System.Windows.Forms.Label)
                {
                    System.Windows.Forms.Label tmpLabel = (System.Windows.Forms.Label)sender;
                    tmpLabel.BackgroundImage = Resources.NavBarBG02;
                }
            }

            /// <summary>
            /// 单击导航条上的标题事件处理
            /// </summary>
            private void TitleBar_Click(object sender, EventArgs e)
            {
                if (TitleBarClick != null)
                {
                    TitleBarClick(this, e);
                }
            }

            /// <summary>
            /// 单击图片按钮事件处理
            /// </summary>
            private void ImageButton_Click(object sender, UIForm targetModule)
            {
                if (ImageButtonClick != null)
                {
                    ImageButtonClick(sender, targetModule);
                }
            }
        }


        /// <summary>
        /// 导航栏中的图片按钮
        /// </summary>
        public class ImageButton : UserControl
        {
            public event ButtonClickHander ImageButtonClick;

            public ImageButton(string text, UIForm targetModule, Image image)
            {
                this.Text = " "+text;
                this.TargetModule = targetModule;
                this.Image = image;
                InitializeControl();
            }

            /// <summary>
            /// 初始化图片按钮
            /// </summary>
            private void InitializeControl()
            {
                //
                // 图像按钮上的图像
                //
                //ButtonImage.Cursor = Cursors.Hand;
                ButtonImage.Location = new Point(0, 12);
                ButtonImage.Size = new Size(10, 10);
                //ButtonImage.MouseMove += new MouseEventHandler(ButtonImage_MouseMove);
                //ButtonImage.MouseLeave += new EventHandler(ButtonImage_MouseLeave);
                //ButtonImage.Click += new EventHandler(ButtonImage_Click);
                //
                // 图像按钮上的文字
                //
                ButtonText.Cursor = Cursors.Hand;
                ButtonText.TextAlign = ContentAlignment.MiddleLeft;
                ButtonText.ForeColor = Color.FromArgb(68, 68, 68);
                ButtonText.Location = new Point(0, 0);
                ButtonText.Size = new Size(400, 30);
                ButtonText.MouseMove += new MouseEventHandler(ButtonImage_MouseMove);
                ButtonText.MouseLeave += new EventHandler(ButtonImage_MouseLeave);
                ButtonText.Click += new EventHandler(ButtonImage_Click);
                //
                //ImageButton图像按钮 
                //
                Width = 153;
                Height = 30;
                this.Controls.Add(ButtonText);
                //this.Controls.Add(ButtonImage);
            }


            /// <summary>
            /// 鼠标从图片按钮上移开时事件处理
            /// </summary>
            private void ButtonImage_MouseLeave(object sender, EventArgs e)
            {
                //if (sender is PictureBox)
                //{
                //    PictureBox tmpPictureBox = (PictureBox)sender;
                //    tmpPictureBox.BackgroundImage = null;
                //}
                (sender as Control).BackgroundImage = null;
                //(sender as Control).Text = "◆ " + (sender as Control).Text.Substring(2,(sender as Control).Text.Length-2);
            }

            /// <summary>
            /// 鼠标移动到图片按钮上时事件处理
            /// </summary>
            private void ButtonImage_MouseMove(object sender, MouseEventArgs e)
            {
                //if (sender is PictureBox)
                //{
                //    PictureBox tmpPictureBox = (PictureBox)sender;
                //    tmpPictureBox.BackgroundImage = Resources.NavBtnBG;
                //}
                (sender as Control).BackgroundImage = Resources.NavBarBG02;
            }

            /// <summary>
            /// 图片按钮单击事件处理
            /// </summary>
            private void ButtonImage_Click(object sender, EventArgs e)
            {
                if (ImageButtonClick != null)
                {
                    ImageButtonClick(this, this.TargetModule);
                }
            }

            private System.Windows.Forms.Label ButtonText = new System.Windows.Forms.Label();
            private PictureBox ButtonImage = new PictureBox();

            /// <summary>
            /// 图片按钮中图片下方的文字
            /// </summary>
            public new string Text
            {
                get { return ButtonText.Text; }
                set { ButtonText.Text = value; }
            }

            /// <summary>
            /// 图片按钮中显示的图片
            /// </summary>
            public Image Image
            {
                get { return ButtonImage.Image; }
                set { ButtonImage.Image = value; }
            }

            /// <summary>
            /// 用户点击图片按钮后，期望转向的模块名称
            /// </summary>
            public UIForm TargetModule
            {
                get;
                set;
            }

        }

        #endregion
    }
}
