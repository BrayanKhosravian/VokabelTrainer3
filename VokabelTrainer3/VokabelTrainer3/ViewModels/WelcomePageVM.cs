using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Autofac;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Services;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    public class WelcomePageVM : BaseVM
    {
        private readonly INavigatorService _navigatorService;

        public WelcomePageVM(INavigatorService navigatorService)
        {
            _navigatorService = navigatorService;
        }

        public ICommand Command_Options { get; }

        public ICommand Command_BasicVocabs    => new Command<string>(ToChapterSelectionListView);
        public ICommand Command_AdvancedVocabs => new Command<string>(ToChapterSelectionListView);
        public ICommand Command_CustomVocabs   => new Command<string>(ToChapterSelectionListView, canExecute => false);

        public ICommand Command_Statistics { get; }

        private async void ToChapterSelectionListView(string path)
        {
            await _navigatorService.PushWithParameterAsync<ChapterSelectionLVPageVM>(new NamedParameter("path", path));
        }
    }
}
