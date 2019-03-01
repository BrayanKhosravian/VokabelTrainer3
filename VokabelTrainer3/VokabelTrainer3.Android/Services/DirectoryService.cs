using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private static bool _executed = false;

        internal void CreateDirectoryHirarchy()
        {
            if(_executed) return;

            this.CreateDirectory(Paths.RootPath);
            this.CreateDirectory(Paths.BasicVocabsPath);
            this.CreateDirectory(Paths.AdvancedVocabsPath);
            this.CreateDirectory(Paths.CustomVocabsPath);

            var basicVocabsPaths = Paths.GetBasicVocabsPaths;
            foreach (var path in basicVocabsPaths)
            {
                this.CreateDirectory(path);
            }

            _executed = true;
        }

        public string GetLastDirectoryName(string path)
        {
            string pattern = @"([ A-Z a-z 0-9 \-]+)";
            Regex regex = new Regex(pattern, RegexOptions.RightToLeft | RegexOptions.IgnorePatternWhitespace);

            string result = regex.Match(path).Value;
            return result;
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
    }
}