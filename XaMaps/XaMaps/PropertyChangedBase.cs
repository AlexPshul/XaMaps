using System.ComponentModel;
using System.Runtime.CompilerServices;
using XaMaps.Annotations;

namespace XaMaps
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (member?.Equals(value) ?? false)
                return;

            member = value;
            OnPropertyChanged(propertyName);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}