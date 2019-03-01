using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Interfaces
{
    public interface IDirectoryService
    {
        string GetLastDirectoryName(string directory);
    }
}
