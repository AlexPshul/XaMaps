using System;
using XaMaps.Models;

namespace XaMaps.Services
{
    public static class NavigationService
    {
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

        private static bool _isNavigating;
        public static bool IsNavigating
        {
            get => _isNavigating;
            set
            {
                _isNavigating = value; 
                IsNavigatingChanged?.Invoke(value);
            }
        }


        public static event Action<Route> SelectedRouteChanged;
        public static event Action<bool> IsNavigatingChanged;
    }
}