using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace CustomValidatorsLibrary
{
    [ToolboxBitmap(typeof(RangeValidator), "RangeValidator.ico")]
    public class RangeValidator : BaseCompareValidator
    {
        private string _minimumValue = "";
        private string _maximumValue = "";

        [Category("Behaviour")]
        [Description("Sets or returns the value of the control that you are validating, which must be greater than or equal to the value of this property. The default value is an empty string (\"\").")]
        [DefaultValue("")]
        public string MinimumValue
        {
            get { return _minimumValue; }
            set { _minimumValue = value; }
        }

        [Category("Behaviour")]
        [Description("Sets or returns the value of the control that you are validating, which must be less than or equal to the value of this property. The default value is an empty string (\"\").")]
        [DefaultValue("")]
        public string MaximumValue
        {
            get { return _maximumValue; }
            set { _maximumValue = value; }
        }

        protected override bool EvaluateIsValid()
        {
            // Don't validate if empty, unless required
            if (ControlToValidate.Text.Trim() == "") return true;

            // Validate and convert Minimum
            if (_minimumValue.Trim() == "") throw new Exception("MinimumValue must be provided.");
            string formattedMinimumValue = Format(_minimumValue.Trim());
            if (!CanConvert(formattedMinimumValue)) throw new Exception("MinimumValue cannot be converted to the specified Type.");
            object minimum = TypeConverter.ConvertFrom(formattedMinimumValue);

            // Validate and convert Maximum
            if (_maximumValue.Trim() == "") throw new Exception("MaximumValue must be provided.");
            string formattedMaximumValue = Format(_maximumValue.Trim());
            if (!CanConvert(formattedMaximumValue)) throw new Exception("MaximumValue cannot be converted to the specified Type.");
            object maximum = TypeConverter.ConvertFrom(formattedMaximumValue);

            // Check minimum <= maximum
            if (Comparer.Default.Compare(minimum, maximum) > 0) throw new Exception("MinimumValue cannot be greater than MaximumValue.");

            // Check and convert ControlToValue
            string formattedValue = Format(ControlToValidate.Text.Trim());
            if (!CanConvert(formattedValue)) return false;
            object value = TypeConverter.ConvertFrom(formattedValue);

            // Validate value's range (minimum <= value <= maximum)
            return ((Comparer.Default.Compare(minimum, value) <= 0) &&
              (Comparer.Default.Compare(value, maximum) <= 0));
        }
    }
}
