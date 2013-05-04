using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WaveGenerator
{
    class DoubleToLogIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //slider to textbox
            double defaultValue = 0;
            if (double.TryParse(value.ToString(), out defaultValue))
                return (int)Math.Pow(10, defaultValue);
            else
                return (int)1000;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //text to slider
            double defaultValue = 0;
            if (double.TryParse((string)value, out defaultValue))
                return Math.Log10(defaultValue);
            else
                return 3.0;
        }
    }
}
