using System;
using System.Windows.Input;
using Xamarin.Forms;
using XaMaps.Models;
using XaMaps.Services;
using Position = Xamarin.Forms.Maps.Position;

namespace XaMaps.ViewModels
{
    public class ActionPanelViewModel : PropertyChangedBase
    {
        private int _nextInstructionIndex = 0;

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

        private Instruction _nextInstruction;
        public Instruction NextInstruction
        {
            get => _nextInstruction;
            set => Set(ref _nextInstruction, value);
        }

        private double _metersToNextManeuver;
        public double MetersToNextManeuver
        {
            get => _metersToNextManeuver;
            set => Set(ref _metersToNextManeuver, value);
        }

        public ICommand StartNavigationCommand { get; } = new Command(NavigationService.StartNavigating);
        public ICommand StopNavigationCommand { get; } = new Command(NavigationService.StopNavigating);

        public ActionPanelViewModel()
        {
            IsNavigating = NavigationService.IsNavigating;
            NavigationService.IsNavigatingChanged += isNavigating =>
            {
                IsNavigating = isNavigating;
                _nextInstructionIndex = 0;
                NextInstruction = SelectedRoute?.Guidance.Instructions[_nextInstructionIndex];
            };

            SelectedRoute = NavigationService.SelectedRoute;
            NavigationService.SelectedRouteChanged += selectedRoute => SelectedRoute = selectedRoute;

            NavigationService.NavigatedToLocation += UpdateInstruction;
        }

        private void UpdateInstruction(Position newPosition)
        {
            MetersToNextManeuver = MapCalculations.GetDistanceFromLatLonInKm(
                newPosition.Latitude, newPosition.Longitude, NextInstruction.Point.Latitude, NextInstruction.Point.Longitude) * 1000;

            if (_nextInstructionIndex + 1 == SelectedRoute.Guidance.Instructions.Count)
                return;

            if (newPosition.Latitude.Equals(NextInstruction.Point.Latitude) &&
                newPosition.Longitude.Equals(NextInstruction.Point.Longitude))
            {
                _nextInstructionIndex++;
                NextInstruction = SelectedRoute.Guidance.Instructions[_nextInstructionIndex];
            }
        }
    }
}