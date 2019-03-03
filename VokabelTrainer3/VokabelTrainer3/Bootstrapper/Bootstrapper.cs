using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using VokabelTrainer3.Bootstrapper.Modules;
using VokabelTrainer3.Factory;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.ViewModels;
using VokabelTrainer3.Views;
using Xamarin.Forms;

namespace VokabelTrainer3.Bootstrapper
{
    public class Bootstrapper
    {
        private readonly App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        /// <summary>
        /// pass objects from Android/IOS/UWP namespaces to this method in order to register them!
        /// </summary>
        /// <param name="directoryService"></param>
        public void Load(IDirectoryService directoryService)
        {
            var builder = new ContainerBuilder();

            // Register runtime instances
            builder.RegisterInstance(directoryService).As<IDirectoryService>();

            // register modules
            builder.RegisterModule<PageModule>();
            builder.RegisterModule<ServiceModule>();

            // register types
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            IContainer container = builder.Build();

            // register viewFactory
            var viewFactory = container.Resolve<IViewFactory>();
            viewFactory.Register<WelcomePageVM, WelcomePage>();
            viewFactory.Register<QuizPageVM, QuizPage>();
            viewFactory.Register<ChapterSelectionLVPageVM, ChapterSelectionLVPage>();
            viewFactory.Register<DisplayVocabsLVPageVM, DisplayVocabsLVPage>();

            // configure application
            var mainPage = viewFactory.Resolve<WelcomePageVM>();
            var navigationPage = new NavigationPage(mainPage);
            _app.MainPage = navigationPage;

        }
    }
}
