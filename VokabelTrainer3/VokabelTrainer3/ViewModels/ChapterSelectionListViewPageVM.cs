using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class ChapterSelectionListViewPageVM : BaseVM
    {
        public ObservableCollection<ChapterGroup> Chapters { get; private set; } = new ObservableCollection<ChapterGroup>();
        private readonly List<ChapterGroup> _data = new List<ChapterGroup>();
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

        private readonly IPageService _pageService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public ChapterSelectionListViewPageVM(IPageService pageService, IDirectoryService directoryService, IFileService fileService)
        {
            _pageService = pageService;
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public ICommand HeaderSelectedCommand
        {
            get
            {
                return new Command<string>(groupName =>
                {
                    int index = LookUp(groupName);
                    if (_data[index].IsSelected)
                    {
                        _data[index].IsSelected = false;
                    }
                    else
                    {
                        _data[index].IsSelected = true;
                    }
                    this.CreateChapters();
                });
            }

        }

        public void CreateData(string path)
        {
            var directories = Directory.GetDirectories(path);
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

        public int LookUp(string groupName)
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

        public void ExpandChapter()
        {

        }

        public void CollapsChapter(ChapterGroup group)
        {
            
        }


    }
}
