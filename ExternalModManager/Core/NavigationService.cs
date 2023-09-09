using System;
using System.Windows.Controls;
using ExternalModManager.MVVM.View;
using ExternalModManager.MVVM.ViewModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ExternalModManager.Core;

public class NavigationService : ReactiveObject
{
    private readonly Func<Type, Type, UserControl> _userControlFactory;

    [Reactive]
    public UserControl CurrentView { get; set; }

    public NavigationService(Func<Type, Type, UserControl> userControlFactory)
    {
        _userControlFactory = userControlFactory;
        
        CurrentView = userControlFactory.Invoke(typeof(ModsView), typeof(ModsViewModel));
    }
    
    public void NavigateTo<TUserControl, TViewModel>() where TViewModel : ReactiveObject
    {
        CurrentView = _userControlFactory.Invoke(typeof(TUserControl), typeof(TViewModel));
    }
    
    public RelayCommand CreatNavigationCommand<TView, TViewModel>() where TView : UserControl where TViewModel : ReactiveObject
    {
        return new RelayCommand(o => { NavigateTo<TView, TViewModel>(); });
    }
}