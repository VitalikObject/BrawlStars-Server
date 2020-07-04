using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Challenge : Data
    {
        public Challenge(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public int ChallengeId { get; set; }

        public string FileName { get; set; }

        public string EventAsset { get; set; }

        public string BannerSWF { get; set; }

        public string EventBanner { get; set; }

        public string RewardItem { get; set; }

        public string RewardUnlockedItem { get; set; }

        public string HeaderFrame { get; set; }

        public string TID { get; set; }

        public string StageTID { get; set; }

        public string RewardTID { get; set; }

        public string CompletedTID { get; set; }

        public string RewardPopupTID { get; set; }

        public string BattleEndHeaderTID { get; set; }

        public string BattleEndWinLabelTID { get; set; }

        public string BattleEndWinTID { get; set; }

        public string StartNotification { get; set; }

        public string ReminderNotification { get; set; }

        public string TeaserTitleTID { get; set; }

        public string TeaserInfoTID { get; set; }
    }
}
