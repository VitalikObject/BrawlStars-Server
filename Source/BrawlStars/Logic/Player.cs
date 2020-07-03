using System;
using BrawlStars.Database;
using BrawlStars.Files.Logic;
using BrawlStars.Utilities.Netty;
using BrawlStars.Utilities.Utils;
using DotNetty.Buffers;
using Newtonsoft.Json;
using BrawlStars.Files;

namespace BrawlStars.Logic
{
    public class Player
    {
        public Player(long id)
        {
            Home = new Home.Home(id, GameUtils.GenerateToken);
        }

        public Player()
        {
            // Player.
        }

        public Home.Home Home { get; set; }

        [JsonIgnore] public Device Device { get; set; }

        public void RankingEntry(IByteBuffer packet)
        {
            // TODO
        }

        public void LogicClientHome(IByteBuffer packet)
        {

        }

        public void LogicClientAvatar(IByteBuffer packet)
        {

        }

        /*public async void AddEntry(AvatarStreamEntry entry)
        {
            lock (Home.Stream)
            {
                while (Home.Stream.Count >= 40)
                    Home.Stream.RemoveAt(0);

                var max = Home.Stream.Count == 0 ? 1 : Home.Stream.Max(x => x.Id);
                entry.Id = max == int.MaxValue ? 1 : max + 1; // If we ever reach that value... but who knows...

                Home.Stream.Add(entry);
            }

            await new AvatarStreamEntryMessage(Device)
            {
                Entry = entry
            }.SendAsync();
        }*/

        /// <summary>
        ///     Validates this session
        /// </summary>
        public void ValidateSession()
        {
            var session = Device.Session;
            session.Duration = (int) DateTime.UtcNow.Subtract(session.SessionStart).TotalSeconds;

            Home.TotalPlayTimeSeconds += session.Duration;

            while (Home.Sessions.Count >= 50) Home.Sessions.RemoveAt(0);

            Home.Sessions.Add(session);
        }

        public async void Save()
        {
            Home.LastSaveTime = DateTime.UtcNow;

/*#if DEBUG
            var st = new Stopwatch();
            st.Start();

            Resources.ObjectCache.CachePlayer(this);
            await PlayerDb.SaveAsync(this);

            st.Stop();
            Logger.Log($"Player {Home.Id} saved in {st.ElapsedMilliseconds}ms.", GetType(), ErrorLevel.Debug);
#else*/
            Resources.ObjectCache.CachePlayer(this);
            await PlayerDb.SaveAsync(this);
//#endif
        }
    }
}
