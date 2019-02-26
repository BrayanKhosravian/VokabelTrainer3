using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VokabelTrainer3.Interfaces;

namespace VokabelTrainer3.Droid.Services
{
    public class DirectoryService : IDirectoryService
    {
        public void CreateDirectoryHirarchy()
        {
            this.CreateDirectory(Paths.RootPath);
            this.CreateDirectory(Paths.BasicVocabsPath);
            this.CreateDirectory(Paths.AdvancedVocabsPath);
            this.CreateDirectory(Paths.CustomVocabsPath);

            var basicVocabsPaths = Paths.GetBasicVocabsPaths;
            foreach (var path in basicVocabsPaths)
            {
                this.CreateDirectory(path);
            }
        }

        public string[] GetDirectoriesPaths(string path)
        {
            var directories = Directory.GetDirectories(path);
            return directories;
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
    }
}