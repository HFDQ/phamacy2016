using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace CustomValidatorsLibrary
{
    [ToolboxBitmap(typeof(RequiredFieldValidator), "RequiredFieldValidator.ico")]
    public class RequiredFieldValidator : BaseValidator
    {
        private string _initialValue = null;

        [Category("Behaviour")]
        [DefaultValue(null)]
        [Description("��ȡ��������֤�ؼ���Ĭ��ֵ��Ĭ��ֵΪnull��")]
        public string InitialValue
        {
            get { return _initialValue; }
            set { _initialValue = value; }
        }

        protected override bool EvaluateIsValid()
        {
            string controlValue = ControlToValidate.Text.Trim();
            //string initialValue;
            //if (_initialValue == null) initialValue = "";
            //else initialValue = _initialValue.Trim();
            return (controlValue != string.Empty);
        }
    }
}
