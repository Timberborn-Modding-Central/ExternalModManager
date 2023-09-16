using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ExternalModManager.Mvvm.ViewModels;

namespace ExternalModManager.Mvvm.Views;

public partial class FirstPageView : ReactiveUserControl<FirstPageViewModel>
{
    public FirstPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}