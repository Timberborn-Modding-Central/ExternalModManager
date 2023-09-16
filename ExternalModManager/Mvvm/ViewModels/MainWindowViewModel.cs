using System.Reactive;
using ExternalModManager.Core;
using ReactiveUI;

namespace ExternalModManager.Mvvm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public NavigationService NavigationService { get; }
    
    // The command that navigates a user to first view model.
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoNextEmpty { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel?> GoBack => NavigationService.Router.NavigateBack;
    

    public MainWindowViewModel(NavigationService navigationService)
    {
        NavigationService = navigationService;
        
        GoNext = ReactiveCommand.CreateFromObservable(NavigationService.NavigateTo<FirstPageViewModel>);
        
        GoNextEmpty = ReactiveCommand.CreateFromObservable(NavigationService.NavigateAndResetTo<FirstPageViewModel>);
    }

    public MainWindowViewModel()
    {
    }
}