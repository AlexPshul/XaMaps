using System;
using System.ComponentModel;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;
using XaMaps;
using XaMaps.Services;
using XaMaps.UWP;
using Thickness = Windows.UI.Xaml.Thickness;

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
            if (_xamap == null)
                return;

            if (e.PropertyName == nameof(XaMap.CurrentLocation))
                UpdateDriverLocation();
            else if (e.PropertyName == nameof(XaMap.SelectedRoute))
                ShowRouteOverview();

        }

        private void UpdateDriverLocation()
        {
            Geopoint geopoint = new Geopoint(new BasicGeoposition { Latitude = _xamap.CurrentLocation.Latitude, Longitude = _xamap.CurrentLocation.Longitude });
            var trySetViewAsync = Control.TrySetViewAsync(geopoint, 18, _xamap.Bearing, 0);
        }

        private void ShowRouteOverview()
        {
            Control.MapElements.Clear();

            BasicGeoposition[] allRoutePoints = _xamap.SelectedRoute.Legs
                .SelectMany(leg => leg.Points)
                .Select(point => new BasicGeoposition { Latitude = point.Latitude, Longitude = point.Longitude })
                .ToArray();

            MapPolyline routeLine = new MapPolyline
            {
                Path = new Geopath(allRoutePoints),
                StrokeColor = Colors.Blue,
                StrokeThickness = 7
            };

            Control.MapElements.Add(routeLine);

            GeoboundingBox routeBounds = GeoboundingBox.TryCompute(allRoutePoints);
            var trySetViewAsync = Control.TrySetViewBoundsAsync(routeBounds, new Thickness(50d), MapAnimationKind.Bow);
        }

        private void SetCurrentLocation(MapControl sender, MapInputEventArgs args)
        {
            _xamap.CurrentLocation = new Position(args.Location.Position.Latitude, args.Location.Position.Longitude);
        }
    }
}