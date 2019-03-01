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
            EnglishVocabGroup vocabGroup = new EnglishVocabGroup();

            var temp = line.Split("::".ToCharArray())[0];   // get left side of "::"
            var englishVocabs = temp.Split("/".ToCharArray());

            this.ConfigureVocabGroup(vocabGroup, englishVocabs);
            return vocabGroup;
        }

        private GermanVocabGroup GetGermanVocabGroup(string line)
        {
            GermanVocabGroup vocabGroup = new GermanVocabGroup();

            var temp = line.Split("::".ToCharArray())[2];   // get right side of "::"
            var germanVocabs = temp.Split("/".ToCharArray());

            this.ConfigureVocabGroup(vocabGroup, germanVocabs);

            return vocabGroup;
        }

        private void ConfigureVocabGroup(Vocab vocabGroup, string[] vocabs)
        {
           
            if (vocabs.Length >= 1) if (!string.IsNullOrEmpty(vocabs[0])) vocabGroup.Vocab1 = vocabs[0];
            if (vocabs.Length >= 2) if (!string.IsNullOrEmpty(vocabs[1])) vocabGroup.Vocab1 = vocabs[1];
            if (vocabs.Length >= 3) if (!string.IsNullOrEmpty(vocabs[2])) vocabGroup.Vocab3 = vocabs[2];
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
