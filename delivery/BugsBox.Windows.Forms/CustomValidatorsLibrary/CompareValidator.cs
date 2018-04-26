using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomValidatorsLibrary
{
    [ToolboxBitmap(typeof(CompareValidator), "CompareValidator.ico")]
    public class CompareValidator : BaseCompareValidator
    {
        private string _valueToCompare = "";
        private Control _controlToCompare = null;
        private ValidationCompareOperator _operator = ValidationCompareOperator.Equal;

        [TypeConverter(typeof(ValidatableControlConverter))]
        [Category("Behaviour")]
        [Description("Gets or sets the input control to compare with the input control being validated.")]
        [DefaultValue(null)]
        public Control ControlToCompare
        {
            get { return _controlToCompare; }
            set { _controlToCompare = value; }
        }

        [Category("Behaviour")]
        [Description("Gets or sets the comparison operation to perform.")]
        [DefaultValue(null)]
        public ValidationCompareOperator Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        [Category("Behaviour")]
        [Description("Gets or sets a constant value to compare with the value entered by the user into the input control being validated.")]
        [DefaultValue("")]
        public string ValueToCompare
        {
            get { return _valueToCompare; }
            set { _valueToCompare = value; }
        }

        protected override bool EvaluateIsValid()
        {
            // Don't validate if empty, unless required
            if (ControlToValidate.Text.Trim() == "") return true;

            // Can't evaluate if missing ControlToCompare and ValueToCompare
            if ((_controlToCompare == null) && (_valueToCompare == "")) throw new Exception("The ControlToCompare property cannot be blank.");

            // Validate and convert CompareFrom
            string formattedCompareFrom = Format(ControlToValidate.Text);
            bool canConvertFrom = CanConvert(formattedCompareFrom);
            if (canConvertFrom)
            {
                if (_operator == ValidationCompareOperator.DataTypeCheck) return canConvertFrom;
            }
            else return false;
            object compareFrom = TypeConverter.ConvertFrom(formattedCompareFrom);

            // Validate and convert CompareTo
            string formattedCompareTo = Format(((_controlToCompare != null) ? _controlToCompare.Text : _valueToCompare));
            if (!CanConvert(formattedCompareTo)) throw new Exception("The value you are comparing to cannot be converted to the specified Type.");
            object compareTo = TypeConverter.ConvertFrom(formattedCompareTo);

            // Perform comparison eg ==, >, >=, <, <=, !=
            int result = Comparer.Default.Compare(compareFrom, compareTo);
            switch (_operator)
            {
                case ValidationCompareOperator.Equal:
                    return (result == 0);
                case ValidationCompareOperator.GreaterThan:
                    return (result > 0);
                case ValidationCompareOperator.GreaterThanEqual:
                    return (result >= 0);
                case ValidationCompareOperator.LessThan:
                    return (result < 0);
                case ValidationCompareOperator.LessThanEqual:
                    return (result <= 0);
                case ValidationCompareOperator.NotEqual:
                    return ((result != 0));
                default:
                    return false;
            }
        }
    }
}
