using System;
using Xamarin.Forms.Maps;

namespace XaMaps.Services
{
    public static class MapCalculations
    {
        public static double DegreeBearing(Position point1, Position point2)
        {
            double dLon = ToRad(point2.Longitude - point1.Longitude);
            double dPhi = Math.Log(Math.Tan(ToRad(point2.Latitude) / 2 + Math.PI / 4) / Math.Tan(ToRad(point1.Latitude) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);

            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        public static double ToRad(double degrees)
        {
            
            return degrees * (Math.PI / 180);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }
    }
}