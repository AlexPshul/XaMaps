using System.ComponentModel;
using System.Linq;
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

        public void OnMapLoaded() => _xamap.InitializeCurrentLocation();

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            _xamap = e.NewElement as XaMap;
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            NativeMap.SetOnMapLoadedCallback(this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (_xamap == null || NativeMap == null)
                return;

            if (e.PropertyName == nameof(XaMap.CurrentLocation))
                UpdateDriverLocation();
            else if (e.PropertyName == nameof(XaMap.SelectedRoute))
                ShowRouteOverview();
        }
        
        private void UpdateDriverLocation()
        {
            // Get the driver location and update camera
        }

        private void ShowRouteOverview()
        {
            // Clear map from previous highlights

            // Create polyline options

            // Calculate all route points

            // Create a camera update object

            // Update the map
        }
    }
}