using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WaveGenerator
{
    class frequencyRangeRule:ValidationRule
    {
        public int min { get; set; }
        public int max { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int number;
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "Invalid number format");
            }

            if (number < min || number > max)
            {
                return new ValidationResult(false, string.Format("Number out of range ({0} ~ {1})", min, max));
            }

            //OK
            return ValidationResult.ValidResult;
        }
    }
}
