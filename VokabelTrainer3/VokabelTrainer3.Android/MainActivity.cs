using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using VokabelTrainer3.Droid.Helpers;
using VokabelTrainer3.Droid.Interfaces;
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

            DirectoryService directoryService = new DirectoryService();
            directoryService.CreateDirectoryHirarchy();

            FileService fileService = new FileService(new TextFileParser());
            fileService.CreateTextFileHirarchy();

            LoadApplication(new App(directoryService));
        }
    }
}