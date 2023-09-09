using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalModManager.Utilities;
using System.Windows.Input;
using ExternalModManager.Core;

namespace ExternalModManager.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
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
        
        public NavigationVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationService.NavigateTo<HomeVM>();
            NavigateHomeCommand = new RelayCommand(o => { NavigationService.NavigateTo<HomeVM>(); });
            NavigateCustomerCommand = new RelayCommand(o => { NavigationService.NavigateTo<CustomerVM>(); });
        }
    }
}
