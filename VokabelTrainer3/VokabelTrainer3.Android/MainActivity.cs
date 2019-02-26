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

            IDirectoryService directoryService = new DirectoryService();
            directoryService.CreateDirectoryHirarchy();

            IFileService fileService = new FileService(new TextFileParser());
            fileService.CreateTextFileHirarchy();

            //Dictionary<Type,Type> map = new Dictionary<Type, Type>(){};
            //map.Add(typeof(DirectoryService), typeof(IDirectoryService));
            //map.Add(typeof(TextFileParser), typeof(ITextFileParser));
            //map.Add(typeof(FileService),typeof(IFileService));

            LoadApplication(new App(directoryService, fileService));
        }
    }
}