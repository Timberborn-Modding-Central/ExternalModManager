using System;
using ExternalModManager.Utilities;
using ReactiveUI;

namespace ExternalModManager.Core;

public interface INavigationService
{
    ReactiveObject CurrentView { get; }

    void NavigateTo<T>() where T : ReactiveObject;
}

public class NavigationService : ViewModelBase, INavigationService
{
    private readonly Func<Type, ReactiveObject> _viewModelFactory;
    
    private ReactiveObject _currentView;

    public ReactiveObject CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, ReactiveObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }
    
    public void NavigateTo<TViewModel>() where TViewModel : ReactiveObject
    {
        CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
    }
}