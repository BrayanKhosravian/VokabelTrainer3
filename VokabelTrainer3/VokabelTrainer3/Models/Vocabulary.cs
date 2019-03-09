
namespace VokabelTrainer3.Models
{
    public class Vocabulary
    {
        public string EnglishVocabModel { get; private set; }
        public string GermanVocabModel { get; private set; }

        public Vocabulary(string englishVocabModel, string germanVocabModel)
        {
            EnglishVocabModel = englishVocabModel;
            GermanVocabModel = germanVocabModel;
        }

    }
}
