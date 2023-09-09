using System;
using System.Windows;
using ExternalModManager.MVVM.ViewModel;
using ExternalModManager.Navigation;
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

        services.AddSingleton<CustomerVM>();
        services.AddSingleton<HomeVM>();

        services.AddSingleton<NavigationService>();
        services.AddSingleton<Func<Type, ReactiveObject>>(serviceProvider => viewModelType => (ReactiveObject) serviceProvider.GetRequiredService(viewModelType));
        
        _serviceProvider = services.BuildServiceProvider();
    }
    
    protected override async void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        
        base.OnStartup(e);
    }
}