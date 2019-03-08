using VokabelTrainer3.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VokabelTrainer3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        public void ConfigureApplication(IDirectoryService directoryService)
        {
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
