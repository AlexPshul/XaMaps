using System;
using System.Collections.Generic;
using System.Text;
using XaMaps.Models;

namespace XaMaps.ViewModels
{
    public class SearchResultViewModel : PropertyChangedBase
    {
        private SingleFuzzyResult _fuzzyResult;
        public SingleFuzzyResult FuzzyResult
        {
            get => _fuzzyResult;
            set => Set(ref _fuzzyResult, value);
        }

        private RouteDirectionsResult _directions;
        public RouteDirectionsResult Directions
        {
            get => _directions;
            set => Set(ref _directions, value);
        }

    }
}