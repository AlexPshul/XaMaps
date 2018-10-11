using System.Windows.Input;
using Xamarin.Forms;
using XaMaps.Models;
using XaMaps.Services;

namespace XaMaps.ViewModels
{
    public class ActionPanelViewModel : PropertyChangedBase
    {
        private bool _isNavigating;
        public bool IsNavigating
        {
            get => _isNavigating;
            set => Set(ref _isNavigating, value);
        }

        private Route _selectedRoute;
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set => Set(ref _selectedRoute, value);
        }

        public ICommand StartNavigationCommand { get; } = new Command(() => NavigationService.IsNavigating = true);
        public ICommand StopNavigationCommand { get; } = new Command(() => NavigationService.IsNavigating = false);

        public ActionPanelViewModel()
        {
            IsNavigating = NavigationService.IsNavigating;
            NavigationService.IsNavigatingChanged += isNavigating => IsNavigating = isNavigating;

            SelectedRoute = NavigationService.SelectedRoute;
            NavigationService.SelectedRouteChanged += selectedRoute => SelectedRoute = selectedRoute;
        }
    }
}