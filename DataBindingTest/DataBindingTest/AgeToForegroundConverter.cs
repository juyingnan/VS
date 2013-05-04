using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace DataBindingTest
{
    [ValueConversion(/*sourceType*/ typeof(int),typeof(Brush))]
    class AgeToForegroundConverter:IValueConverter
    {
        //called when converting the age to a foreground brush
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //only convert to brushes
            if (targetType != typeof(Brush))
                return null;
            //over 25
            int age = int.Parse(value.ToString());
            return (age > 25 ? Brushes.Red : Brushes.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //won't be called here
            throw new NotImplementedException();
        }
    }
}
