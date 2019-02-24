using System;
using System.Runtime.CompilerServices;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.ViewModels;
using VokabelTrainer3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VokabelTrainer3
{
    public partial class App : Application
    {
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public App(IDirectoryService directoryService, IFileService fileService)
        {
            InitializeComponent();

            _directoryService = directoryService;
            _fileService = fileService;

            this.ContainerBootstrapper();

            MainPage = new NavigationPage(new WelcomePage());
        }

        void ContainerBootstrapper()
        {
            ViewModelLocator.SetContainerProvider(ContainerConfig.Configure());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            _directoryService.CreateDirectoryHirarchy();
            _fileService.CreateTextFileHirarchy();
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
