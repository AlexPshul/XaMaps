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

        public static event Action<Route> SelectedRouteChanged;
    }
}