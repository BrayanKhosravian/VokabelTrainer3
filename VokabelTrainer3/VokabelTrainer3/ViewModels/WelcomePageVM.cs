using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Views;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class WelcomePageVM : BaseVM
    {
        private readonly IPageService _pageService;

        public ICommand Command_Options { get; set; }
        public ICommand Command_BasicVocabs { get; set; }
        public ICommand Command_AdvancedVocabs { get; set; }
        public ICommand Command_CustomVocabs { get; set; }
        public ICommand Command_Statistics { get; set; }

        public WelcomePageVM(IPageService pageService)
        {
            _pageService = pageService;

            Command_BasicVocabs = new Command(async () => await _pageService.NavigationPushAsync(new ChapterSelectionListViewPage()));
        }
    }
}
