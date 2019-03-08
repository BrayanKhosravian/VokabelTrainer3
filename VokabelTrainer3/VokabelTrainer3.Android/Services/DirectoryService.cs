using System.IO;
using System.Text.RegularExpressions;
using VokabelTrainer3.Interfaces;

namespace VokabelTrainer3.Droid.Services
{
    public class DirectoryService : IDirectoryService
    {
        private static bool _executed = false;

        internal void CreateDirectoryHirarchy()
        {
            if(_executed) return;

            var allPaths = Paths.AllPaths;
            foreach (var path in allPaths)
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