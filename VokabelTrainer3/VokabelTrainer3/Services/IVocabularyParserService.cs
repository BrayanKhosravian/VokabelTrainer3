using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModels;

namespace VokabelTrainer3.Services
{
    interface IVocabularyParserService
    {
        Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO> GetRandomizedVocabDictionary(string path);
        ObservableCollection<Vocabulary> GetVocabularyForView(string path);
    }
}

