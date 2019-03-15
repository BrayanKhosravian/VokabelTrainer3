using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VokabelTrainer3.ServiceModels
{
    public abstract class Vocab : IEnumerable<string>
    {
        public IEnumerable<string> Words { get; private set; } = new List<string>();

        protected Vocab(string[] words)
        {
            if (words?.Length <= 0) throw new IndexOutOfRangeException();
            Words = new List<string>(AddVocabs(words));
        }

        public override string ToString()
        {
            string output = "";

            foreach (var vocab in Words)
            {
                output += vocab;
                output += " / ";
            }

            output = output.Remove(output.Length - 3, 3); // removes last " / "

            return output;
        }

        private IEnumerable<string> AddVocabs(string[] words)
        {
            return Words.Concat(words.AsEnumerable());
        }

        public IEnumerator<string> GetEnumerator() => Words.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
