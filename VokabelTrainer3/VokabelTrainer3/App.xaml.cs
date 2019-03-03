using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Services;
using VokabelTrainer3.ViewModels;
using VokabelTrainer3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VokabelTrainer3.Bootstrapper;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VokabelTrainer3
{
    public partial class App : Application
    {
        public App(IDirectoryService directoryService)
        {
            InitializeComponent();

            var bootstrapper = new Bootstrapper.Bootstrapper(this);
            bootstrapper.Load(directoryService);

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
