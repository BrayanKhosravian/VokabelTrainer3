
namespace VokabelTrainer3.Droid.Interfaces
{
    internal interface ITextFileParser
    {
        bool PathContains(string path, string match);
        bool PathContainsBasic(string path);
        bool PathContainsAdvanced(string path);
        bool PathContainsCustom(string path);
        string GetFileNameFromResource(string path);
    }
}