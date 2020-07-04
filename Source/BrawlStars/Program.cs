using System;
using System.Drawing;
using System.Threading;
using BrawlStars.Utilities.Utils;

namespace BrawlStars
{
    public static class Program
    {
        public static int Version { get; set; }
        private static void Main()
        {
            Console.Title = $"By Mr Vitalik & PhoenixFire - {DateTime.Now.Year} ©";


            Resources.Initialize();

            if (ServerUtils.IsLinux())
            {
                Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                Logger.Log("Press any key to shutdown the server.", null);
                Console.Read();
            }

            Shutdown();
        }

        public static async void Shutdown()
        {
            Console.WriteLine("Shutting down...");

            await Resources.Netty.Shutdown();

            try
            {
                Console.WriteLine("Saving players...");

                lock (Resources.Players.SyncObject)
                {
                    foreach (var player in Resources.Players.Values) player.Save();
                }

                Console.WriteLine("All players saved.");
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't save all players.");
            }

            await Resources.Netty.ShutdownWorkers();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}