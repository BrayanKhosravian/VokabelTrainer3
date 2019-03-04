using System;
using System.Collections.Generic;
using System.Text;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModelsDTO;

namespace VokabelTrainer3.Services
{
    interface IVocabularyParserService
    {
        Dictionary<EnglishVocabGroup, GermanVocabGroup> GetRandomizedVocabDictionary(string path);
    }
}

