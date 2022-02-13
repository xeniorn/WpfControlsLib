using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfControlsLib
{
    public class NumberViewingSuperConverter : IMultiValueConverter
    {
      

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var value = (double)values[0];
            var parentNumericInputBox = (NumericInputBox)values[1];
            
            //if (!parentObject.ValueBox.IsFocused) return value;

            switch (parentNumericInputBox.RoundingMode)
            {
                case RoundingMode.Auto:
                case RoundingMode.None:
                    return value.ToString();
                case RoundingMode.DecimalPlaces:
                    return StringFromFixedDecimalPlaces(value, parentNumericInputBox.DecimalSpots);
                case RoundingMode.SignificantDigits:
                    return StringFromFixedSignificantDigits(value, parentNumericInputBox.SignificantDigits);
                default:
                    return "";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //this is only for one way conversions
            throw new NotSupportedException();
        }

        private string StringFromFixedSignificantDigits(double value, int targetSignificantDigits)
        {
            var numericValue = value;
            
            //if ((value == null) || (value == "")) return "";

            //double numericValue;
            //try
            //{
            //    numericValue = double.Parse(value, CultureInfo.InvariantCulture);
            //}
            //catch (FormatException e)
            //{
            //    return value;
            //}

            if (numericValue == 0) return "0";

            var logScale = (int)Math.Floor(Math.Log10(Math.Abs(numericValue))) + 1;
            var scale = Math.Pow(10, logScale);
            var finalVal = scale * Math.Round(numericValue / scale, targetSignificantDigits);


            if (targetSignificantDigits > scale)
            {
                if (numericValue < 1)
                {
                    return finalVal.ToString();
                }

                var afterDecimal = targetSignificantDigits - logScale;
                var formatString = "0." + new string('0', afterDecimal);
                return finalVal.ToString(formatString);
            }

            {
                var formatString = "0";
                return finalVal.ToString(formatString);
            }
        }

        private string StringFromFixedDecimalPlaces(double value, int targetDecimalSpots)
        {
            var numericValue = value;

            //if ((value == null) || (value=="")) return "";
            
            //double numericValue;
            //try
            //{
            //    numericValue = double.Parse(value, CultureInfo.InvariantCulture);
            //}
            //catch (FormatException e)
            //{
            //    return value;
            //}

            if (targetDecimalSpots > 0)
            {
                var format = "0." + new string('0', targetDecimalSpots);
                var finalVal = Math.Round(numericValue, targetDecimalSpots);
                return finalVal.ToString(format);
            }

            var factor = Math.Pow(10, targetDecimalSpots);
            var reverseFactor = (int)Math.Pow(10, -1 * targetDecimalSpots);

            return ((int)(Math.Round(numericValue * factor, 0) * reverseFactor)).ToString();
        }
    }
}