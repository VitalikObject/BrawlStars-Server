using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Resource : Data
    {
        public Resource(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string IconSWF { get; set; }

        public string CollectEffect { get; set; }

        public string IconExportName { get; set; }

        public string Type { get; set; }

        public string Rarity { get; set; }

        public bool PremiumCurrency { get; set; }

        public int TextRed { get; set; }

        public int TextGreen { get; set; }

        public int TextBlue { get; set; }

        public int Cap { get; set; }
    }
}
