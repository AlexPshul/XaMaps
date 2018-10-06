using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XaMaps.Services;

namespace XaMaps
{
    public class XaMap : Map
    {
        public double Bearing { get; private set; }

        public Position CurrentLocation
        {
            get => (Position)GetValue(CurrentLocationProperty);
            set
            {
                Bearing = MapCalculations.DegreeBearing(CurrentLocation, value);
                SetValue(CurrentLocationProperty, value);
            }
        }

        public static readonly BindableProperty CurrentLocationProperty =
            BindableProperty.Create(nameof(CurrentLocation), typeof(Position), typeof(XaMap), new Position());

        public async void InitializeCurrentLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync();
            SetValue(CurrentLocationProperty, new Position(position.Latitude, position.Longitude));
        }
    }
}