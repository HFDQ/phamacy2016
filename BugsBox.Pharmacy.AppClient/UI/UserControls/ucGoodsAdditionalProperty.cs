using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using System.Reflection;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucGoodsAdditionalProperty : UserControl
    {
        public ucGoodsAdditionalProperty()
        {
            InitializeComponent();
        }


        #region 控件到数据


        private void CellectData()
        {
            foreach (PropertyInfo propertyInfo in PropertyInfoes)
            {
                CellectProperty(propertyInfo);
            }
        }

        private void CellectProperty(PropertyInfo property)
        {
            Type propertyType = property.PropertyType;
            if (propertyType == typeof(Guid)) return;
            DataMemberAttribute dataMember = property.GetCustomAttributes(typeof(DataMemberAttribute), false)
                .FirstOrDefault() as DataMemberAttribute;
            if (dataMember == null) return;
            NotMappedAttribute notMapped = property.GetCustomAttributes(typeof(NotMappedAttribute), false)
                .FirstOrDefault() as NotMappedAttribute;
            if (notMapped != null) return;
            DisplayNameAttribute display = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                .FirstOrDefault() as DisplayNameAttribute;
            MaxLengthAttribute maxLength = property.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .FirstOrDefault() as MaxLengthAttribute;
            if (display == null) return;
            if (propertyType == typeof(string))
            {
                //字符串
                TextBox textBox = EditControls.FirstOrDefault(c => c.Name == typeof(TextBox).Name + property.Name) as TextBox;
                if (textBox != null)
                {
                    property.SetValue(goodsAdditional, textBox.Text.Trim(), null);
                }
            }
            //日期
            else if (propertyType == typeof(DateTime))
            {
                DateTimePicker dateTimePicker = EditControls.FirstOrDefault(c => c.Name == typeof(DateTimePicker).Name + property.Name) as DateTimePicker;
                if (dateTimePicker != null)
                {
                    property.SetValue(goodsAdditional, dateTimePicker.Value, null);
                }
            }
        }

        #endregion 控件到数据

        #region 数据到控件

        private void BindInfo()
        {
            foreach (PropertyInfo propertyInfo in PropertyInfoes)
            {
                BindInfoProperty(propertyInfo);
            }
        }

        private void BindInfoProperty(PropertyInfo property)
        {
            Type propertyType = property.PropertyType;
            if (propertyType == typeof(Guid)) return;
            DataMemberAttribute dataMember = property.GetCustomAttributes(typeof(DataMemberAttribute), false)
                .FirstOrDefault() as DataMemberAttribute;
            if (dataMember == null) return;
            NotMappedAttribute notMapped = property.GetCustomAttributes(typeof(NotMappedAttribute), false)
                .FirstOrDefault() as NotMappedAttribute;
            if (notMapped != null) return;
            DisplayNameAttribute display = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                .FirstOrDefault() as DisplayNameAttribute;
            MaxLengthAttribute maxLength = property.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .FirstOrDefault() as MaxLengthAttribute;
            if (display == null) return;
            if (propertyType == typeof(string))
            {
                //字符串
                TextBox textBox = EditControls.FirstOrDefault(c => c.Name == typeof(TextBox).Name + property.Name) as TextBox;
                if (textBox != null)
                {
                    object value = property.GetValue(goodsAdditional, null);
                    textBox.Text = value != null ? value.ToString() : "";
                }
            }
            //日期
            else if (propertyType == typeof(DateTime))
            {
                DateTimePicker dateTimePicker = EditControls.FirstOrDefault(c => c.Name == typeof(DateTimePicker).Name + property.Name) as DateTimePicker;
                if (dateTimePicker != null)
                {
                    object value = property.GetValue(goodsAdditional, null);
                    DateTime date = DateTime.Parse(value.ToString()).Date;
                    if (date > dateTimePicker.MinDate && date < dateTimePicker.MaxDate)
                        dateTimePicker.Value = DateTime.Parse(value.ToString());
                }
            }
        }

        #endregion

        #region 属性与字段

        private List<Control> EditControls = new List<Control>();

        private bool ControlsGenerated = false;

        private readonly static PropertyInfo[] PropertyInfoes = typeof(GoodsAdditionalProperty)
            .GetProperties().Where(p => p.CanRead && p.CanWrite).ToArray();

        private GoodsAdditionalProperty goodsAdditional = null;

        [Browsable(false)]
        public GoodsAdditionalProperty GoodsAdditional
        {
            get
            {
                CellectData();
                return goodsAdditional;
            }
            set
            {
                goodsAdditional = value;
                if (goodsAdditional == null) return;
                GeneratedControls();
                BindInfo();
            }
        }

        private DrugInfo drugInfo;

        /// <summary>
        /// 当前药物信息
        /// </summary>
        [Browsable(false)]
        public DrugInfo DrugInfo
        {
            get { return drugInfo; }
            set
            {
                drugInfo = value;
            }
        }

        private FormRunMode runMode;

        /// <summary>
        /// 窗口运行模式
        /// </summary>
        [Browsable(false)]
        public FormRunMode RunMode
        {
            get
            {
                return runMode;
            }
            set
            {
                runMode = value;
                if (runMode == FormRunMode.Add)
                {
                    this.Text = string.Format("{0}药物信息", "添加");
                }
                else if (runMode == FormRunMode.Edit)
                {
                    this.Text = string.Format("{0}药物信息", "编辑");
                }
                else if (runMode == FormRunMode.Browse)
                {
                    this.Text = string.Format("{0}药物信息", "查看");
                }
            }
        }

        #endregion

        #region 实体属性成控件

        private void GeneratedControlByPropertyInfo(PropertyInfo property)
        {
            Type propertyType = property.PropertyType;
            if (propertyType == typeof(Guid)) return;
            DataMemberAttribute dataMember = property.GetCustomAttributes(typeof(DataMemberAttribute), false)
                .FirstOrDefault() as DataMemberAttribute;
            if (dataMember == null) return;
            NotMappedAttribute notMapped = property.GetCustomAttributes(typeof(NotMappedAttribute), false)
                .FirstOrDefault() as NotMappedAttribute;
            if (notMapped != null) return;
            DisplayNameAttribute display = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                .FirstOrDefault() as DisplayNameAttribute;
            MaxLengthAttribute maxLength = property.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .FirstOrDefault() as MaxLengthAttribute;
            if (display == null) return;
            //标签处理 
            Label label = new Label();
            label.Width = EditControlWidth / 2;
            label.Name = label.GetType().Name + property.Name;
            label.Text = display.DisplayName + ":";
            label.TextAlign = ContentAlignment.MiddleCenter;
            EditControls.Add(label);
            if (propertyType == typeof(string))
            {
                //字符串
                TextBox textBox = new TextBox();
                textBox.Name = textBox.GetType().Name + property.Name;
                textBox.Width = EditControlWidth;
                //处理长度
                if (maxLength == null)
                {
                    textBox.MaxLength = 32;
                }
                else
                {
                    textBox.MaxLength = maxLength.Length / 2;
                }
                EditControls.Add(textBox);
            }
            //日期
            else if (propertyType == typeof(DateTime))
            {
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Name = dateTimePicker.GetType().Name + property.Name;
                dateTimePicker.Value = DateTime.Now;
                dateTimePicker.Width = EditControlWidth;
                dateTimePicker.MaxDate = DateTime.Now.AddYears(100);
                dateTimePicker.MinDate = DateTime.Now.AddYears(-100);
                EditControls.Add(dateTimePicker);
            }

        }

        private void GeneratedControls()
        {
            if (ControlsGenerated) return;
            var propertyInfoes = PropertyInfoes;
            foreach (var property in propertyInfoes)
            {
                GeneratedControlByPropertyInfo(property);
            }
            this.flowLayoutPanel1.Controls.AddRange(EditControls.ToArray());
            ControlsGenerated = true;
        }

        private const int EditControlWidth = 180;

        #endregion 实体属性成控件

        #region 事件处理

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            switch (RunMode)
            {
                case FormRunMode.Add:
                    break;
                case FormRunMode.Edit:
                    break;
                case FormRunMode.Browse:
                    this.Enabled = true;
                    break;
                case FormRunMode.Search:
                    break;
                case FormRunMode.Delete:
                    break;
                default:
                    break;
            }

        }

        #endregion 事件处理
    }
}
