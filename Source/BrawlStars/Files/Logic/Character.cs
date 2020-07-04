using BrawlStars.Files.CsvHelpers;
using BrawlStars.Files.CsvReader;

namespace BrawlStars.Files.Logic
{
    public class Character : Data
    {
        public Character(Row row, DataTable datatable) : base(row, datatable)
        {
            LoadData(this, GetType(), row);
        }

        public string Name { get; set; }

        public bool LockedForChronos { get; set; }

        public bool Disabled { get; set; }

        public string ItemName { get; set; }

        public string WeaponSkill { get; set; }

        public string UltimateSkill { get; set; }

        public string Pet { get; set; }

        public int Speed { get; set; }

        public int Hitpoints { get; set; }

        public bool MeleeAutoAttackSplashDamage { get; set; }

        public int AutoAttackSpeedMs { get; set; }

        public int AutoAttackDamage { get; set; }

        public int AutoAttackBulletsPerShot { get; set; }

        public string AutoAttackMode { get; set; }

        public int AutoAttackProjectileSpread { get; set; }

        public string AutoAttackProjectile { get; set; }

        public int AutoAttackRange { get; set; }

        public int RegeneratePerSecond { get; set; }

        public int UltiChargeMul { get; set; }

        public int UltiChargeUltiMul { get; set; }

        public string Type { get; set; }

        public int DamagerPercentFromAliens { get; set; }

        public string DefaultSkin { get; set; }

        public string FileName { get; set; }

        public string BlueExportName { get; set; }

        public string RedExportName { get; set; }

        public string ShadowExportName { get; set; }

        public string AreaEffect { get; set; }

        public string DeathAreaEffect { get; set; }

        public string TakeDamageEffect { get; set; }

        public string DeathEffect { get; set; }

        public string MoveEffect { get; set; }

        public string ReloadEffect { get; set; }

        public string OutOfAmmoEffect { get; set; }

        public string DryFireEffect { get; set; }

        public string SpawnEffect { get; set; }

        public string MeleeHitEffect { get; set; }

        public string AutoAttackStartEffect { get; set; }

        public string BoneEffect1 { get; set; }

        public string BoneEffect2 { get; set; }

        public string BoneEffect3 { get; set; }
        
        public string BoneEffect4 { get; set; }

        public string BoneEffectUse { get; set; }

        public string LoopedEffect { get; set; }

        public string LoopedEffect2 { get; set; }

        public string KillCelebrationSoundVO { get; set; }

        public string InLeadCelebrationSoundVO { get; set; }

        public string StartSoundVO { get; set; }

        public string UseUltiSoundVO { get; set; }

        public string TakeDamageSoundVO { get; set; }

        public string DeathSoundVO { get; set; }

        public string AttackSoundVO { get; set; }

        public int AttackStartEffectOffset { get; set; }

        public int TwoWeaponAttackEffectOffset { get; set; }

        public int ShadowScaleX { get; set; }

        public int ShadowScaleY { get; set; }

        public int ShadowX { get; set; }

        public int ShadowY { get; set; }

        public int ShadowSkew { get; set; }

        public int Scale { get; set; }

        public int HeroScreenScale { get; set; }

        public int FitToBoxScale { get; set; }

        public int EndScreenScale { get; set; }

        public int GatchaScreenScale { get; set; }

        public int HomeScreenScale { get; set; }

        public int HeroScreenXOffset { get; set; }

        public int HeroScreenZOffset { get; set; }

        public int CollisionRadius { get; set; }

        public string HealthBar { get; set; }

        public int HealthBarOffsetY { get; set; }

        public int FlyingHeight { get; set; }

        public int ProjectileStartZ { get; set; }

        public int StopMovementAfterMS { get; set; }

        public int WaitMS { get; set; }

        public string TID { get; set; }

        public bool ForceAttackAnimationToEnd { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public int RecoilAmount { get; set; }

        public string Homeworld { get; set; }

        public string FootstepClip { get; set; }

        public int DifferentFootstepOffset { get; set; }

        public int FootstepIntervalMS { get; set; }

        public int AttackingWeaponScale { get; set; }

        public bool UseThrowingLeftWeaponBoneScaling { get; set; }

        public bool UseThrowingRightWeaponBoneScaling { get; set; }

        public int CommonSetUpgradeBonus { get; set; }

        public int RareSetUpgradeBonus { get; set; }

        public int SuperRareSetUpgradeBonus { get; set; }

        public bool CanWalkOverWater { get; set; }

        public bool UseColorMod { get; set; }

        public int RedAdd { get; set; }

        public int GreenAdd { get; set; }

        public int BlueAdd { get; set; }

        public int RedMul { get; set; }

        public int GreenMul { get; set; }
 
        public int BlueMul { get; set; }

        public int ChargeUltiAutomatically { get; set; }

        public string VideoLink { get; set; }

        public bool ShouldEncodePetStatus { get; set; }

        public bool SecondaryPet { get; set; }

        public int ExtraMinions { get; set; }

        public int PetAutoSpawnDelay { get; set; }

        public int OffenseRating { get; set; }

        public int DefenseRating { get; set; }
        
        public int UtilityRating { get; set; }
    }
}
