using Android.App;
using Android.Content.PM;
using Android.OS;
using VokabelTrainer3.Droid.Helpers;
using VokabelTrainer3.Droid.Services;

namespace VokabelTrainer3.Droid
{
    [Activity(Label = "VokabelTrainer3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            DirectoryService directoryService = new DirectoryService();
            directoryService.CreateDirectoryHirarchy();

            FileService fileService = new FileService(new TextFileParser());
            fileService.CreateTextFileHirarchy();

            App app = new App();
            app.ConfigureApplication(directoryService);

            LoadApplication(app);
        }
    }
}