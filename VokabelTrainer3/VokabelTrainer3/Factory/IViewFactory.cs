using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Autofac;
using Autofac.Core;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;

namespace VokabelTrainer3.Factory
{
    interface IViewFactory
    {
        void Register<TViewModel, TView>()
            where TViewModel : BaseVM
            where TView : Page;

        void Resolve<TViewModel>() 
            where TViewModel : BaseVM;

        void ResolveWithParameter<TViewModel>(NamedParameter parameter) 
            where TViewModel : BaseVM;

        void ResolveWithParameters<TViewModel>(params Parameter[] parameters)
            where TViewModel : BaseVM;
    }
}
