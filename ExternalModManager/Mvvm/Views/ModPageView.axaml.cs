using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ExternalModManager.Mvvm.ViewModels;

namespace ExternalModManager.Mvvm.Views;

public partial class ModPageView : ReactiveUserControl<ModPageViewModel>
{
    public ModPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // public void Next(object source, RoutedEventArgs args)
    // {
    //     Trace.WriteLine((bool)source);
    //     CarouselTest.Next();
    // }
    //
    // public void Previous(object source, RoutedEventArgs args) 
    // {
    //     Trace.WriteLine((bool)source);
    //     CarouselTest.Previous();
    // }
}