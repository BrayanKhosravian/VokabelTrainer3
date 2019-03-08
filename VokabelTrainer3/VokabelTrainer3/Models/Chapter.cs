
namespace VokabelTrainer3.Models
{
    public class Chapter
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
