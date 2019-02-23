using System;
using System.Runtime.CompilerServices;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VokabelTrainer3
{
    public partial class App : Application
    {
        private static IContainer _container;
        public IDirectoryService DirectoryService { get; }

        public App(IDirectoryService directoryService)
        {
            InitializeComponent();

            this.DirectoryService = directoryService;

            Container = ContainerConfig.Configure();

            MainPage = new NavigationPage(new WelcomePage());
        }

        public IContainer Container
        {
            get { return _container; }
            private set { _container = value; }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DirectoryService.CreateDirectoryHirarchy();
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
