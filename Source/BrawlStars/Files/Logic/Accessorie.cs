using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Accessorie : Data
    {
        public Accessorie(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int ChargeCount { get; set; }

        public int Cooldown { get; set; }

        public string UseEffect { get; set; }

        public string LoopingEffect { get; set; }
        
        public int ActivationDelay { get; set; }

        public int ActiveTicks { get; set; }

        public bool StopMovement { get; set; }

        public bool SetAttackAngle { get; set; }

        public int AimGuideType { get; set; }

        public bool ConsumesAmmo { get; set; }

        public string AreaEffect { get; set; }

        public string PetAreaEffect { get; set; }

        public bool InterruptsAction { get; set; }

        public bool AllowStunActivation { get; set; }

        public bool RequirePet { get; set; }

        public bool DestroyPet { get; set; }

        public int RequireEnemyDistance { get; set; }

        public int ShieldPercent { get; set; }

        public int ShieldTicks { get; set; }

        public bool SkipTypeCondition { get; set; }

        public string CustomObject { get; set; }

        public int CustomValue1 { get; set; }

        public int CustomValue2 { get; set; }

        public int CustomValue3 { get; set; }

        public int CustomValue4 { get; set; }

        public int CustomValue5 { get; set; }

        public int CustomValue6 { get; set; }

        public string MissingTargetText { get; set; }

        public string TargetTooFarText { get; set; }

        public string TargetAlreadyActiveText { get; set; }
    }
}
