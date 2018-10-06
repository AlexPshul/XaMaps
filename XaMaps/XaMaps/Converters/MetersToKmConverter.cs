using System;
using System.Globalization;
using Xamarin.Forms;

namespace XaMaps.Converters
{
    public class MetersToKmConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long meters = (long)value;
            return (meters / 1000d).ToString("N1");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}