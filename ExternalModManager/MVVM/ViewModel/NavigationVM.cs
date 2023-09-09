using ExternalModManager.Core;
using ExternalModManager.Navigation;

namespace ExternalModManager.MVVM.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private NavigationService _navigationService;

        public NavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateCustomerCommand { get; set; }
        
        public NavigationVM(NavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationService.NavigateTo<HomeVM>();
            NavigateHomeCommand = new RelayCommand(o => { NavigationService.NavigateTo<HomeVM>(); });
            NavigateCustomerCommand = new RelayCommand(o => { NavigationService.NavigateTo<CustomerVM>(); });
        }
    }
}
