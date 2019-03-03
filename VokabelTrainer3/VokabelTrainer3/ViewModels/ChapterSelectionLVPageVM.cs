﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using VokabelTrainer3.Services;
using VokabelTrainer3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace VokabelTrainer3.ViewModels
{
    class ChapterSelectionLVPageVM : BaseVM
    {
        public ObservableCollection<ChapterGroup> Chapters { get; private set; } = new ObservableCollection<ChapterGroup>();
        private readonly List<ChapterGroup> _data = new List<ChapterGroup>();
        // comment is to provide a knowledge on how _data looks like
        //private readonly List<ChapterGroup> _data = new List<ChapterGroup>()
        //{
        //    new ChapterGroup("GroupA", "Path")
        //    {
        //        new Chapter("Chapter1A", "Path"),
        //        new Chapter("Chapter2A", "Path")
        //    },
        //    new ChapterGroup("GroupB", "path")
        //    {
        //        new Chapter("Chapter1B", "Path"),
        //        new Chapter("Chapter2B", "Path")
        //    }
        //};    

        private readonly INavigatorService _navigatorService;
        private readonly IDirectoryService _directoryService;
        private readonly string _path;

        public ChapterSelectionLVPageVM(INavigatorService navigatorService, IDirectoryService directoryService, string path)
        {
            _navigatorService = navigatorService;
            _directoryService = directoryService;
            _path = path;
        }

        public ICommand GroupSelectedCommand
        {
            get
            {
                return new Command<string>(groupName =>
                {
                    int index = LookUp(groupName);
                    if (_data[index].IsSelected)
                    {
                        this.DeselectAll();
                        _data[index].IsSelected = false;
                    }
                    else
                    {
                        this.DeselectAll();
                        _data[index].IsSelected = true;
                    }
                    this.CreateChapters();
                });
            }

        }

        public ICommand ChapterSelectedCommand => new Command<string>(async chapterPath =>
        {
            await _navigatorService.PushWithParameterAsync<QuizPageVM>(new NamedParameter("chapterPath" , chapterPath));
        });

        public void CreateData()
        {
            _data.Clear();
            var directories = Directory.GetDirectories(_path);
            foreach (var directory in directories)
            {
                var chapterGroup = new ChapterGroup(_directoryService.GetLastDirectoryName(directory), directory);
                var chapters = Directory.GetFiles(directory);
                foreach (var chapter in chapters)
                {
                    chapterGroup.Add(new Chapter(Path.GetFileName(chapter), chapter));
                }
                _data.Add(chapterGroup);
            }

        }

        public void CreateChapters()
        {
            Chapters.Clear();
            int i = 0;
            foreach (var group in _data)
            {
                if (group.IsSelected)   // expand
                {
                    Chapters.Add(group);
                }
                else                    // collapse
                {
                    Chapters.Add(new ChapterGroup(group.GroupName, group.GroupPath));
                }
                i++;
            }
        }

        private int LookUp(string groupName)
        {
            foreach (var group in Chapters)
            {
                if (group.GroupName == groupName)
                {
                    return Chapters.IndexOf(group);
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        private void DeselectAll()
        {
            foreach (var group in Chapters)
            {
                group.IsSelected = false;
            }
        }

    }
}