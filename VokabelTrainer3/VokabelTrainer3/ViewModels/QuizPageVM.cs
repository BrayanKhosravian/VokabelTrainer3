using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModelsDTO;
using VokabelTrainer3.Services;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class QuizPageVM : BaseVM
    {
        private Dictionary<EnglishVocabGroup, GermanVocabGroup> _vocabs = new Dictionary<EnglishVocabGroup, GermanVocabGroup>();
        private Dictionary<EnglishVocabGroup, GermanVocabGroup> _wrongVocabs = new Dictionary<EnglishVocabGroup, GermanVocabGroup>();
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
        private readonly INavigatorService _navigatorService;
        private readonly IPageService _pageService;
        private readonly string _chapterPath;

        public QuizPageVM(IVocabularyParserService vocabularyParserService, INavigatorService navigatorService, IPageService pageService, string chapterPath)
        {
            _navigatorService = navigatorService;
            _vocabularyParserService = vocabularyParserService;
            _pageService = pageService;
            _chapterPath = chapterPath;
        }

        public ICommand Command_Next => new Command(async () => await NextVocab());

        public void ConfgureViewModel()
        {
            _vocabs = _vocabularyParserService.GetRandomizedVocabDictionary(_chapterPath);
            _selGermanVocabGroup = GetGermanVocabGroup(_routine);
            _selEnglishVocabGroup = GetEnglishVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroup.ToString();
            this.StatsTotalVocabs = _vocabs.Count;
        }


        // 1.) check input is null if true make DisplayAlert and return
        // 2.) check if input matches one of each vocabs (replace spaces)
        // 3.) increment _routine
        // 4.) check if all vocabs finished (if yes navigate to root page) (maybe save to database)
        // 5.) select next vocabs

        private enum InputState { Correct, Incorrect, NullOrEmpty }

        private async Task NextVocab()
        {
            string input = this.InputEntry?.ToLower().Replace(" ", "");

            InputState inputState = this.CheckInput(input);

            switch (inputState)
            {
                case InputState.NullOrEmpty:
                    bool isSkipping = await _pageService.DisplayAlert(" Status", " Your input is empty! \n Do you want to skip?", "YES", "NO");
                    if (!isSkipping) return;
                    await _pageService.DisplayAlert(" Status", $" The correct vocab should be: \n\n {_selEnglishVocabGroup.ToString()}", "OK");
                    this.StatsIncorrectVocabs++;
                    break;

                case InputState.Correct:
                    await _pageService.DisplayAlert(" Status", " The input is correct!", "ok");
                    this.StatsCorrectVocabs++;
                    break;

                case InputState.Incorrect:
                    await _pageService.DisplayAlert(" Status", $" The input was wrong! \n It should be: \n\n {_selEnglishVocabGroup.ToString()}", "OK");
                    this.StatsIncorrectVocabs++;
                    break;
            }

            await this.SelectNextVocabs();
            this.OutputLabel = _selGermanVocabGroup.ToString();

        }

        private InputState CheckInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return InputState.NullOrEmpty;
            else if (_selEnglishVocabGroup.Any(x => x == input)) return InputState.Correct;
            else return InputState.Incorrect;
        }

        private async Task SelectNextVocabs()
        {
            _routine++;
            if (_routine >= _vocabs.Count)
            {
                await _pageService.DisplayAlert("Status", "You completed the quiz!", "ok");
                await _navigatorService.PopToRootAsync();
            }
            _selEnglishVocabGroup = this.GetEnglishVocabGroup(_routine);
            _selGermanVocabGroup = this.GetGermanVocabGroup(_routine);

            this.InputEntry = "";
            this.StatsFinishedVocabs++;
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
