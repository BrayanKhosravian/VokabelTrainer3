using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VokabelTrainer3.Interfaces;
using VokabelTrainer3.Models;
using VokabelTrainer3.ServiceModels;

namespace VokabelTrainer3.Services
{
    class VocabularyParserService : IVocabularyParserService
    {
        private Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO> _vocabs = new Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO>();

        public VocabularyParserService()
        {

        }

        public Dictionary<EnglishVocabGroupDTO, GermanVocabGroupDTO> GetRandomizedVocabDictionary(string path)
        {
            CreateDictionaryFromFile(path);
            this.RandomizeDictionary();
            return _vocabs;
        }

        public ObservableCollection<Vocabulary> GetVocabularyForView(string path)
        {
            ObservableCollection<Vocabulary> outputCollection = new ObservableCollection<Vocabulary>();

            var dictionary = this.GetRandomizedVocabDictionary(path);

            foreach (var kvp in dictionary)
            {
                outputCollection.Add(new Vocabulary(kvp.Key.ToString(), kvp.Value.ToString()));
            }

            return outputCollection;
        }

        private void CreateDictionaryFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!this.IsUsingFormat(line, "::")) continue;

                var englishVocabGroup = this.GetEnglishVocabGroup(line);
                var germanVocabGroup = this.GetGermanVocabGroup(line);
                _vocabs.Add(englishVocabGroup, germanVocabGroup);
            }
        }

        private EnglishVocabGroupDTO GetEnglishVocabGroup(string line)
        {

            var temp = line.Split("::".ToCharArray())[0];   // get left side of "::"
            var englishVocabs = temp.Split("/".ToCharArray());

            EnglishVocabGroupDTO vocabGroupDto = new EnglishVocabGroupDTO(englishVocabs);

            return vocabGroupDto;
        }

        private GermanVocabGroupDTO GetGermanVocabGroup(string line)
        {

            var temp = line.Split("::".ToCharArray())[2];   // get right side of "::"
            var germanVocabs = temp.Split("/".ToCharArray());

            GermanVocabGroupDTO vocabGroupDto = new GermanVocabGroupDTO(germanVocabs);

            return vocabGroupDto as GermanVocabGroupDTO;
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
