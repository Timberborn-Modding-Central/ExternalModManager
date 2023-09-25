using System;
using Autofac;
using Avalonia.ReactiveUI;
using ExternalModManager.Mvvm.ViewModels;
using ExternalModManager.Mvvm.Views;
using ReactiveUI;
using Splat;
using Splat.Autofac;

namespace ExternalModManager.Core;

public static class DependencyContainer
{
    public static void SetupConfigurator(ContainerBuilder builder)
    {
        builder.RegisterView<FirstPageView, FirstPageViewModel>();
        builder.RegisterView<ModPageView, ModPageViewModel>();
        
        builder.RegisterType<NavigationService>().AsSelf();
        
        builder.RegisterType<MainWindowViewModel>().AsSelf().SingleInstance();
        
        builder.Register<Func<Type, ViewModelBase>>(c =>
        {
            var context = c.Resolve<IComponentContext>();
            return viewModelTyp => (ViewModelBase) context.Resolve(viewModelTyp);
        });
    }

    public static void Initialize()
    {
        var builder = new ContainerBuilder();
        
        SetupConfigurator(builder);
        
        var resolver = builder.UseAutofacDependencyResolver();
        Locator.SetLocator(resolver);
        resolver.InitializeSplat();
        resolver.InitializeReactiveUI();
        
        Locator.CurrentMutable.RegisterConstant(new AvaloniaActivationForViewFetcher(), typeof(IActivationForViewFetcher));
        Locator.CurrentMutable.RegisterConstant(new AutoDataTemplateBindingHook(), typeof(IPropertyBindingHook));
        RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
        
        var container = builder.Build();
        resolver.SetLifetimeScope(container);
    }
}