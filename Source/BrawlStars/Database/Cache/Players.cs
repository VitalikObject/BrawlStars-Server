using System.Collections.Generic;
using System.Threading.Tasks;
using BrawlStars.Logic;

namespace BrawlStars.Database.Cache
{
    public class Players : Dictionary<long, Player>
    {
        public readonly object SyncObject = new object();

        /// <summary>
        ///     Login a player
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        public async Task<Player> Login(long userId, string token)
        {
            Player player;

            if (userId <= 0 && string.IsNullOrEmpty(token))
            {
                player = await PlayerDb.CreateAsync();
            }
            else
            {
                //var p = await Redis.GetPlayerAsync(userId);
                var p = Resources.ObjectCache.GetCachedPlayer(userId);

                if (p != null)
                    player = p;
                else
                    player = await PlayerDb.GetAsync(userId);

                if (player == null) return null;
                if (player.Home.UserToken != token) return null;
            }

            lock (SyncObject)
            {
                if (player == null) return null;

                Logout(ref player);

                var result = TryAdd(player.Home.Id, player);

                if (!result) return null;

                //Logger.Log($"User {player.Home.Id} logged in.", GetType(), ErrorLevel.Debug);

                return player;
            }
        }

        /// <summary>
        ///     Called when a player logs out
        /// </summary>
        /// <param name="player"></param>
        public void Logout(ref Player player)
        {
            lock (SyncObject)
            {
                if (!ContainsKey(player.Home.Id)) return;

                var p = this[player.Home.Id];
                p.ValidateSession();
                p.Save();

                player = p;

                var result = Remove(p.Home.Id);

                if (!result) Logger.Log($"Couldn't logout player {p.Home.Id}", GetType(), Logger.ErrorLevel.Error);
                //else Logger.Log($"User {player.UserId} logged out.", GetType(), ErrorLevel.Debug);
            }
        }

        /// <summary>
        ///     Log out a player by the UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool LogoutById(long userId)
        {
            lock (SyncObject)
            {
                if (!ContainsKey(userId)) return true;

                var player = this[userId];
                player.ValidateSession();
                player.Save();

                var result = Remove(userId);

                if (!result) Logger.Log($"Couldn't logout player {userId}", GetType(), Logger.ErrorLevel.Error);

                return result;
            }
        }

        /// <summary>
        ///     Get a player from cache or database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="onlineOnly"></param>
        /// <returns></returns>
        public async Task<Player> GetPlayerAsync(long userId, bool onlineOnly = false)
        {
            lock (SyncObject)
            {
                if (ContainsKey(userId))
                    return this[userId];
            }

            if (onlineOnly) return null;

            var player = Resources.ObjectCache.GetCachedPlayer(userId);

            if (player != null) return player;

            player = await PlayerDb.GetAsync(userId);

            Resources.ObjectCache.CachePlayer(player);

            return player;
        }
    }
}