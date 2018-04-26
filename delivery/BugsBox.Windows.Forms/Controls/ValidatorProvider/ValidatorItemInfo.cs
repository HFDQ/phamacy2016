using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using BugsBox.Common.Data;
using System.Text.RegularExpressions;

namespace BugsBox.Windows.Controls
{
    public class ValidatorItemInfo
    {
        private Control control;

        public Control Control
        {
            get { return control; }
            set { control = value; }
        }
        private string dataName = string.Empty;
        private ValidatorProvider provider;


        public ValidatorItemInfo(ValidatorProvider provider, Control control)
        {
            this.control = control;
            this.provider = provider;
        }


        /// <summary>
        /// 数据项名称
        /// </summary>   
        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }

        private DataType dataType = DataType.字符串;

        /// <summary>
        /// 数据类型
        /// </summary>  
        public DataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        private bool allowNullOrEmpty = false;

        /// <summary>
        /// 是否允许为空OrNull
        /// </summary>
        public bool AllowNullOrEmpty
        {
            get { return allowNullOrEmpty; }
            set { allowNullOrEmpty = value; }
        }

        private int minLength = 1;

        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength
        {
            get { return minLength; }
            set { minLength = value; }
        }

        private int maxLength = 16;

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength
        {
            get { return maxLength; }
            set { maxLength = value; }
        }

        private string regex = string.Empty;

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex
        {
            get { return regex; }
            set
            { 
                regex = value;
                try
                {
                    if (!string.IsNullOrWhiteSpace(regex))
                    {
                        trueRegex = new Regex(regex);
                    }
                }
                catch (Exception ex)
                {
                    trueRegex = null;
                }
            }
        }

        private Regex trueRegex = null;

        public Regex GetRegex()
        {
            return trueRegex;
        }

        private string dataDescription = string.Empty;

        /// <summary>
        /// 数据描述
        /// </summary>
        public string DataDescription
        {
            get { return dataDescription; }
            set { dataDescription = value; }
        }

        private int precision = 0;

        public int Precision
        {
            get { return precision; }
            set { precision = value; }
        }
 
    }


}
