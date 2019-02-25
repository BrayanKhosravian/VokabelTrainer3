using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Models
{
    class ChapterGroup : List<Chapter>
    {
        public string GroupName { get; set; }
        public string GroupPath { get; set; }

        public ChapterGroup(string groupName, string groupPath)
        {
            GroupName = groupName;
            GroupPath = groupPath;
        }
    }
}
