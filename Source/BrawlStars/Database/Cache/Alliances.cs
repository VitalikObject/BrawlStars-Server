using System.Collections.Generic;
using BrawlStars.Logic.Clan;
using System.Threading.Tasks;

namespace BrawlStars.Database.Cache
{
    public class Alliances : Dictionary<long, Alliance>
    {
        private readonly object _syncObject = new object();

        /// <summary>
        ///     Add an alliance to the server
        /// </summary>
        /// <param name="alliance"></param>
        public void Add(Alliance alliance)
        {
            lock (_syncObject)
            {
                if (!ContainsKey(alliance.Id)) Add(alliance.Id, alliance);
            }
        }

        /// <summary>
        ///     Remove an alliance from the server and save it
        /// </summary>
        /// <param name="allianceId"></param>
        public new void Remove(long allianceId)
        {
            lock (_syncObject)
            {
                if (ContainsKey(allianceId))
                {
                    var alliance = this[allianceId];

                    alliance.Save();

                    var result = base.Remove(allianceId);

                    if (!result)
                        Logger.Log($"Couldn't remove alliance {allianceId}", GetType(), Logger.ErrorLevel.Error);
                }
            }
        }
        public async Task<Alliance> GetAllianceAsync(long allianceId, bool onlineOnly = false)
        {
            lock (_syncObject)
            {
                if (ContainsKey(allianceId))
                    return this[allianceId];
            }

            if (onlineOnly) return null;

            var alliance = Resources.ObjectCache.GetCachedAlliance(allianceId);

            if (alliance != null) return alliance;

            alliance = await AllianceDb.GetAsync(allianceId);

            Resources.ObjectCache.CacheAlliance(alliance);

            return alliance;
        }

        /// <summary>
        ///     Get an alliance from cache or database
        /// </summary>
        /// <param name="allianceId"></param>
        /// <param name="onlineOnly"></param>
        /// <returns></returns>
        /*public async Task<Alliance> GetAllianceAsync(long allianceId, bool onlineOnly = false)
        {
            lock (_syncObject)
            {
                if (ContainsKey(allianceId))
                    return this[allianceId];
            }

            if (onlineOnly) return null;

            if (!Redis.IsConnected) return await AllianceDb.GetAsync(allianceId);

            var alliance = await Redis.GetAllianceAsync(allianceId);

            if (alliance != null) return alliance;

            alliance = await AllianceDb.GetAsync(allianceId);

            await Redis.CacheAsync(alliance);

            return alliance;
        }

        /// <summary>
        ///     Returns a list of random cached Alliances
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Alliance>> GetRandomAlliancesAsync(int count = 40, bool notFull = true)
        {
            var alliances = new List<Alliance>(count);

            for (var i = 0; i < count; i++)
            {
                var alliance = await Redis.GetRandomAllianceAsync();

                if (alliance != null && alliances.FindIndex(a => a.Id == alliance.Id) == -1)
                {
                    if (notFull)
                    {
                        if (alliance.Members.Count < 50) alliances.Add(alliance);
                    }
                    else
                    {
                        alliances.Add(alliance);
                    }
                }
            }

            return alliances;
        }*/
    }
}