﻿using System;
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
                if (_textFileParser.PathContains(resource, "Basic"))
                {
                    if (_textFileParser.PathContains(resource, "At the hotel"))
                    {
                        this.ResourceWriter(Paths.AtTheHotel, resource);
                    }
                    else if (_textFileParser.PathContains(resource, "Car rental"))
                    {
                        this.ResourceWriter(Paths.CarRental, resource);
                    }
                    else if (_textFileParser.PathContains(resource, "Getting started"))
                    {
                        this.ResourceWriter(Paths.GettingStarted,resource);
                    }
                    else if (_textFileParser.PathContains(resource, "The journey"))
                    {
                        this.ResourceWriter(Paths.TheJourney, resource);
                    }
                    else if (_textFileParser.PathContains(resource, "Travelling abroad"))
                    {
                        this.ResourceWriter(Paths.TravellingAbroad, resource);
                    }
                }
                else if (_textFileParser.PathContains(resource, "Advanced"))
                {
                    this.ResourceWriter(Paths.AdvancedVocabsPath, resource);
                }
                else if (_textFileParser.PathContains(resource, "Custom"))
                {
                    this.ResourceWriter(Paths.CustomVocabsPath, resource);
                }
            }

        }

        public string[] GetFilesPaths(string path)
        {
            var files = Directory.GetFiles(path);
            return files;
        }

        private void ResourceWriter(string path, string resource)
        {
            var fileName = _textFileParser.GetFileNameFromResource(resource);
            var concretePath = Path.Combine(path, fileName);
            string text = ResourceReader(resource);
            File.WriteAllText(concretePath, text);
        }

        private string ResourceReader(string resource)
        {
            using (Stream stream = _assembly.GetManifestResourceStream(resource))
            using (var reader = new System.IO.StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}