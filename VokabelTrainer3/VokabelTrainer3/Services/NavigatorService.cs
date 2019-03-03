using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using VokabelTrainer3.Factory;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;

namespace VokabelTrainer3.Services
{
    class NavigatorService : INavigatorService
    {
        private readonly IViewFactory _viewFactory;
        private readonly Lazy<INavigation> _navigation;

        public NavigatorService(IViewFactory viewFactory, Lazy<INavigation> navigation)
        {
            _viewFactory = viewFactory;
            _navigation = navigation;
        }

        private INavigation Navigation => _navigation.Value;

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>() where TViewModel : BaseVM
        {
            Page view = _viewFactory.Resolve<TViewModel>();
            await Navigation.PushAsync(view);
        }

        public async Task PushWithParameterAsync<TViewModel>(NamedParameter parameter) where TViewModel : BaseVM
        {
            Page view = _viewFactory.ResolveWithParameter<TViewModel>(parameter);
            await Navigation.PushAsync(view);
        }

        public async Task PushWithParametersAsync<TViewModel>(params Parameter[] parameters) where TViewModel : BaseVM
        {
            Page view = _viewFactory.ResolveWithParameters<TViewModel>(parameters);
            await Navigation.PushAsync(view);
        }

    }
}
