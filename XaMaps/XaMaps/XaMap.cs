using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XaMaps.Models;
using XaMaps.Services;
using Position = Xamarin.Forms.Maps.Position;

namespace XaMaps
{
    public class XaMap : Map
    {
        public double Bearing { get; private set; }


        public Position CurrentLocation
        {
            get => (Position) GetValue(CurrentLocationProperty);
            set
            {
                Bearing = MapCalculations.DegreeBearing(CurrentLocation, value);
                SetValue(CurrentLocationProperty, value);
            }
        }

        public static readonly BindableProperty CurrentLocationProperty =
            BindableProperty.Create(nameof(CurrentLocation), typeof(Position), typeof(XaMap), new Position());


        public Route SelectedRoute
        {
            get => (Route) GetValue(SelectedRouteProperty);
            set => SetValue(SelectedRouteProperty, value);
        }

        public static readonly BindableProperty SelectedRouteProperty = 
            BindableProperty.Create(nameof(SelectedRoute), typeof(Route), typeof(XaMap), null);


        public XaMap()
        {
            NavigationService.NavigatedToLocation += newPosition => CurrentLocation = newPosition;
            InitializeCurrentLocation();
        }


        public async void InitializeCurrentLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync();
            SetValue(CurrentLocationProperty, new Position(position.Latitude, position.Longitude));
            MoveToRegion(MapSpan.FromCenterAndRadius(CurrentLocation, Distance.FromKilometers(1)));
        }
    }
}