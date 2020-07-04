using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class AllianceBadge : Data
    {
        public AllianceBadge(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string Category { get; set; }
    }
}
