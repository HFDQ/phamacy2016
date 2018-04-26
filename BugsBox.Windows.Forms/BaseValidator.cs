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
        [Description("��ȡ�����ô�����Ϣ�����ݡ�")]
        [DefaultValue("")]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        [Category("Appearance")]
        [Description("��ȡ��������ʽ����ʱʹ�õ�ͼ�ꡣ")]
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        [Category("Behaviour")]
        [Description("��ȡ������Ҫ��֤�Ŀؼ���")]
        [DefaultValue(null)]
        [TypeConverter(typeof(ValidatableControlConverter))]
        public Control ControlToValidate
        {
            get { return _controlToValidate; }
            set
            {
                _controlToValidate = value;

                // Ϊ����ؼ�����¼���������
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
            // ��֤�ؼ���
            _isValid = EvaluateIsValid();

            // ʹ��ErrorProviderʵ����ʽ��Ч�����롣
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
            // ��Ҫȡ����Ч�����룬��������û��Ĳ��������鷳��
            Validate();
        }
    }

    #region У����������͡�

    public enum ValidationDataType
    {
        Currency,
        Date,
        Double,
        Integer,
        String
    }

    #endregion

    #region У��ؼ��ıȽϲ������͡�

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
