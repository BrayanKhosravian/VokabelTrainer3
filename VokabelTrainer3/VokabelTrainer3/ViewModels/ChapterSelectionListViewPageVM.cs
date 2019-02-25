using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<ChapterGroup> _data = new List<ChapterGroup>()
        {
            new ChapterGroup("GroupA", "Path")
            {
                new Chapter("Chapter1A", "Path"),
                new Chapter("Chapter2A", "Path")
            },
            new ChapterGroup("GroupB", "path")
            {
                new Chapter("Chapter1B", "Path"),
                new Chapter("Chapter2B", "Path")
            }
        };

        private readonly IPageService _pageService;

        public ChapterSelectionListViewPageVM(IPageService pageService)
        {
            _pageService = pageService;

            this.CreateChapters();
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
