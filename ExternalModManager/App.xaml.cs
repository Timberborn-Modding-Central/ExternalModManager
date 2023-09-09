using System;
using System.Windows;
using System.Windows.Controls;
using ExternalModManager.Core;
using ExternalModManager.MVVM.View;
using ExternalModManager.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace ExternalModManager;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
        {
            DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>()
        });

        
        services.AddView<MapsView, MapsViewModel>().AsSingleton();
        services.AddView<ModsView, ModsViewModel>().AsSingleton();
        

        services.AddSingleton<NavigationService>();

        services.AddSingleton<Func<Type, Type, UserControl>>(serviceProvider => (userControlType, viewModelType) =>
        {
            var userControl = (UserControl) serviceProvider.GetRequiredService(userControlType);
            var viewModelControl = (ReactiveObject) serviceProvider.GetRequiredService(viewModelType);

            userControl.DataContext = viewModelControl;

            return userControl;
        });

        _serviceProvider = services.BuildServiceProvider();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        
        base.OnStartup(e);
    }
}