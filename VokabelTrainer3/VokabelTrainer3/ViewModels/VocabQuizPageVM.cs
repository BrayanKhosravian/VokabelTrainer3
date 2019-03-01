using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using VokabelTrainer3.Services;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class VocabQuizPageVM : BaseVM
    {
        private Dictionary<EnglishVocabGroup, GermanVocabGroup> _vocabs = new Dictionary<EnglishVocabGroup, GermanVocabGroup>();
        private EnglishVocabGroup _selEnglishVocabGroup;
        private GermanVocabGroup _selGermanVocabGroup;

        private int _routine = 0;

        private string _outputLabel;
        private string _inputEntry;
        private int _statsTotalVocabs;
        private int _statsFinishedVocabs;
        private int _statsCorrectVocabs;
        private int _statsIncorrectVocabs;

        private readonly IVocabularyParserService _vocabularyParserService;
        private readonly IPageService _pageService;

        public VocabQuizPageVM(IVocabularyParserService vocabularyParserService, IPageService pageService)
        {
            _vocabularyParserService = vocabularyParserService;
            _pageService = pageService;
        }

        public ICommand Command_Next => new Command(async () => await NextVocab());

        public void ConfgureViewModel(string path)
        {
            _vocabs = _vocabularyParserService.GetRandomizedVocabDictionary(path);
            _selGermanVocabGroup = GetGermanVocabGroup(_routine);
            _selEnglishVocabGroup = GetEnglishVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroup.Vocab1 + _selGermanVocabGroup.Vocab2 + _selGermanVocabGroup.Vocab3;
            this.StatsTotalVocabs = _vocabs.Count;
        }

        private async Task NextVocab()
        {
            this.CheckVocab();
            _routine++;
            await this.SelectNextVocabs();

            // 1.) check input is null if true make DisplayAlert and return
            // 2.) check if input matches one of each vocabs (replace spaces)
            // 3.) increment _routine
            // 4.) check if all vocabs finished (if yes navigate to root page) (maybe save to database)
            // 5.) select next vocabs


        }

        private void CheckVocab()
        {
            string input = this.InputEntry;
            bool isCorrect = this.IsVocabCorrect(input);
            if (isCorrect)
            {
                this.StatsCorrectVocabs++;
            }
            else
            {
                this.StatsIncorrectVocabs++;
            }
        }

        private async Task SelectNextVocabs()
        {
            if (_routine >= _vocabs.Count)
            {
                await _pageService.DisplayAlert("Status", "You completed the quiz!", "ok");
                return;
            }
            _selEnglishVocabGroup = this.GetEnglishVocabGroup(_routine);
            _selGermanVocabGroup = this.GetGermanVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroup.Vocab1 + _selGermanVocabGroup.Vocab2 + _selGermanVocabGroup.Vocab3;
        }

        private bool IsVocabCorrect(string input)
        {
            string vocab1, vocab2, vocab3;

            vocab1 = _selEnglishVocabGroup.Vocab1?.Replace(" ", "");
            vocab2 = _selEnglishVocabGroup.Vocab2?.Replace(" ", "");
            vocab3 = _selEnglishVocabGroup.Vocab3?.Replace(" ", "");

            if ((bool)vocab1?.Contains(input) || (bool)vocab2?.Contains(input) || (bool)vocab3?.Contains(input))
            {
                return true;
            }

            return false;
        }
        

        private EnglishVocabGroup GetEnglishVocabGroup(int elementAt)
        {
            EnglishVocabGroup vocabGroup = _vocabs.ElementAt(elementAt).Key;
            return vocabGroup;
        }

        private GermanVocabGroup GetGermanVocabGroup(int elementAt)
        {
            GermanVocabGroup vocabGroup = _vocabs.ElementAt(elementAt).Value;
            return vocabGroup;
        }

        #region I/O Properties

        public string OutputLabel
        {
            get => _outputLabel;
            set => base.SetProperty(ref _outputLabel, value);
        }

        public string InputEntry
        {
            get => _inputEntry;
            set => base.SetProperty(ref _inputEntry, value);
        }

        #endregion

        #region Statistics Output Properties

        public int StatsTotalVocabs
        {
            get => _statsTotalVocabs;
            private set => base.SetProperty(ref _statsTotalVocabs, value);
        }

        public int StatsFinishedVocabs
        {
            get => _statsFinishedVocabs;
            private set => base.SetProperty(ref _statsFinishedVocabs, value);
        }

        public int StatsCorrectVocabs
        {
            get => _statsCorrectVocabs;
            private set => base.SetProperty(ref _statsCorrectVocabs, value);
        }

        public int StatsIncorrectVocabs
        {
            get => _statsIncorrectVocabs;
            private set => base.SetProperty(ref _statsIncorrectVocabs, value);
        }

        #endregion
    }
}
