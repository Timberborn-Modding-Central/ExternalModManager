using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExternalModManager.Core;
using ExternalModManager.Mvvm.ViewModels;
using Splat;
using MainWindow = ExternalModManager.Mvvm.Views.MainWindow;

namespace ExternalModManager;

public partial class App : Application
{
    public override void Initialize()
    {
        DependencyContainer.Initialize();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}