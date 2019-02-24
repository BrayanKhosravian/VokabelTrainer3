using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        public static string AtTheHotel { get; } = Path.Combine(BasicVocabsPath, "AtTheHotel");
        public static string CarRental { get; } = Path.Combine(BasicVocabsPath, "CarRental");
        public static string GettingStarted { get; } = Path.Combine(BasicVocabsPath, "GettingStarted");
        public static string TheJourney { get; } = Path.Combine(BasicVocabsPath, "TheJourney");
        public static string TravellingAbroad { get; } = Path.Combine(BasicVocabsPath, "TravellingAbroad");

        // Children paths from "advanced" parent paths


        // Children paths from "custom" parent paths


        // get paths from each parent path
      //  public static  string[]
        public static string[] GetBasicVocabsPaths => new[] { AtTheHotel, CarRental, GettingStarted, TheJourney, TravellingAbroad };
        // public static string[] GetAdvancedVocabsPaths => new[] { };
    }
}
