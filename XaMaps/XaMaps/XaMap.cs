using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XaMaps
{
    public class XaMap : Map
    {
        public double RegionRotation
        {
            get => (double) GetValue(RegionRotationProperty);
            set => SetValue(RegionRotationProperty, value);
        }

        public static readonly BindableProperty RegionRotationProperty = 
            BindableProperty.Create(nameof(RegionRotation), typeof(double), typeof(XaMap), 0d);
    }
}