using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Services;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;

namespace VokabelTrainer3
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            // viewmodel registration
            builder.RegisterType<WelcomePageVM>();
            builder.RegisterType<ChapterSelectionListViewPageVM>();

            // register services
            builder.RegisterType<PageService>().As<IPageService>();

            return builder.Build();
        }
    }
}
