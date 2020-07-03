using System.Collections.Generic;
using System.Threading.Tasks;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files
{
    public partial class Csv
    {
        public static readonly List<string> Gamefiles = new List<string>();
        public static Gamefiles Tables;

        public Csv()
        {
            /*Gamefiles.Add("GameAssets/csv_logic/locales.csv");
            Gamefiles.Add("GameAssets/csv_logic/globals.csv");
            Gamefiles.Add("GameAssets/csv_logic/resources.csv");
            Gamefiles.Add("GameAssets/csv_logic/alliance_badges.csv");
            Gamefiles.Add("GameAssets/csv_logic/characters.csv");
            Gamefiles.Add("GameAssets/csv_logic/area_effects.csv");
            Gamefiles.Add("GameAssets/csv_logic/items.csv");
            Gamefiles.Add("GameAssets/csv_logic/skills.csv");
            Gamefiles.Add("GameAssets/csv_logic/campaign.csv");
            Gamefiles.Add("GameAssets/csv_logic/bosses.csv");
            Gamefiles.Add("GameAssets/csv_logic/cards.csv");
            Gamefiles.Add("GameAssets/csv_logic/alliance_roles.csv");
            Gamefiles.Add("GameAssets/csv_logic/skins.csv");*/

            Tables = new Gamefiles();

            Parallel.ForEach(Gamefiles,
                file => { Tables.Initialize(new Table(file), (Files) Gamefiles.IndexOf(file) + 1); });

            Logger.Log($"{Gamefiles.Count} Gamefile(s) loaded.", GetType());
        }
    }
}