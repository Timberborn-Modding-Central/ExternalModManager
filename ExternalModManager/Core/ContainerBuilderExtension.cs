using Autofac;
using Avalonia.Controls;
using ReactiveUI;

namespace ExternalModManager.Core;

public static class ContainerBuilderExtension
{
    public static void RegisterView<TView, TViewModel>(this ContainerBuilder builder) where TView : UserControl where TViewModel : ViewModelBase
    {
        builder.RegisterType<TView>().As<IViewFor<TViewModel>>();
        builder.RegisterType<TViewModel>().AsSelf();
    }
}