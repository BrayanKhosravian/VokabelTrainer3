using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Interfaces
{
    public interface IFileService
    {
        void CreateTextFileHirarchy();
        string[] GetFilesPaths(string path);
    }
}
