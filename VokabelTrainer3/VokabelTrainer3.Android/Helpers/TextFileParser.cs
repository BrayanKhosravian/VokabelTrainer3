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
using VokabelTrainer3.Droid.Interfaces;

namespace VokabelTrainer3.Droid.Helpers
{
    class TextFileParser : ITextFileParser
    {
        public bool PathContainsBasic(string path)
        {
            if (this.Match(path, "Basic")) return true;
            return false;
        }

        public bool PathContainsAdvanced(string path)
        {
            if (this.Match(path, "Advanced")) return true;
            return false;
        }

        public bool PathContainsCustom(string path)
        {
            if (this.Match(path, "Custom")) return true;
            return false;
        }

        public string GetFileNameFromResource(string path)
        {
            string pattern = @"([ A-Z a-z 0-9 \-]+)\.txt";
            Regex regex = new Regex(pattern, RegexOptions.RightToLeft | RegexOptions.IgnorePatternWhitespace); 

            string result = regex.Match(path).Value;
            return result;
        }

        private bool Match(string path, string match)
        {
            if (path.StartsWith("VokabelTrainer3.Vokabeln." + match) && this.IsTextFile(path)) return true;
            return false;
        }

        private bool IsTextFile(string path)
        {
            if (path.EndsWith(".txt")) return true;
            return false;
        }
    }
}