using System;
using ReactiveUI;

namespace ExternalModManager.Core;

public class NavigationService
{
    private readonly Func<Type, ViewModelBase> _viewModelFactory;

    public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public RoutingState Router { get; } = new();
    
    public IObservable<IRoutableViewModel> NavigateTo<T>() where T : ViewModelBase, IRoutableViewModel
    {
        return Router.Navigate.Execute((IRoutableViewModel) _viewModelFactory(typeof(T)));
    }
    
    public IObservable<IRoutableViewModel> NavigateAndResetTo<T>() where T : ViewModelBase, IRoutableViewModel
    {
        return Router.NavigateAndReset.Execute((IRoutableViewModel) _viewModelFactory(typeof(T)));
    }
}