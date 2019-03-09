using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModels;
using VokabelTrainer3.Services;
using Xamarin.Forms;

namespace VokabelTrainer3.ViewModels
{
    class QuizPageVM : BaseVM
    {
        public string Title => Path.GetFileName(_chapterPath);

        private Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO> _vocabs = new Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO>();
        private List<Vocabulary> _wrongVocabs = new List<Vocabulary>();
        private EnglishVocabGroupDTO _selEnglishVocabGroupDto;
        private GermanVocabGroupDTO _selGermanVocabGroupDto;

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
            _selGermanVocabGroupDto = GetGermanVocabGroup(_routine);
            _selEnglishVocabGroupDto = GetEnglishVocabGroup(_routine);
            this.OutputLabel = _selGermanVocabGroupDto.ToString();
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
            string input = this.InputEntry;

            InputState inputState = this.CheckInput(input);

            switch (inputState)
            {
                case InputState.NullOrEmpty:
                    bool isSkipping = await _pageService.DisplayAlert(" Status", " Your input is empty! \n Do you want to skip?", "YES", "NO");
                    if (!isSkipping) return;

                    await _pageService.DisplayAlert(" Status", $" The correct vocab should be: \n\n {_selEnglishVocabGroupDto.ToString()}", "OK");
                    this.StatsIncorrectVocabs++;
                    _wrongVocabs.Add(new Vocabulary(_selEnglishVocabGroupDto.ToString(), _selGermanVocabGroupDto.ToString()));
                    break;

                case InputState.Correct:
                    await _pageService.DisplayAlert(" Status", " The input is correct!", "ok");
                    this.StatsCorrectVocabs++;
                    break;

                case InputState.Incorrect:
                    await _pageService.DisplayAlert(" Status", $" The input was wrong! \n It should be: \n\n {_selEnglishVocabGroupDto.ToString()}", "OK");
                    this.StatsIncorrectVocabs++;
                    _wrongVocabs.Add(new Vocabulary(_selEnglishVocabGroupDto.ToString(), _selGermanVocabGroupDto.ToString()));
                    break;
            }

            await this.SelectNextVocabs();
            this.OutputLabel = _selGermanVocabGroupDto.ToString();

        }

        private InputState CheckInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return InputState.NullOrEmpty;
            else if (_selEnglishVocabGroupDto.Any(x => x == input)) return InputState.Correct;
            else return InputState.Incorrect;
        }

        private async Task SelectNextVocabs()
        {
            _routine++;
            if (_routine >= _vocabs.Count)
            {
                await _pageService.DisplayAlert("Status", "You completed the quiz!", "ok");
                await _navigatorService.PushWithParametersAsync<DisplayVocabsLVPageVM>(new NamedParameter("vocabs", _wrongVocabs));
            }
            _selEnglishVocabGroupDto = this.GetEnglishVocabGroup(_routine);
            _selGermanVocabGroupDto = this.GetGermanVocabGroup(_routine);

            this.InputEntry = "";
            this.StatsFinishedVocabs++;
        }

        private EnglishVocabGroupDTO GetEnglishVocabGroup(int elementAt)
        {
            EnglishVocabGroupDTO vocabGroupDto = _vocabs.ElementAt(elementAt).Key;
            return vocabGroupDto;
        }

        private GermanVocabGroupDTO GetGermanVocabGroup(int elementAt)
        {
            GermanVocabGroupDTO vocabGroupDto = _vocabs.ElementAt(elementAt).Value;
            return vocabGroupDto;
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
