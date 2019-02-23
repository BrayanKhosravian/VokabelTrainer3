using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using VokabelTrainer3.Droid.Helpers;
using VokabelTrainer3.Droid.Services;
using VokabelTrainer3.Interfaces;

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

            IDirectoryService directoryService = new DirectoryService();
            IFileService fileService = new FileService(new TextFileParser());

            LoadApplication(new App(directoryService, fileService));
        }
    }
}