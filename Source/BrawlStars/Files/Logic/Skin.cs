using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Skin : Data
    {
        public Skin(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Conf { get; set; }

        public int Campaign { get; set; }

        public int ObtainType { get; set; }

        public int ObtainTypeCN { get; set; }

        public string PetSkin { get; set; }

        public string PetSkin2 { get; set; }

        public int CostLegendaryTrophies { get; set; }

        public int CostGems { get; set; }

        public string TID { get; set; }

        public string ShopTID { get; set; }

        public string Features { get; set; }

        public string CommunityCredit { get; set; }

        public string MaterialsFile { get; set; }

        public string BlueTexture { get; set; }

        public string RedTexture { get; set; }

        public string BlueSpecular { get; set; }

        public string RedSpecular { get; set; }
    }
}
