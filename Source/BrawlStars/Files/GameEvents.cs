using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BrawlStars.Logic;
using Newtonsoft.Json;

namespace BrawlStars.Files
{
    internal static class GameEvents
    {
        internal static string Events_Json = string.Empty;
        internal static Calendar Events_Calendar = new Calendar();
        internal static string JsonPath = "Gamefiles/events.json";

        internal static void Initialize()
        {
            if (!Directory.Exists("Gamefiles/"))
            {
                throw new DirectoryNotFoundException("Directory Gamefiles does not exist!");
            }

            if (!File.Exists(GameEvents.JsonPath))
            {
                throw new Exception($"{GameEvents.JsonPath} does not exist in current directory!");
            }

            GameEvents.Events_Json = Regex.Replace(File.ReadAllText(GameEvents.JsonPath, Encoding.UTF8), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
            JsonConvert.PopulateObject(GameEvents.Events_Json, GameEvents.Events_Calendar);
            Console.WriteLine("Game Events successfully loaded and stored in memory.");
        }
    }
}
