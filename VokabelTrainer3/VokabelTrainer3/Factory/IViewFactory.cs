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

        Page Resolve<TViewModel>() 
            where TViewModel : BaseVM;

        Page ResolveWithParameter<TViewModel>(NamedParameter parameter) 
            where TViewModel : BaseVM;

        Page ResolveWithParameters<TViewModel>(params Parameter[] parameters)
            where TViewModel : BaseVM;
    }
}
