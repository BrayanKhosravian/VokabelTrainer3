using System.Collections.Generic;
using System.Collections.ObjectModel;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModels;

namespace VokabelTrainer3.Services
{
    interface IVocabularyParserService
    {
        Dictionary<EnglishVocabGroup, GermanVocabGroup> GetRandomizedVocabDictionary(string path);
        ObservableCollection<Vocabulary> GetVocabularyForView(string path);

        string FormatVocabForQuiz(string vocab);
    }
}

