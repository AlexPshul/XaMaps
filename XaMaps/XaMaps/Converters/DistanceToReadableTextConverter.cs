using System;
using System.Globalization;
using Xamarin.Forms;

namespace XaMaps.Converters
{
    public class DistanceToReadableTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double meters = (double)value;
            int hundredMeters = (int)Math.Round(meters / 100d);

            if (hundredMeters < 10)
            {
                // Round up to a multiplier of 100
                return $"{hundredMeters * 100} Meters";
            }

            return $"{meters / 1000:N1} KMs";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}