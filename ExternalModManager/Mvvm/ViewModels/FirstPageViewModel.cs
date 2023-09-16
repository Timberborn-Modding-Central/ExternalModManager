using System;
using ExternalModManager.Core;

namespace ExternalModManager.Mvvm.ViewModels;

public class FirstPageViewModel : RoutedViewModelBase
{
    public string MyFirstString { get; } = Guid.NewGuid().ToString("N").Substring(0, 10);
}