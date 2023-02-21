using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManagement.Desktop.Core
{
    /// <summary>
    /// Represents an observable object
    /// </summary>
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
