using System.IO;

namespace VokabelTrainer3
{
    public static class Paths
    {
        private static readonly string _path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        // Root Path from _path
        public static string RootPath { get; } = Path.Combine(_path, "Vokabeln");

        // Parent paths of root
        public static string BasicVocabsPath { get; } = Path.Combine(RootPath, "Basic");
        public static string AdvancedVocabsPath { get; } = Path.Combine(RootPath, "Advanced");
        public static string CustomVocabsPath { get; } = Path.Combine(RootPath, "Custom");

        // Children paths from "basic" parent paths
        public static string AtTheHotel { get; } = Path.Combine(BasicVocabsPath, "At the hotel");
        public static string CarRental { get; } = Path.Combine(BasicVocabsPath, "Car rental");
        public static string GettingStarted { get; } = Path.Combine(BasicVocabsPath, "Getting started");
        public static string TheJourney { get; } = Path.Combine(BasicVocabsPath, "The journey");
        public static string TravellingAbroad { get; } = Path.Combine(BasicVocabsPath, "Travelling abroad");

        // Children paths from "advanced" parent paths
        public static string News { get; } = Path.Combine(AdvancedVocabsPath, "News");

        // Children paths from "custom" parent paths
        // ..
        
        // get all paths
        public static string[] AllPaths => new string[]{RootPath,                   // Root
            BasicVocabsPath, AdvancedVocabsPath, CustomVocabsPath,                  // parent paths of Root
            AtTheHotel, CarRental, GettingStarted, TheJourney, TravellingAbroad,    // basic paths
            News                                                                    // advanced paths
        };
    }
}
