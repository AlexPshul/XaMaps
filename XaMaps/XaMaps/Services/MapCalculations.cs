using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace XaMaps.Services
{
    public static class MapCalculations
    {
        public static List<Position> GetMidPoints(Position start, Position end, double metersPerSecondSpeed, int updatesPerSecond)
        {
            double distanceInMeters = GetDistanceFromLatLonInKm(start.Latitude, start.Longitude, end.Latitude, end.Longitude) * 1000;
            int pointsInTheMiddle = (int) Math.Floor(distanceInMeters / metersPerSecondSpeed * updatesPerSecond);
            
            double bearingDegrees = DegreeBearing(start, end);
            double kmPerJump = metersPerSecondSpeed / updatesPerSecond / 1000d;

            List<Position> sectionPoints = new List<Position>();
            Position lastPoint = start;
            for (int i = 0; i < pointsInTheMiddle; i++)
            {
                Position nextPosition = FindPointAtDistanceFrom(lastPoint, bearingDegrees, kmPerJump);
                sectionPoints.Add(nextPosition);
                lastPoint = nextPosition;
            }

            return sectionPoints;
        }

        public static double DegreeBearing(Position point1, Position point2)
        {
            double dLon = ToRad(point2.Longitude - point1.Longitude);
            double dPhi = Math.Log(Math.Tan(ToRad(point2.Latitude) / 2 + Math.PI / 4) / Math.Tan(ToRad(point1.Latitude) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);

            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        /// <summary>
        /// Convert radians to degrees (as bearing: 0...360)
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double ToBearing(double radians) => (ToDegrees(radians) + 360) % 360;
        public static double ToRad(double degrees) => degrees * (Math.PI / 180);
        public static double ToDegrees(double radians) => radians * 180 / Math.PI;

        public static double GetDistanceFromLatLonInKm(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371d; // Radius of the earth in km
            var dLat = ToRad(lat2 - lat1);  // deg2rad below
            var dLon = ToRad(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2d) * Math.Sin(dLat / 2d) +
                Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                Math.Sin(dLon / 2d) * Math.Sin(dLon / 2d);
            var c = 2d * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1d - a));
            var d = R * c; // Distance in km

            return d;
        }

        private static Position FindPointAtDistanceFrom(Position startPoint, double initialBearingDegrees, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = ToRad(startPoint.Latitude);
            var startLonRad = ToRad(startPoint.Longitude);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            double bearingRad = ToRad(initialBearingDegrees);
            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(bearingRad)));

            var endLonRads = startLonRad
                             + Math.Atan2(
                                 Math.Sin(bearingRad) * distRatioSine * startLatCos,
                                 distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new Position(ToDegrees(endLatRads), ToDegrees(endLonRads));
        }
    }
}