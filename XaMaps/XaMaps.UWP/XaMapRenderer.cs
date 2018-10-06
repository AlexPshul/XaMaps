using System;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;
using XaMaps;
using XaMaps.Services;
using XaMaps.UWP;

[assembly: ExportRenderer(typeof(XaMap), typeof(XaMapRenderer))]
namespace XaMaps.UWP
{
    public class XaMapRenderer : MapRenderer
    {
        private XaMap _xamap;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            _xamap = e.NewElement as XaMap;

            Control.Language = "en";

            Control.LoadingStatusChanged -= OnFirstLoadingChange;
            Control.LoadingStatusChanged += OnFirstLoadingChange;

            Control.MapTapped -= SetCurrentLocation;
            Control.MapTapped += SetCurrentLocation;
        }

        private void OnFirstLoadingChange(MapControl sender, object args)
        {
            if (sender.LoadingStatus == MapLoadingStatus.Loaded)
            {
                Control.LoadingStatusChanged -= OnFirstLoadingChange;
                _xamap.InitializeCurrentLocation();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (_xamap == null || e.PropertyName != nameof(XaMap.CurrentLocation))
                return;

            Geopoint geopoint = new Geopoint(new BasicGeoposition { Latitude = _xamap.CurrentLocation.Latitude, Longitude = _xamap.CurrentLocation.Longitude });
            var trySetViewAsync = Control.TrySetViewAsync(geopoint, 18, _xamap.Bearing, 0);
        }

        private void SetCurrentLocation(MapControl sender, MapInputEventArgs args)
        {
            _xamap.CurrentLocation = new Position(args.Location.Position.Latitude, args.Location.Position.Longitude);
        }
    }
}