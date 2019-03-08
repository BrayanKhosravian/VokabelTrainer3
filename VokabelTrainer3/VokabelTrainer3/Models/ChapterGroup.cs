using System.Collections.Generic;

namespace VokabelTrainer3.Models
{
    public class ChapterGroup : List<Chapter>
    {
        public string GroupName { get; set; }
        public string GroupPath { get; set; }

        public bool IsSelected { get; set; } = false;

        public ChapterGroup(string groupName, string groupPath)
        {
            GroupName = groupName;
            GroupPath = groupPath;
        }

    }
}
