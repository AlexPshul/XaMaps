using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace XaMaps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var position = await CrossGeolocator.Current.GetPositionAsync();
            
            MapSpan currentCenter = MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(0.5));
            MapElement.MoveToRegion(currentCenter);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            MapElement.RegionRotation = MapElement.RegionRotation + 90 % 360;
        }
    }
}