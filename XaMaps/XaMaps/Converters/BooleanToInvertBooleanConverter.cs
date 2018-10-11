﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace XaMaps.Converters
{
    public class BooleanToInvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
    }
}