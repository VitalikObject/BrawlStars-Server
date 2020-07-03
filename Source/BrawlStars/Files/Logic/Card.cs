using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Card : Data
    {
        public Card(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string Target { get; set; }

        public bool LockedForChronos { get; set; }

        public int DynamicRarityStartSeason { get; set; }

        public int MetaType { get; set; }

        public string RequiresCard { get; set; }

        public string Type { get; set; }

        public string Skill { get; set; }

        public int Value { get; set; }

        public int Value2 { get; set; }

        public int Value3 { get; set; }

        public string Rarity { get; set; }

        public string TID { get; set; }

        public string PowerNumberTID { get; set; }

        public string PowerNumber2TID { get; set; }

        public string PowerNumber3TID { get; set; }

        public string PowerIcon1ExportName { get; set; }

        public string PowerIcon2ExportName { get; set; }

        public int SortOrder { get; set; }

        public bool DontUpgradeStat { get; set; }

        public bool HideDamageStat { get; set; }
    }
}
