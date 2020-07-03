using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BrawlStars.Logic.Clan.StreamEntry;
using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Clan
{
    public class Alliance
    {
        public enum Role
        {
            Member = 1,
            Leader = 2,
            Elder = 3,
            CoLeader = 4
        }

        [JsonProperty("members")] public List<AllianceMember> Members = new List<AllianceMember>(50);
        [JsonProperty("stream")] public List<AllianceStreamEntry> Stream = new List<AllianceStreamEntry>(40);

        public Alliance(long id)
        {
            Id = id;
            Name = "RetroClash";
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("badge")] public int Badge { get; set; }
        [JsonProperty("region")] public int Region { get; set; }
        [JsonProperty("type")] public int Type { get; set; }
        [JsonProperty("requiredScore")] public int RequiredScore { get; set; }

        [JsonIgnore] public int Score => Members.Sum(m => m.Score) / 2;

        [JsonIgnore] public int Online => Members.Count(m => m.IsOnline);

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

        public void AllianceRankingEntry(IByteBuffer packet)
        {
            // TODO
        }

        public void AllianceFullEntry(IByteBuffer packet)
        {
            AllianceHeaderEntry(packet);

            // TODO
        }

        public void AllianceHeaderEntry(IByteBuffer packet)
        {
            // TODO
        }

        public AllianceInfo GetAllianceInfo(long userId)
        {
            return new AllianceInfo
            {
                Id = Id,
                Name = Name,
                Badge = Badge,
                Role = GetRole(userId)
            };
        }

        public void Add(AllianceMember member)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == member.Id);

                if (index == -1) Members.Add(member);
            }
        }

        public async void Remove(long id)
        {
            var index = Members.FindIndex(x => x.Id == id);

            if (index > -1)
            {
                var member = Members[index];

                // If the leader leaves the clan and it's not empty, we choose a new leader 
                if (member.Role == (int) Role.Leader)
                {
                    var newLeader = Members.FirstOrDefault(m => m.Id != member.Id);
                    if (newLeader != null)
                    {
                        var player = await newLeader.GetPlayerAsync();

                        newLeader.Role = (int) Role.Leader;
                        player.Home.AllianceInfo.Role = (int) Role.Leader;

                        player.Save();
                    }
                }

                lock (Members)
                {
                    Members.RemoveAt(index);
                }
            }
        }

        public async void AddEntry(AllianceStreamEntry entry)
        {
            lock (Stream)
            {
                while (Stream.Count >= 40)
                    Stream.RemoveAt(0);

                var max = Stream.Count == 0 ? 1 : Stream.Max(x => x.Id);
                entry.Id = max == int.MaxValue ? 1 : max + 1; // If we ever reach that value... but who knows...

                Stream.Add(entry);
            }

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await member.GetPlayerAsync(true);

                /*if (player != null)
                    await new AllianceStreamEntryMessage(player.Device)
                    {
                        Entry = entry
                    }.SendAsync();*/
            }
        }

        /*public async void RemoveEntry(AllianceStreamEntry entry)
        {
            lock (Stream)
            {
                Stream.RemoveAll(e => e.Id == entry.Id);
            }

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await member.GetPlayerAsync(true);

                if (player != null)
                    await new AllianceStreamEntryRemovedMessage(player.Device)
                    {
                        EntryId = entry.Id
                    }.SendAsync();
            }
        }*/

        public int GetRole(long id)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == id);

                return index > -1 ? Members[index].Role : 1;
            }
        }

        public AllianceMember GetMember(long id)
        {
            lock (Members)
            {
                var index = Members.FindIndex(x => x.Id == id);

                return index > -1 ? Members[index] : null;
            }
        }

        /*public async void UpdateOnlineCount()
        {
            var count = Online;

            foreach (var member in Members.Where(m => m.IsOnline).ToList())
            {
                var player = await Resources.Players.GetPlayerAsync(member.Id, true);

                if (player != null)
                    await new AllianceOnlineStatusUpdatedMessage(player.Device)
                    {
                        Count = count
                    }.SendAsync();
            }
        }*/

        public async void Save()
        {
#if DEBUG
            var st = new Stopwatch();
            st.Start();

            //await Redis.CacheAsync(this);

            st.Stop();
            Logger.Log($"Alliance {Id} saved in {st.ElapsedMilliseconds}ms.", GetType(), Logger.ErrorLevel.Debug);
#else
            //await Redis.CacheAsync(this);
            await AllianceDb.SaveAsync(this);
#endif
        }
    }
}