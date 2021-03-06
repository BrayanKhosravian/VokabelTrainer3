﻿using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using VokabelTrainer3.Exceptions;
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
            foreach (var kvp in _map)   // aggregate root pattern
            {
                if (kvp.Key == typeof(TViewModel) || kvp.Value == typeof(TView))
                {
                    this.ThrowDublicateViewRegisteredException();
                }
            }

            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Resolve<TViewModel>() 
            where TViewModel : BaseVM
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>();
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
            return view;
        }


        public Page ResolveWithParameter<TViewModel>(NamedParameter parameter)
            where TViewModel : BaseVM
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>(parameter);
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
            return view;
        }

        public Page ResolveWithParameters<TViewModel>(params Parameter[] parameters) 
            where TViewModel : BaseVM
        {
            if(parameters?.Length <= 0) throw new IndexOutOfRangeException();

            TViewModel viewModel = _componentContext.Resolve<TViewModel>(parameters);
            Page view = GetPage<TViewModel>();

            view.BindingContext = viewModel;
            return view;
        }

        private Page GetPage<TViewModel>() 
            where TViewModel : BaseVM
        {
            Type viewType = _map[typeof(TViewModel)];
            Page view = _componentContext.Resolve(viewType) as Page;
            return view;
        }

        private void ThrowDublicateViewRegisteredException()
        {
            throw new DublicateViewRegisteredException("You accidentally registered a already registered View or ViewModel \n" +
                                                       "Cannot register a already Registered View or ViewModel of the same type");
        }
    }
}
