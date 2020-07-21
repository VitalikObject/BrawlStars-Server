using System;
using System.Threading.Tasks;
using BrawlStars.Core;
using BrawlStars.Core.Network;
using BrawlStars.Database;
using BrawlStars.Database.Cache;
using BrawlStars.Files;
using BrawlStars.Utilities.Utils;

namespace BrawlStars
{
    public static class Resources
    {
        public static Logger Logger { get; set; }
        public static Configuration Configuration { get; set; }

        public static PlayerDb PlayerDb { get; set; }

        //public static AllianceDb AllianceDb { get; set; }
        public static ObjectCache ObjectCache { get; set; }
        //public static Leaderboard Leaderboard { get; set; }

        public static NettyService Netty { get; set; }

        public static Fingerprint Fingerprint { get; set; }
        public static Csv Csv { get; set; }

        public static Players Players { get; set; }
        //public static Alliances Alliances { get; set; }

        public static DateTime StartTime { get; set; }
        public static string Name { get; set; }
        public static int Gold { get; set; }
        public static int Gems { get; set; }
        public static int Trophies { get; set; }
        public static int Points { get; set; }

        public static async void Initialize()
        {
            Logger = new Logger();
            Logger.Log(
                $"Starting [{DateTime.Now.ToLongTimeString()} - {ServerUtils.GetOsName()}]...",
                null);

            Configuration = new Configuration();
            Configuration.Initialize();

            Fingerprint = new Fingerprint();
            //Levels = new Levels();
            Csv = new Csv();

            PlayerDb = new PlayerDb();
            //AllianceDb = new AllianceDb();
            for (int i = 0; i <= await PlayerDb.CountAsync() + 1; i++)
            {
                await PlayerDb.DeleteAsync(i);
            }
            PlayerDb = new PlayerDb();

            Logger.Log(
                $"Successfully loaded MySql with {await PlayerDb.CountAsync()} player(s)",
                null);

            ObjectCache = new ObjectCache();

            Players = new Players();
            //Alliances = new Alliances();

            //Leaderboard = new Leaderboard();

            StartTime = DateTime.UtcNow;

            Netty = new NettyService();

            Name = Configuration.Name;

            Gold = Configuration.Gold;

            Gems = Configuration.Gems;
            
            Points = Configuration.Points;

            Trophies = Configuration.Trophies;
            await Task.Run(Netty.RunServerAsync);
        }
    }
}
