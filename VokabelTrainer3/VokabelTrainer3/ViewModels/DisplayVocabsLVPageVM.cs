using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using VokabelTrainer3.Services;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class DisplayVocabsLVPageVM : BaseVM
    {
        public string Title => _directoryService.GetLastDirectoryName(_chapterPath);
        public ObservableCollection<Vocabulary> Vocabs { get; private set; }

        private readonly INavigatorService _navigatorService;
        private readonly IVocabularyParserService _vocabularyParserService;
        private readonly IDirectoryService _directoryService;
        private readonly string _chapterPath;

        public DisplayVocabsLVPageVM(INavigatorService navigatorService, IDirectoryService directoryService, List<Vocabulary> vocabs = null)
        {
            _navigatorService = navigatorService;
            _directoryService = directoryService;
           if(vocabs?.Count > 0)
               Vocabs = new ObservableCollection<Vocabulary>(vocabs);
        }

        public DisplayVocabsLVPageVM(INavigatorService navigatorService,IVocabularyParserService vocabularyParserService, IDirectoryService directoryService, string chapterPath = null)
        {
            _navigatorService = navigatorService;
            _vocabularyParserService = vocabularyParserService;
            _directoryService = directoryService;
            _chapterPath = chapterPath;
            if(!string.IsNullOrEmpty(chapterPath))
                Vocabs = new ObservableCollection<Vocabulary>(_vocabularyParserService.GetVocabularyForView(chapterPath));
        }

        public ICommand CancelCommand => new Command(async () => await _navigatorService.PopToRootAsync());

       

    }
}
