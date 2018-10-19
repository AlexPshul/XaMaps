using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Geolocator;
using Xamarin.Forms;
using XaMaps.Models;
using XaMaps.Services;

namespace XaMaps.ViewModels
{
    public class SearchPaneViewModel : PropertyChangedBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        private SearchResultViewModel[] _results;
        public SearchResultViewModel[] Results
        {
            get => _results;
            set => Set(ref _results, value);
        }

        private SearchResultViewModel _selectedResult;
        public SearchResultViewModel SelectedResult
        {
            get => _selectedResult;
            set
            {
                Set(ref _selectedResult, value);
                NavigationService.SelectedRoute = value?.Directions?.Routes?.FirstOrDefault();
            }
        }

        public ICommand SearchAddressCommand { get; }

        public SearchPaneViewModel()
        {
            SearchAddressCommand = new Command<string>(Search);
        }

        private async void Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return;

            Results = Array.Empty<SearchResultViewModel>();

            IsBusy = true;
            
            // Populate the Results array

            IsBusy = false;
        }
    }
}