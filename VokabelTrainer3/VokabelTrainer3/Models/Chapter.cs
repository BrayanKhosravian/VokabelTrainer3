using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VokabelTrainer3.Models
{
    class Chapter
    {
        public string ChapterName { get; set; }
        public string ChapterPath { get; set; }

        public Chapter(string chapterName, string chapterPath)
        {
            ChapterName = chapterName;
            ChapterPath = chapterPath;
        }
        
    }
}
