using System;
using System.Collections.Generic;
using BrawlStars.Files;
using BrawlStars.Files.Logic;
using BrawlStars.Logic.Clan;
using BrawlStars.Logic.Home.Slots;
using BrawlStars.Logic.Home.StreamEntry;
using BrawlStars.Logic.Sessions;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Home
{
    public class Home
    {
        [JsonProperty("clanInfo")] public AllianceInfo AllianceInfo = new AllianceInfo();
        /*[JsonIgnore] public ComponentManager ComponentManager = new ComponentManager();*/
       /* [JsonIgnore] public GameObjectManager GameObjectManager = new GameObjectManager();*/
        [JsonProperty("resources")] public ResourceSlots Resources = new ResourceSlots();
        [JsonIgnore] public List<Session> Sessions = new List<Session>(50);
        [JsonProperty("stream")] public List<AvatarStreamEntry> Stream = new List<AvatarStreamEntry>(40);
        [JsonIgnore] public Time Time = new Time();

        public Home()
        {

        }

        public Home(long id, string token)
        {
            Id = id;
            UserToken = token;

            PreferredDeviceLanguage = "EN";

            Name = "NoName";
            ExpLevel = 1;

            Diamonds = 10000000;
            Resources.Initialize();

           /* GameObjectManager.Home = this;
            ComponentManager.Home = this;
            GameObjectManager.LoadJson(Levels.StartingHome);*/
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("token")] public string UserToken { get; set; }
        [JsonProperty("nameSet")] public int NameSet { get; set; }
        [JsonProperty("createdIp")] public string CreatedIpAddress { get; set; }
        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("diamonds")] public int Diamonds { get; set; }
        [JsonProperty("heroes_king")] public int HeroesKing { get; set; }
        [JsonProperty("sleep_king")] public int SleepKing { get; set; }
        [JsonProperty("heroes_queen")] public int HeroesQueen { get; set; }
        [JsonProperty("sleep_queen")] public int SleepQueen { get; set; }
        [JsonProperty("warden_heroes_lvl")] public int WardenHerolvl { get; set; }
        [JsonProperty("battle_machine_heroes_lvl")] public int BattleMachineHerolvl { get; set; }
        [JsonProperty("sleep_warden")] public int SleepWarden { get; set; }
        [JsonProperty("champion_heroes_lvl")] public int ChampionHerolvl { get; set; }
        [JsonProperty("king_skin")] public int KingSkin { get; set; }
        [JsonProperty("queen_skin")] public int QueenSkin { get; set; }
        [JsonProperty("warder_skin")] public int WardenSkin { get; set; }
        [JsonProperty("champion_skin")] public int ChampionSkin { get; set; }
        [JsonProperty("sleep_champion")] public int SleepChampion { get; set; }
        [JsonProperty("warder_fly")] public int WardenFly { get; set; }
        [JsonProperty("language")] public string PreferredDeviceLanguage { get; set; }
        [JsonProperty("fcbId")] public string FacebookId { get; set; }
        [JsonProperty("totalSessions")] public int TotalSessions { get; set; }
        [JsonProperty("totalPlayTimeSeconds")] public int TotalPlayTimeSeconds { get; set; }

        [JsonProperty("lastSave")] public DateTime LastSaveTime { get; set; }

        /// <summary>
        ///     1 = Builderbase, 0 = Home Village
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }

        // Player Stats
        [JsonProperty("expLevel")] public int ExpLevel { get; set; }
        [JsonProperty("expPoints")] public int ExpPoints { get; set; }
        [JsonProperty("trophies")] public int Trophies { get; set; }
        [JsonProperty("builder_trophies")] public int BTrophies { get; set; }

        [JsonIgnore]
        public long Id
        {
            get => ((long) HighId << 32) | (LowId & 0xFFFFFFFFL);
            set
            {
                HighId = Convert.ToInt32(value >> 32);
                LowId = (int) value;
            }
        }

      /*  public void AddExpPoints(int expPoints)
        {
            ExpPoints += expPoints;

            while (true)
            {
                var data = Csv.Tables.Get(Csv.Files.ExperienceLevels).GetDataWithId<ExperienceLevels>(ExpLevel - 1);
                if (data == null) return;

                if (ExpPoints < data.ExpPoints) return;

                ExpLevel++;
                ExpPoints -= data.ExpPoints;

                if (ExpPoints >= data.ExpPoints)
                    continue;

                break;
            }
        }*/

        /*public void Tick()
        {
            GameObjectManager.Tick();
        }*/

       /* public void FastForward(int seconds)
        {
            GameObjectManager.FastForward(seconds);
        }*/

        public void Reset(bool notResetGameObjects = false)
        {
            Diamonds = 10000000;
            Resources.Initialize();

            Name = "NoName";
            NameSet = 0;
            ExpLevel = 1;
            ExpPoints = 0;
            Trophies = 0;

            State = 0;

          /*  if (!notResetGameObjects)
                GameObjectManager.LoadJson(Levels.StartingHome);*/
        }

        #region Resources

        public bool UseGold(int amount)
        {
            var gold = Resources.GetById(5000001).Count;

            if (gold - amount < 0) return false;

            Resources.Remove(5000001, amount);
            return true;
        }

        public bool UseOwcAny(int amount)
        {
            var owcAny = Resources.GetById(5000002).Count;

            if (owcAny - amount < 0) return false;

            Resources.Remove(5000002, amount);
            return true;
        }

        public bool UseOwcRareOrBetter(int amount)
        {
            var owcRare = Resources.GetById(5000003).Count;

            if (owcRare - amount < 0) return false;

            Resources.Remove(5000003, amount);
            return true;
        }

        public bool UseowcEpicOrBetter(int amount)
        {
            var owcEpic = Resources.GetById(5000004).Count;

            if (owcEpic - amount < 0) return false;

            Resources.Remove(5000004, amount);
            return true;
        }

        public bool UseDust(int amount)
        {
            var dust = Resources.GetById(5000005).Count;

            if (dust - amount < 0) return false;

            Resources.Remove(5000005, amount);
            return true;
        }

        public bool UseUpgradium(int amount)
        {
            var upgrdium = Resources.GetById(5000006).Count;

            if (upgrdium - amount < 0) return false;

            Resources.Remove(5000006, amount);
            return true;
        }

        public bool UseBolts(int amount)
        {
            var bolts = Resources.GetById(5000007).Count;

            if (bolts - amount < 0) return false;

            Resources.Remove(5000007, amount);
            return true;
        }

        public bool UseHeroLvlUpMaterial(int amount)
        {
            var heroUpMate = Resources.GetById(5000008).Count;

            if (heroUpMate - amount < 0) return false;

            Resources.Remove(5000008, amount);
            return true;
        }

        public bool UseFirstWins(int amount)
        {
            var firstWins = Resources.GetById(5000009).Count;

            if (firstWins - amount < 0) return false;

            Resources.Remove(5000009, amount);
            return true;
        }

        public bool UseDiamonds(int amount)
        {
            if (Diamonds - amount < 0) return false;

            Diamonds -= amount;
            return true;
        }
        #endregion
    }
}