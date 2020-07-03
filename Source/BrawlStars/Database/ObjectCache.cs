using System;
using System.Diagnostics;
using BrawlStars.Logic;
using BrawlStars.Logic.Home;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using BrawlStars.Logic.Clan;

namespace BrawlStars.Database
{
    public class ObjectCache
    {
        private readonly TimeSpan _expirationTimeSpan;
        private readonly MemoryCache _objectCache;
        private readonly MemoryCache _playerCache;
        private readonly MemoryCache _allianceCache;

        public ObjectCache()
        {
            var options = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromMinutes(5)
            };

            _expirationTimeSpan = TimeSpan.FromHours(2);

            _playerCache = new MemoryCache(options, new NullLoggerFactory());
            _objectCache = new MemoryCache(options, new NullLoggerFactory());
            _allianceCache = new MemoryCache(options, new NullLoggerFactory());

            Logger.Log("Successfully loaded caches", null);
        }

        /// <summary>
        ///     Cache a player to access it from memory
        /// </summary>
        /// <param name="player"></param>
        public void CachePlayer(Player player)
        {
            try
            {
                var home = player.Home;

                var playerEntry = _playerCache.CreateEntry(home.Id);
                playerEntry.Value = home;
                _playerCache.Set(home.Id, playerEntry, _expirationTimeSpan);

                var objectEntry = _objectCache.CreateEntry(home.Id);

                _objectCache.Set(home.Id, objectEntry, _expirationTimeSpan);
            }
            catch (Exception)
            {
                Logger.Log("Failed to cache player.", GetType(), Logger.ErrorLevel.Error);
            }
        }
        public void CacheAlliance(Alliance alliance)
        {
            try
            {
                var allianceEntry = _allianceCache.CreateEntry(alliance.Id);
                allianceEntry.Value = alliance;
                _allianceCache.Set(alliance.Id, allianceEntry, _expirationTimeSpan);
            }
            catch (Exception)
            {
                Logger.Log("Failed to cache player.", GetType(), Logger.ErrorLevel.Error);
            }
        }
        public Player GetCachedPlayer(long id)
        {
            try
            {
                var st = new Stopwatch();
                st.Start();

                if (_playerCache.Get(id) is ICacheEntry playerEntry)
                    if (_objectCache.Get(id) is ICacheEntry objectEntry)
                        if (playerEntry.Value is Home home)
                            if (objectEntry.Value is string json)
                            {
                                home.Time.SubTick = 0;

                                st.Stop();
                                Logger.Log($"Successfully got player {id} from cache in {st.ElapsedMilliseconds}ms",
                                    null,
                                    Logger.ErrorLevel.Debug);

                                return new Player
                                {
                                    Home = home
                                };
                            }
            }
            catch (Exception)
            {
                Logger.Log("Failed to fetch player from cache.", GetType(), Logger.ErrorLevel.Error);
            }

            return null;
        }
        public Alliance GetCachedAlliance(long id)
        {
            try
            {
                var st = new Stopwatch();
                st.Start();

                if (_allianceCache.Get(id) is ICacheEntry allianceEntry)
                {
                    if (allianceEntry.Value is Alliance alliance)
                    {
                        st.Stop();
                        Logger.Log($"Successfully got alliance {id} from cache in {st.ElapsedMilliseconds}ms", null,
                            Logger.ErrorLevel.Debug);

                        return alliance;
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log("Failed to fetch alliance from cache.", GetType(), Logger.ErrorLevel.Error);
            }

            return null;
        }

        public long CachedPlayers()
        {
            return _playerCache.Count;
        }
    }
}