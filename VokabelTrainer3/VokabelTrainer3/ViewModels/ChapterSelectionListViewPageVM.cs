using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand HeaderSelectedCommand { get; private set; }

        private readonly IPageService _pageService;

        public ChapterSelectionListViewPageVM(IPageService pageService)
        {
            _pageService = pageService;

            this.CreateChapters();

            HeaderSelectedCommand = new Command(async () => await _pageService.DisplayAlert("title", "header tapped", "ok"));
        }


        public void CreateChapters()
        {
            ChapterGroup group1 = new ChapterGroup("GroupA", "Path");
            group1.Add(new Chapter("Chapter1A", "Path"));
            group1.Add(new Chapter("Chapter2A", "Path"));

            ChapterGroup group2 = new ChapterGroup("GroupB", "path");
            group2.Add(new Chapter("Chapter1B", "Path"));
            group2.Add(new Chapter("Chapter2B", "Path"));

            Chapters.Add(group1);
            Chapters.Add(group2);
        }
        
        public void ExpandChapter()
        {

        }

        public void CollapsChapter(ChapterGroup group)
        {
            foreach (var chapter in Chapters)
            {
                if (chapter.GroupName == group.GroupName)
                {
                    Chapters.Remove(group);
                }
            }
        }


    }
}
