using TaskManagement.Desktop.Core;

namespace TaskManagement.Desktop.Domain.ViewModel
{
    /// <summary>
    /// Represents a main view
    /// </summary>
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        public MainViewModel() 
        {
            HomeViewModel = new HomeViewModel();
            TaskViewModel= new TaskViewModel();

            CurrentView = this.HomeViewModel;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeViewModel;
            });            
            
            TaskViewCommand = new RelayCommand(o =>
            {
                CurrentView = TaskViewModel;
            });
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeViewModel { get; set; }
        public TaskViewModel TaskViewModel { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand TaskViewCommand { get; set; }
    }
}
