using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Navigation;

namespace WpfControlsLib
{
    public class NumberInputSmartSuperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numericValue = (double)value;

            return numericValue.ToString(culture);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var stringValue = (string)value;

            if (String.IsNullOrWhiteSpace(stringValue)) return (double)0;
            
            if (double.TryParse(stringValue, NumberStyles.Float, culture, 
                    out var resultCurrentCulture))
            {
                return resultCurrentCulture;
            }

            if (double.TryParse(stringValue, NumberStyles.Float, CultureInfo.InvariantCulture,
                    out var resultInvariantCulture))
            {
                return resultInvariantCulture;
            }
            
            // didn't manage to convert
            return null;

        }
    }
}