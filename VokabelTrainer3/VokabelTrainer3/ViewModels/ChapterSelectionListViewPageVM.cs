using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VokabelTrainer3.Models;

namespace VokabelTrainer3.ViewModels
{
    class ChapterSelectionListViewPageVM : BaseVM
    {
        public ObservableCollection<ChapterGroup> Chapters { get; set; }

    }
}
