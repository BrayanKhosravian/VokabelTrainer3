using System;
using System.Runtime.CompilerServices;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Services;
using VokabelTrainer3.ViewModels;
using VokabelTrainer3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VokabelTrainer3
{
    public partial class App : Application
    {
        public App(IDirectoryService directoryService, IFileService fileService)
        {
            InitializeComponent();

            this.ContainerBootstrapper(directoryService, fileService);

            MainPage = new NavigationPage(new WelcomePage());
        }

        void ContainerBootstrapper(IDirectoryService directoryService, IFileService fileService)
        {
            ContainerBuilder builder = new ContainerBuilder();

            // viewmodel registration
            builder.RegisterType<WelcomePageVM>();
            builder.RegisterType<ChapterSelectionListViewPageVM>();
            builder.RegisterType<VocabQuizPageVM>();

            // register services
            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<VocabularyParserService>().As<IVocabularyParserService>();

            // register runtime instances
            builder.RegisterInstance(directoryService).As<IDirectoryService>();
            builder.RegisterInstance(fileService).As<IFileService>();

            ViewModelLocator.SetContainerProvider(builder.Build());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
