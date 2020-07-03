using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Locale : Data
    {
        public Locale(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string LocalizedName { get; set; }

        public int SortOrder { get; set; }

        public bool Enabled { get; set; }

        public string FileName { get; set; }

        public bool TestLanguage { get; set; }

        public string UsedSystemFont { get; set; }

        public string PreferedFallbackFont { get; set; }

        public string ForcedFontFullName { get; set; }

        public string HelpshiftSDKLanguage { get; set; }

        public string HelpshiftSDKLanguageAndroid { get; set; }

        public string[] TestExcludes { get; set; }

        public bool LoadAllLanguages { get; set; }

        public string ChampionshipRegisterUrl { get; set; }

        public string ChampionshipRegisterUrl_cn { get; set; }

        public string TermsAndServiceUrl { get; set; }

        public string ParentsGuideUrl { get; set; }

        public string PrivacyPolicyUrl { get; set; }

        public string LaserboxUrl { get; set; }

        public string LaserboxUrlCN { get; set; }

        public string LaserboxStagingUrl { get; set; }

        public string LaserboxStagingUrlCN { get; set; }

        public string LaserboxCommunityUrl { get; set; }

        public string LaserboxCommunityUrlCN { get; set; }

        public string LaserboxCommunityStagingUrl { get; set; }

        public string LaserboxCommunityStagingUrlCN { get; set; }

        public string LaserboxLangCode { get; set; }

        public string FaqUrl_ios { get; set; }

        public string FaqUrl_ios_cn { get; set; }

        public string FaqUrl_android { get; set; }

        public string FaqUrl_android_cn { get; set; }

        public string ContactUsUrl_ios { get; set; }

        public string ContactUsUrl_ios_cn { get; set; }

        public string ContactUsUrl_android { get; set; }

        public string ContactUsUrl_android_cn { get; set; }

        public bool LaserboxEnabled { get; set; }

        public bool IsRTL { get; set; }

        public bool isNounAdj { get; set; }

        public bool SeparateThousandsWithSpaces { get; set; }

        public string SelfHelpUrl { get; set; }

        public bool FallbackToHelpshift { get; set; }

        public bool FallbackToHelpshiftCN { get; set; }
    }
}
