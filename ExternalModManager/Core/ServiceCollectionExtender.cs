using System;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Wpf.Ui.Hardware;

namespace ExternalModManager.Core;

public static class ServiceCollectionExtender
{
    public static ViewBuilder AddView<TUserControl, TViewModel>(this IServiceCollection serviceCollection) where TViewModel : ReactiveObject where TUserControl : class
    {
        serviceCollection.AddTransient<TUserControl>();
        serviceCollection.AddSingleton<TViewModel>();

        return new ViewBuilder(serviceCollection, typeof(TUserControl), typeof(TViewModel));
    }
    
    public class ViewBuilder
    {
        private readonly IServiceCollection _serviceCollection;

        private readonly Type _userControl;

        private readonly Type _viewModel;

        public ViewBuilder(IServiceCollection serviceCollection, Type userControl, Type viewModel)
        {
            _serviceCollection = serviceCollection;
            _userControl = userControl;
            _viewModel = viewModel;
        }

        public IServiceCollection AsSingleton()
        {
            _serviceCollection.AddSingleton(_userControl);
            _serviceCollection.AddSingleton(_viewModel);

            return _serviceCollection;
        }
        
        public IServiceCollection AsTransient()
        {
            _serviceCollection.AddTransient(_userControl);
            _serviceCollection.AddTransient(_viewModel);

            return _serviceCollection;
        }
    }
}