using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VokabelTrainer3.Droid.Helpers;
using VokabelTrainer3.Droid.Interfaces;
using VokabelTrainer3.Interfaces;

namespace VokabelTrainer3.Droid.Services
{
    class FileService : IFileService
    {
        private readonly Assembly _assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
        private readonly ITextFileParser _textFileParser;

        public FileService(ITextFileParser textFileParser)
        {
            _textFileParser = textFileParser;

        }

        public void CreateTextFileHirarchy()
        {
            foreach (var resource in _assembly.GetManifestResourceNames())
            {
                if (_textFileParser.PathContainsBasic(resource))
                {
                    var fileName = _textFileParser.GetFileName(resource);
                    this.ResourceWriter(Paths.BasicVocabsPath, resource);
                }
                else if (_textFileParser.PathContainsAdvanced(resource))
                {
                    var fileName = _textFileParser.GetFileName(resource);
                    this.ResourceWriter(Paths.AdvancedVocabsPath, resource);
                }
                else if (_textFileParser.PathContainsCustom(resource))
                {
                    var fileName = _textFileParser.GetFileName(resource);
                    this.ResourceWriter(Paths.CustomVocabsPath, resource);
                }
            }

        }

        private void ResourceWriter(string path, string resourcePath)
        {
            File.WriteAllText(path, ResourceReader(resourcePath));
        }

        private string ResourceReader(string resource)
        {
            Stream stream = _assembly.GetManifestResourceStream(resource);
            using (var reader = new System.IO.StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}