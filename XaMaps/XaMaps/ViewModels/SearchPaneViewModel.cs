namespace XaMaps.ViewModels
{
    public class SearchPaneViewModel : PropertyChangedBase
    {
        public AddressSearchViewModel SearchViewModel { get; } = new AddressSearchViewModel();
    }
}