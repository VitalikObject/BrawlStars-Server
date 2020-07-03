using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Campaign : Data
    {
        public Campaign(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string Location { get; set; }

        public string AllowedHeroes { get; set; }

        public string Reward { get; set; }

        public int LevelGenerationSeed { get; set; }

        public string Map { get; set; }

        public string Enemies { get; set; }

        public int EnemyLevel { get; set; }

        public string Boss { get; set; }

        public int BossLevel { get; set; }

        public string Base { get; set; }

        public int NumBases { get; set; }

        public int BaseLevel { get; set; }

        public string Tower { get; set; }

        public int NumTowers { get; set; }

        public int TowerLevel { get; set; }

        public int RequiredStars { get; set; }
    }
}
