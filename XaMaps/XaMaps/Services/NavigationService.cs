using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XaMaps.Models;
using Position = Xamarin.Forms.Maps.Position;

namespace XaMaps.Services
{
    public static class NavigationService
    {
        private const double MetersPerSecondSpeed = 25;
        private const int UpdatesPerSecond = 4;

        private static Route _selectedRoute;
        public static Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value; 
                SelectedRouteChanged?.Invoke(value);
            }
        }

        public static bool IsNavigating { get; private set; }

        public static event Action<Route> SelectedRouteChanged;
        public static event Action<bool> IsNavigatingChanged;

        public static event Action<Position> NavigatedToLocation;

        public static async void StartNavigating()
        {
            IsNavigating = true;

            Position[] allPoints = SelectedRoute.Legs
                .SelectMany(leg => leg.Points)
                .Select(point => new Position(point.Latitude, point.Longitude))
                .ToArray();

            List<Position> selectedRoutePoints = new List<Position>();
            for (int i = 1; i < allPoints.Length; i++)
            {
                Position from = allPoints[i - 1];
                Position to = allPoints[i];

                List<Position> midPoints = MapCalculations.GetMidPoints(from, to, MetersPerSecondSpeed, UpdatesPerSecond);
                selectedRoutePoints.Add(from);
                selectedRoutePoints.AddRange(midPoints);
            }

            selectedRoutePoints.Add(allPoints.Last());

            IsNavigatingChanged?.Invoke(true);

            foreach (Position singlePoint in selectedRoutePoints)
            {
                await Task.Delay(1000 / UpdatesPerSecond);
                if (!IsNavigating)
                    return;

                NavigatedToLocation?.Invoke(singlePoint);
            }
        }

        public static void StopNavigating()
        {
            IsNavigating = false;
            IsNavigatingChanged?.Invoke(false);
        }
    }
}