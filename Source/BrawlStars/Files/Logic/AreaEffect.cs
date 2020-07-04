using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class AreaEffect : Data
    {
        public AreaEffect(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string ParentAreaEffectForSkin { get; set; }

        public string FileName { get; set; }

        public string OwnExportName { get; set; }

        public string BlueExportName { get; set; }

        public string RedExportName { get; set; }

        public string NeutralExportName { get; set; }

        public string Layer { get; set; }

        public string ExportNameTop { get; set; }

        public string ExportNameObject { get; set; }

        public string Effect { get; set; }

        public string LoopingEffect { get; set; }

        public bool AllowEffectInterrupt { get; set; }

        public bool ServerControlsFrame { get; set; }

        public int Scale { get; set; }

        public int TimeMs { get; set; }

        public int Radius { get; set; }

        public int Damage { get; set; }

        public int CustomValue { get; set; }

        public string Type { get; set; }

        public bool IsPersonal { get; set; }

        public string BulletExplosionBullet { get; set; }

        public int BulletExplosionBulletDistance { get; set; }

        public string BulletExplosionItem { get; set; }

        public bool DestroysEnvironment { get; set; }

        public int PushbackStrength { get; set; }

        public int PushbackStrengthSelf { get; set; }

        public int PushbackDeadzone { get; set; }

        public bool CanStopGrapple { get; set; }

        public int FreezeStrength { get; set; }

        public int FreezeTicks { get; set; }

        public bool ShouldShowEvenIfOutsideScreen { get; set; }

        public int SameAreaEffectCanNotDamageMs { get; set; }

        public bool DontShowToEnemy { get; set; }

        public bool RequireLineOfSight { get; set; }
    }
}
