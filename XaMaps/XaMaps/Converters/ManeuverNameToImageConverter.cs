using System;
using System.Globalization;
using Xamarin.Forms;

namespace XaMaps.Converters
{
    public class ManeuverNameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string maneuverString = value?.ToString();
            if (string.IsNullOrEmpty(maneuverString))
                return null;

            return ImageSource.FromResource($"XaMaps.Maneuvers.{maneuverString.ToLowerInvariant()}.png", GetType());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}