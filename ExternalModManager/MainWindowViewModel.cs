using ExternalModManager.Core;
using ExternalModManager.MVVM.View;
using ExternalModManager.MVVM.ViewModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ExternalModManager;

class MainWindowViewModel : ReactiveObject
{
    public NavigationService NavigationService { get; }
        
    public RelayCommand NavigateHomeCommand { get; set; }
        
    public RelayCommand NavigateCustomerCommand { get; set; }
        
    public MainWindowViewModel(NavigationService navigationService)
    {
        NavigationService = navigationService;

        NavigateHomeCommand = NavigationService.CreatNavigationCommand<ModsView, ModsViewModel>();
        NavigateCustomerCommand = NavigationService.CreatNavigationCommand<MapsView, MapsViewModel>();
    }
}