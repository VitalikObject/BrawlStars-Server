using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class GameModeVariation : Data
    {
        public GameModeVariation(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int Variation { get; set; }

        public bool Disabled { get; set; }

        public string TID { get; set; }

        public string ChatSuggestionItemName { get; set; }

        public string GameModeRoomIconName { get; set; }

        public string GameModeIconName { get; set; }

        public string ScoreSfx { get; set; }

        public string OpponentScoreSfx { get; set; }

        public string ScoreText { get; set; }

        public string ScoreTextEnd { get; set; }

        public int FriendlyMenuOrder { get; set; }

        public string IntroText { get; set; }

        public string IntroDescText { get; set; }

        public string IntroDescText2 { get; set; }

        public string StartNotification { get; set; }

        public string EndNotification { get; set; }
    }
}
