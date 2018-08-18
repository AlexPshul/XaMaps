using System.ComponentModel;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;
using XaMaps;
using XaMaps.UWP;

[assembly: ExportRenderer(typeof(XaMap), typeof(XaMapRenderer))]
namespace XaMaps.UWP
{
    public class XaMapRenderer : MapRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            XaMap xaMap = Element as XaMap;
            if (xaMap == null || e.PropertyName != nameof(XaMap.RegionRotation))
                return;

            var tryRotateAsync = Control.TryRotateToAsync(xaMap.RegionRotation);
        }
    }
}