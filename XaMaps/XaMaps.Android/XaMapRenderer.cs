using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using XaMaps;
using XaMaps.Droid;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XaMap), typeof(XaMapRenderer))]
namespace XaMaps.Droid
{
    public class XaMapRenderer : MapRenderer, GoogleMap.IOnMapLoadedCallback
    {
        private XaMap _xamap;

        public XaMapRenderer(Context context) : base(context) { }

        public void OnMapLoaded() => UpdateDriverLocation();

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            _xamap = e.NewElement as XaMap;
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.MapClick -= SetCurrentLocation;
            NativeMap.MapClick += SetCurrentLocation;

            NativeMap.SetOnMapLoadedCallback(this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (_xamap == null || NativeMap == null || e.PropertyName != nameof(XaMap.CurrentLocation))
                return;

            UpdateDriverLocation();
        }

        private void SetCurrentLocation(object sender, GoogleMap.MapClickEventArgs e)
        {
            _xamap.CurrentLocation = new Position(e.Point.Latitude, e.Point.Longitude);
        }

        private void UpdateDriverLocation()
        {
            LatLng currentPosition = new LatLng(_xamap.CurrentLocation.Latitude, _xamap.CurrentLocation.Longitude);
            CameraPosition newPosition = new CameraPosition(
                currentPosition, NativeMap.CameraPosition.Zoom, NativeMap.CameraPosition.Tilt, (float) _xamap.Bearing);

            CameraUpdate rotationUpdate = CameraUpdateFactory.NewCameraPosition(newPosition);
            NativeMap.AnimateCamera(rotationUpdate, 250, null);
        }
    }
}