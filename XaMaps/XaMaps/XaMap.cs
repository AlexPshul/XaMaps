using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XaMaps.Services;

namespace XaMaps
{
    public class XaMap : Map
    {
        #region Bindable Properties

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

        #endregion

        #region Constructors

        public XaMap()
        {
            InitializeCurrentLocation();
        }

        #endregion

        #region Private Methods

        private async void InitializeCurrentLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync();
            CurrentLocation = new Position(position.Latitude, position.Longitude);
        }

        #endregion
    }
}