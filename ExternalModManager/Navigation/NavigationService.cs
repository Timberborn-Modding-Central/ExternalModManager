using System;
using ExternalModManager.Core;
using ExternalModManager.MVVM.ViewModel;
using ReactiveUI;

namespace ExternalModManager.Navigation;

public class NavigationService : ViewModelBase
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

        // First page
        _currentView = _viewModelFactory.Invoke(typeof(HomeVM));
    }
    
    public void NavigateTo<TViewModel>() where TViewModel : ReactiveObject
    {
        CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
    }
}