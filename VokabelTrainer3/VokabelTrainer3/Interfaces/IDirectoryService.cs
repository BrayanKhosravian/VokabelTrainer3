using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Interfaces
{
    public interface IDirectoryService
    {
        void CreateDirectoryHirarchy();
        string[] GetDirectoriesPaths(string path);

    }
}
