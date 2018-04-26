using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomValidatorsLibrary
{
    [ToolboxBitmap(typeof(RegularExpressionValidator), "RegularExpressionValidator.ico")]
    public class RegularExpressionValidator : BaseValidator
    {
        private string _validationExpression = "";

        [Category("Behaviour")]
        [Description("��ȡ������������֤��������ʽ��")]
        [DefaultValue("")]
        public string ValidationExpression
        {
            get { return _validationExpression; }
            set { _validationExpression = value; }
        }

        protected override bool EvaluateIsValid()
        {
            // ������ʽΪ�գ�������֤����Ϊ��Ч��
            //if (ControlToValidate.Text.Trim() == "") return true;
            if (string.IsNullOrEmpty(_validationExpression)) return true;
            // Successful if match matches the entire text of ControlToValidate
            string field = ControlToValidate.Text.Trim();
            return Regex.IsMatch(field, _validationExpression.Trim());
        }
    }
}
