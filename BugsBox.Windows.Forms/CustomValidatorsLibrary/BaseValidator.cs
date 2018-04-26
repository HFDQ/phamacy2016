using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CustomValidatorsLibrary
{
    public abstract partial class BaseValidator : Component
    {
        #region Constructors

        public BaseValidator()
        {
            InitializeComponent();
        }

        public BaseValidator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        private static ErrorProvider _errorProvider = new ErrorProvider();

        private string _errorMessage = "";
        private bool _isValid = false;
        private Control _controlToValidate = null;
        private Icon _icon = new Icon(typeof(ErrorProvider), "Error.ico");

        [Category("Appearance")]
        [Description("获取或设置错误消息的内容。")]
        [DefaultValue("")]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        [Category("Appearance")]
        [Description("获取或设置显式错误时使用的图标。")]
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        [Category("Behaviour")]
        [Description("获取或设置要验证的控件。")]
        [DefaultValue(null)]
        [TypeConverter(typeof(ValidatableControlConverter))]
        public Control ControlToValidate
        {
            get { return _controlToValidate; }
            set
            {
                _controlToValidate = value;

                // 为输入控件添加事件处理函数。
                if ((_controlToValidate != null) && (!DesignMode))
                {
                    _controlToValidate.Validating += new CancelEventHandler(ControlToValidate_Validating);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        protected abstract bool EvaluateIsValid();

        public void Validate()
        {
            // 验证控件。
            _isValid = EvaluateIsValid();

            // 使用ErrorProvider实例显式无效的输入。
            string errorMessage = "";
            if (!_isValid)
            {
                errorMessage = _errorMessage;
                _errorProvider.Icon = _icon;
            }

            _errorProvider.SetError(_controlToValidate, errorMessage);
        }

        private void ControlToValidate_Validating(object sender, CancelEventArgs e)
        {
            // 不要取消无效的输入，那样会给用户的操作带来麻烦。
            Validate();
        }
    }

    #region 校验的数据类型。

    public enum ValidationDataType
    {
        Currency,
        Date,
        Double,
        Integer,
        String
    }

    #endregion

    #region 校验控件的比较操作类型。

    public enum ValidationCompareOperator
    {
        DataTypeCheck,
        Equal,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual,
        NotEqual
    }

    #endregion

    #region ValidatableControlConverter

    public class ValidatableControlConverter : ReferenceConverter
    {
        public ValidatableControlConverter(Type type) : base(type) { }

        protected override bool IsValueAllowed(ITypeDescriptorContext context, object value)
        {
            return ((value is TextBox) ||
                    (value is ListBox) ||
                    (value is ComboBox) ||
                    (value is UserControl)||
                    (value is RichTextBox));
        }
    }

    #endregion

}
