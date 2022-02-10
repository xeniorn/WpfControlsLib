using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfControlsLib
{
    public class NumberViewingSuperConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var parentObject = (NumericInputBox)values[0];
            var value = (string)values[1];


            switch (parentObject.RoundingMode)
            {
                case RoundingMode.Auto:
                case RoundingMode.None:
                    return value;
                case RoundingMode.DecimalPlaces:
                    return StringFromFixedDecimalPlaces(value, parentObject.DecimalSpots);
                case RoundingMode.SignificantDigits:
                    return StringFromFixedSignificantDigits(value, parentObject.SignificantDigits);
                default:
                    return "";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //this is only for one way conversions
            throw new NotSupportedException();
        }

        private string StringFromFixedSignificantDigits(string value, int parentObjectSignificantDigits)
        {
            double numericValue;
            try
            {
                numericValue = double.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                return value;
            }

            if (numericValue == 0) return "0";

            var logScale = (int)Math.Floor(Math.Log10(Math.Abs(numericValue))) + 1;
            var scale = Math.Pow(10, logScale);
            var finalVal = scale * Math.Round(numericValue / scale, parentObjectSignificantDigits);


            if (parentObjectSignificantDigits > scale)
            {
                if (numericValue < 1)
                {
                    return finalVal.ToString(CultureInfo.InvariantCulture);
                }

                var afterDecimal = parentObjectSignificantDigits - logScale;
                var formatString = "#." + new string('0', afterDecimal);
                return finalVal.ToString(formatString, CultureInfo.InvariantCulture);
            }

            {
                var formatString = "0";
                return finalVal.ToString(formatString, CultureInfo.InvariantCulture);
            }
        }

        private string StringFromFixedDecimalPlaces(string value, int parentObjectDecimalSpots)
        {
            double numericValue;
            try
            {
                numericValue = double.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                return value;
            }

            if (parentObjectDecimalSpots > 0)
            {
                var finalVal = Math.Round(numericValue, parentObjectDecimalSpots);
                return finalVal.ToString(CultureInfo.InvariantCulture);
            }

            var factor = Math.Pow(10, parentObjectDecimalSpots);
            var reverseFactor = (int)Math.Pow(10, -1 * parentObjectDecimalSpots);

            return ((int)(Math.Round(numericValue * factor, 0) * reverseFactor)).ToString(CultureInfo.InvariantCulture);
        }
    }
}