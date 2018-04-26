using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using BugsBox.Common.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace BugsBox.Windows.Controls
{
    [ProvideProperty("DataName", typeof(Control))
    , ProvideProperty("DataType", typeof(Control))
    , ProvideProperty("AllowNullOrEmpty", typeof(Control))
    , ProvideProperty("MinLength", typeof(Control))
    , ProvideProperty("MaxLength", typeof(Control))
    , ProvideProperty("Regex", typeof(Control))
    , ProvideProperty("DataDescription", typeof(Control))
    ,ProvideProperty("Precision", typeof(Control))
    ]
    public class ValidatorProvider : Component, IExtenderProvider, ISupportInitialize
    {
        private const string ValidatorCategoryName = "BugsboxValidator";

        #region  IExtenderProvider

        bool IExtenderProvider.CanExtend(object extendee)
        {
            return extendee is TextBox 
                //|| extendee is CheckedListBox 
                //|| extendee is ComboBox 
                //|| extendee is ListBox
                ;
        }
        #endregion



        #region ISupportInitialize

        public void BeginInit()
        {

        }

        public void EndInit()
        {

        }

        #endregion

        private IContainer components;
        #region ValidatorProvider Init And Dispose

        public ValidatorProvider()
        {
            this.InitializeComponent();
            InitBalloon();
        }

        public ValidatorProvider(IContainer container)
            : this()
        {

            container.Add(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            if (balloon.Showed)
            {
                balloon.Hide();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.items = new Dictionary<Control, ValidatorItemInfo>();
            this.itemsBackColor = new Dictionary<Control, Color>();
            this.components = new Container();
        }

        #endregion

        private Dictionary<Control, ValidatorItemInfo> items;
        private Dictionary<Control, Color> itemsBackColor;

        private ValidatorItemInfo EnsureControlItem(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            ValidatorItemInfo item = null;
            if (!this.items.ContainsKey(control))
            {
                item = new ValidatorItemInfo(this, control);
                itemsBackColor.Add(control, control.BackColor);
                InitValidate(item);
                this.items.Add(control, item);
            }
            item = this.items[control];
            return item;
        }

        private void InitValidate(ValidatorItemInfo itemInfo)
        {
            itemInfo.Control.Validating += new CancelEventHandler(Control_Validating);
            itemInfo.Control.Validated += new EventHandler(Control_Validated);
            itemInfo.Control.LostFocus += new EventHandler(Control_LostFocus);
            itemInfo.Control.TextChanged += new EventHandler(Control_TextChanged);
        }

        void Control_TextChanged(object sender, EventArgs e)
        {
            if (balloon.Showed)
                balloon.Hide();
        }

        void Control_LostFocus(object sender, EventArgs e)
        {
           
        }

        void Control_Validated(object sender, EventArgs e)
        {
            Control control = sender as Control;
            SetOKBackColor(control);
        }

        void Control_Validating(object sender, CancelEventArgs e)
        {
            Control control = sender as Control;
            ValidatorItemInfo item = this.items[control];
            if (item.DataType == DataType.未设)
                return;
            //如果不允许为空
            if (!item.AllowNullOrEmpty)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    SetErrorBackColor(control);
                    ShowError(control, string.Format("[{0}]不可为空，请您输入[{0}]!", item.DataName), string.Format("验证[{0}]", item.DataName));
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    return;
                }
            }
                //正则表达式
            {    Regex regex=item.GetRegex();
                if (regex != null)
                {
                    bool match = regex.IsMatch(control.Text);
                    if (!match)
                    {
                        ShowError(control, string.Format("[{0}]格式不对，请您输入正确的[{0}]!\r\n{1}", item.DataName, item.DataDescription), string.Format("验证[{0}]格式", item.DataName));
                    }
                    e.Cancel = !match;
                    return;
                }
                if (regex == null)
                {
                    bool validated = ValidateLength(item, control.Text);
                    if (!validated)
                    {
                        ShowError(control, string.Format("您输入的[{0}]长度不对，请您输入正确长度的[{0}]!\r\n{1}", item.DataName, item.DataDescription), string.Format("验证[{0}]格式", item.DataName));
                        e.Cancel = true;
                        return;
                    }
                    //整数,
                    //正整数,
                    //负整数,
                    //非正整数,
                    //非负整数,
                    //浮点数,
                    //正浮点数,
                    //负浮点数,
                    //非正浮点数,
                    //非负浮点数,
                    //中国华人民共和国身份证,
                    //中国华人民共和国邮编,
                    //汉字,
                    //大写字母,
                    //小写字母,
                    //字母,
                    //数字,
                    //字母数字,
                    //大写字母数字,
                    //小写字母数字,
                    //日期,
                    //日期时间,
                    //时间,
                    //字符串,
                    if (item.DataType == DataType.整数
                        || item.DataType == DataType.正整数
                        || item.DataType == DataType.负整数
                        || item.DataType == DataType.非正整数
                        || item.DataType == DataType.非负整数
                        || item.DataType == DataType.中国华人民共和国身份证
                        || item.DataType == DataType.中国华人民共和国邮编
                        || item.DataType == DataType.汉字
                        || item.DataType == DataType.大写字母
                        || item.DataType == DataType.小写字母
                        || item.DataType == DataType.字母
                        || item.DataType == DataType.数字
                        || item.DataType == DataType.字母数字
                        || item.DataType == DataType.大写字母数字
                        || item.DataType == DataType.日期
                        || item.DataType == DataType.日期时间
                        || item.DataType == DataType.时间
                        )
                    {
                        //数据格式
                        validated = false;
                        validated = DataRegex.Instance[item.DataType].IsMatch(control.Text);
                        if (!validated)
                        {
                            ShowError(control, string.Format("[{0}]格式不对，请您输入正确的[{0}]!\r\n{1}", item.DataName, item.DataDescription), string.Format("验证[{0}]格式", item.DataName));
                            e.Cancel = true;
                            return;
                        }
                    }
                }
 
            }            
            balloon.Hide();
        }

        private bool ValidateLength(ValidatorItemInfo item,string value)
        {
            if (item.MaxLength < 1 && item.MinLength < 1 || item.MaxLength < item.MinLength)
                return true;
            if(item.MaxLength==item.MinLength)
            {
                return value.Length == item.MinLength;
            }
            if (item.MaxLength > 0 && item.MinLength<1)
            {
                return value.Length <= item.MaxLength;
            }
            if (item.MinLength > 0 && item.MaxLength <1)
            {
                return value.Length >= item.MaxLength;
            }
            return value.Length <= item.MaxLength && value.Length >= item.MinLength;
            
        }

        private void SetOKBackColor(Control control)
        {
            if (control != null && this.itemsBackColor.ContainsKey(control))
            {
                control.BackColor = this.itemsBackColor[control];
            }
        }

        private void SetErrorBackColor(Control control)
        {
            if (control != null && this.itemsBackColor.ContainsKey(control))
            {
                control.BackColor = errorControlBackColor;
            }
        }


        #region  对外属性


        [Category(ValidatorCategoryName)]
        [DisplayName("DataName")]
        [Description("获取或设置数据项名称")]
        public string GetDataName(Control control)
        {
            return this.EnsureControlItem(control).DataName;
        }


        public void SetDataName(Control c, string value)
        {
            this.EnsureControlItem(c).DataName = value;

        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置数据类型")]
        [DisplayName("DataType")]
        public DataType GetDataType(Control control)
        {
            return this.EnsureControlItem(control).DataType;
        }


        public void SetDataType(Control c, DataType value)
        {
            this.EnsureControlItem(c).DataType = value;

        }


        [Category(ValidatorCategoryName)]
        [Description("获取或设置AllowNullOrEmpty")]
        [DisplayName("AllowNullOrEmpty")]
        public bool GetAllowNullOrEmpty(Control control)
        {
            return this.EnsureControlItem(control).AllowNullOrEmpty;
        }


        public void SetAllowNullOrEmpty(Control c, bool value)
        {
            this.EnsureControlItem(c).AllowNullOrEmpty = value;
        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置MinLength")]
        [DisplayName("MinLength")]
        public int GetMinLength(Control control)
        {
            return this.EnsureControlItem(control).MinLength;
        }


        public void SetMinLength(Control c, int value)
        {
            this.EnsureControlItem(c).MinLength = value;
        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置MaxLength")]
        [DisplayName("MaxLength")]
        public int GetMaxLength(Control control)
        {
            return this.EnsureControlItem(control).MaxLength;
        }


        public void SetMaxLength(Control c, int value)
        {
            this.EnsureControlItem(c).MaxLength = value;
        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置Regex")]
        [DisplayName("Regex")]
        public string GetRegex(Control control)
        {
            return this.EnsureControlItem(control).Regex;
        }


        public void SetRegex(Control c, string value)
        {
            this.EnsureControlItem(c).Regex = value;
        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置DataDescription")]
        [DisplayName("DataDescription")]
        public string GetDataDescription(Control control)
        {
            return this.EnsureControlItem(control).DataDescription;
        }


        public void SetDataDescription(Control c, string value)
        {
            this.EnsureControlItem(c).DataDescription = value;
        }

        [Category(ValidatorCategoryName)]
        [Description("获取或设置数值精度")]
        [DisplayName("Precision")]
        public int GetPrecision(Control control)
        {
            return this.EnsureControlItem(control).Precision;
        }


        public void SetPrecision(Control c, int value)
        {
            this.EnsureControlItem(c).Precision = value;
        }
        #endregion

        #region 错误提示信息

        private Color errorControlBackColor = Color.Yellow;

        public Color ErrorControlBackColor
        {
            get { return errorControlBackColor; }
            set { errorControlBackColor = value; }
        }

        private MessageBalloon balloon = new MessageBalloon();

        private void ShowInfo(Control control, string text, string title)
        {
            balloon.Parent = control;
            balloon.Title = title;
            balloon.TitleIcon = TooltipIcon.Info;
            balloon.Text = text;
            balloon.Show();
        }
        private void ShowError(Control control, string text,string title)
        {
            balloon.Parent = control;
            balloon.Title = title;
            balloon.TitleIcon = TooltipIcon.Error;
            balloon.Text = text;
            balloon.Show();
        }

        private void InitBalloon()
        {

            balloon.Align = BalloonAlignment.BottomLeft;
            balloon.CenterStem = false;
            balloon.UseAbsolutePositioning = true;
           
        }
        #endregion 
    
    }
}
