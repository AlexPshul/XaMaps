using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using XaMaps;
using XaMaps.Droid;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

[assembly: ExportRenderer(typeof(XaMap), typeof(XaMapRenderer))]
namespace XaMaps.Droid
{
    public class XaMapRenderer : MapRenderer
    {
        public XaMapRenderer(Context context) : base(context) { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            XaMap xaMap = Element as XaMap;
            if (xaMap == null || e.PropertyName != nameof(XaMap.RegionRotation))
                return;

            CameraPosition currentPosition = NativeMap.CameraPosition;
            CameraPosition newPosition = new CameraPosition(
                currentPosition.Target, currentPosition.Zoom, currentPosition.Tilt, (float) xaMap.RegionRotation);

            CameraUpdate rotationUpdate = CameraUpdateFactory.NewCameraPosition(newPosition);
            //NativeMap.MoveCamera(rotationUpdate);
            NativeMap.AnimateCamera(rotationUpdate, 500, null);
        }
    }
}