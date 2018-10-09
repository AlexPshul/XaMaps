using XaMaps.Models;
using XaMaps.Services;

namespace XaMaps.ViewModels
{
    public class MapViewModel : PropertyChangedBase
    {
        private Route _selectedRoute;
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set => Set(ref _selectedRoute, value);
        }

        public MapViewModel()
        {
            NavigationService.SelectedRouteChanged += route => SelectedRoute = route;
        }
    }
}