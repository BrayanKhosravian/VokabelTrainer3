using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
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

        public VocabQuizPageVM(IVocabularyParserService vocabularyParserService)
        {
            _vocabularyParserService = vocabularyParserService;
        }

        public ICommand Command_Next => new Command(NextVocab);

        public void ConfgureData(string path)
        {
            _vocabs = _vocabularyParserService.GetRandomizedVocabDictionary(path);
            _selGermanVocabGroup = GetGermanVocabGroup(_routine);
            _selEnglishVocabGroup = GetEnglishVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroup.Vocab1 + _selGermanVocabGroup.Vocab2 + _selGermanVocabGroup.Vocab3;
        }

        private void NextVocab()
        {
            string input = this.InputEntry;
            bool isCorrect = this.CheckVocab(input);
            if (isCorrect)
            {
                this.StatsCorrectVocabs++;
            }
            else
            {
                this.StatsIncorrectVocabs++;
            }

            _routine++;
            this.SelectNextVocabs();
        }

        private void SelectNextVocabs()
        {
            _selEnglishVocabGroup = this.GetEnglishVocabGroup(_routine);
            _selGermanVocabGroup = this.GetGermanVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroup.Vocab1 + _selGermanVocabGroup.Vocab2 + _selGermanVocabGroup.Vocab3;
        }

        private bool CheckVocab(string input)
        {
            if (input == _selEnglishVocabGroup.Vocab1 || input == _selEnglishVocabGroup.Vocab2 ||
                input == _selEnglishVocabGroup.Vocab3)
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
