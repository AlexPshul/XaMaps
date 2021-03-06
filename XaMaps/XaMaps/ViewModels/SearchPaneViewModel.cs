﻿using System;
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

            FuzzyResults fuzzyResults = await SearchService.FuzzySearch(query);

            var crossPosition = await CrossGeolocator.Current.GetPositionAsync();
            Position xaMapPosition = new Position { Lat = crossPosition.Latitude, Lon = crossPosition.Longitude };

            IEnumerable<Task<SearchResultViewModel>> searchRouteTasks =
                fuzzyResults.Results.Select(result => LoadRoutes(xaMapPosition, result));

            var directionsResults = await Task.WhenAll(searchRouteTasks);
            Results = directionsResults.Where(result => result != null).ToArray();

            IsBusy = false;
        }

        private async Task<SearchResultViewModel> LoadRoutes(Position currentPosition, SingleFuzzyResult fuzzyResult)
        {
            RouteDirectionsResult routeDirectionsResult = await SearchService.GetDirections(currentPosition, fuzzyResult.Position);

            return routeDirectionsResult?.Routes?.Length > 0
                ? new SearchResultViewModel { FuzzyResult = fuzzyResult, Directions = routeDirectionsResult }
                : null;
        }
    }
}