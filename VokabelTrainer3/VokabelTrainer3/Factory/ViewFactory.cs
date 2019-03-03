using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;

namespace VokabelTrainer3.Factory
{
    class ViewFactory : IViewFactory
    {
        private readonly Dictionary<Type,Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Register<TViewModel, TView>()
            where TViewModel : BaseVM 
            where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public void Resolve<TViewModel>() 
            where TViewModel : BaseVM
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>();
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
        }


        public void ResolveWithParameter<TViewModel>(NamedParameter parameter)
            where TViewModel : BaseVM
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>(parameter);
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
        }

        public void ResolveWithParameters<TViewModel>(params Parameter[] parameters) 
            where TViewModel : BaseVM
        {
            if(parameters?.Length <= 0) throw new IndexOutOfRangeException();

            TViewModel viewModel = _componentContext.Resolve<TViewModel>(parameters);
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
        }

        private Page GetPage<TViewModel>() 
            where TViewModel : BaseVM
        {
            Type viewType = _map[typeof(TViewModel)];
            Page view = _componentContext.Resolve(viewType) as Page;
            return view;
        }
    }
}
