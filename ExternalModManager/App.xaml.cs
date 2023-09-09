using System;
using System.Diagnostics.Metrics;
using System.Windows;
using ExternalModManager.Core;
using ExternalModManager.Utilities;
using ExternalModManager.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace ExternalModManager;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
        {
            DataContext = serviceProvider.GetRequiredService<NavigationVM>()
        });
        services.AddSingleton<NavigationVM>();
        services.AddSingleton<GlobalCounter>();
        services.AddSingleton<HomeVM>();

        services.AddSingleton<CustomerVM>();
        services.AddSingleton<OrderVM>();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ReactiveObject>>(serviceProvider => viewModelType => (ReactiveObject) serviceProvider.GetRequiredService(viewModelType));
        
        _serviceProvider = services.BuildServiceProvider();
    }
    
    protected override async void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        
        base.OnStartup(e);
    }
    
    protected override async void OnExit(ExitEventArgs e)
    {
    
        base.OnExit(e);
    }
}