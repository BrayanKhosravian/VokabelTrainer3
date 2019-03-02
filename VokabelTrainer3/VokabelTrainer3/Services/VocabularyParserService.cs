using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;

namespace VokabelTrainer3.Services
{
    class VocabularyParserService : IVocabularyParserService
    {
        private Dictionary<EnglishVocabGroup, GermanVocabGroup> _vocabs = new Dictionary<EnglishVocabGroup, GermanVocabGroup>();

        public VocabularyParserService()
        {

        }

        public Dictionary<EnglishVocabGroup, GermanVocabGroup> GetRandomizedVocabDictionary(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!this.IsUsingFormat(line, "::")) continue;

                var englishVocabGroup = this.GetEnglishVocabGroup(line);
                var germanVocabGroup = this.GetGermanVocabGroup(line);
                _vocabs.Add(englishVocabGroup,germanVocabGroup);
            }

            this.RandomizeDictionary();
            return _vocabs;
        }

        private EnglishVocabGroup GetEnglishVocabGroup(string line)
        {

            var temp = line.Split("::".ToCharArray())[0];   // get left side of "::"
            var englishVocabs = temp.Split("/".ToCharArray());

            EnglishVocabGroup vocabGroup = new EnglishVocabGroup(englishVocabs);

            return vocabGroup;
        }

        private GermanVocabGroup GetGermanVocabGroup(string line)
        {

            var temp = line.Split("::".ToCharArray())[2];   // get right side of "::"
            var germanVocabs = temp.Split("/".ToCharArray());

            GermanVocabGroup vocabGroup = new GermanVocabGroup(germanVocabs);

            return vocabGroup as GermanVocabGroup;
        }

        private bool IsUsingFormat(string line, string match)
        {
            if (line.Contains(match) && !string.IsNullOrEmpty(line)) return true;
            return false;
        }

        private void RandomizeDictionary()
        {
            Random rand = new Random();
            _vocabs = _vocabs.OrderBy(x => rand.Next()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value); // kvp = KeyValuePair
        }
    }

}
