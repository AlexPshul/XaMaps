using XaMaps.Models;
using XaMaps.Services;

namespace XaMaps.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        public SearchPaneViewModel SearchPaneViewModel { get; } = new SearchPaneViewModel();
        public MapViewModel MapViewModel { get; } = new MapViewModel();

        private bool _isSearchPresented;
        public bool IsSearchPresented
        {
            get => _isSearchPresented;
            set => Set(ref _isSearchPresented, value);
        }

        public MainViewModel()
        {
            NavigationService.SelectedRouteChanged += route =>
            {
                if (route != null)
                    IsSearchPresented = false;
            };
        }
    }
}