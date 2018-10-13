using System;
using System.Globalization;
using Xamarin.Forms;
using XaMaps.Models;

namespace XaMaps.Converters
{
    public class FuzzyResultToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SingleFuzzyResult singleFuzzyResult = value as SingleFuzzyResult;
            if (singleFuzzyResult == null)
                return null;

            return !string.IsNullOrEmpty(singleFuzzyResult.Poi?.Name)
                ? singleFuzzyResult.Poi.Name
                : singleFuzzyResult.Address?.FreeformAddress;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}