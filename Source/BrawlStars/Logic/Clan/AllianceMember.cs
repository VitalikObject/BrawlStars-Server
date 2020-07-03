using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Clan
{
    public class AllianceMember
    {
        public AllianceMember(Player player, Alliance.Role role)
        {
            Id = player.Home.Id;
            Role = (int) role;
            Score = player.Home.Trophies;
            Name = player.Home.Name;
        }

        public AllianceMember()
        {
            // ...
        }

        [JsonProperty("highId")] public int HighId { get; set; }
        [JsonProperty("lowId")] public int LowId { get; set; }
        [JsonProperty("role")] public int Role { get; set; }
        [JsonProperty("score")] public int Score { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("donations")] public int Donations { get; set; }
        [JsonProperty("donationsReceived")] public int DonationsReceived { get; set; }

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

        [JsonIgnore] public bool IsOnline => Resources.Players.ContainsKey(Id);

        public void AllianceMemberEntry(IByteBuffer packet)
        {
            // TODO
        }

        public async Task<Player> GetPlayerAsync(bool onlineOnly = false)
        {
            return await Resources.Players.GetPlayerAsync(Id, onlineOnly);
        }
    }
}