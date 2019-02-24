using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Models
{
    class ChapterGroup : List<Chapter>
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public ChapterGroup(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
