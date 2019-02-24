using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VokabelTrainer3.Models
{
    class Chapter
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Chapter(string name, string path)
        {
            Name = name;
            Path = path;
        }
        
    }
}
