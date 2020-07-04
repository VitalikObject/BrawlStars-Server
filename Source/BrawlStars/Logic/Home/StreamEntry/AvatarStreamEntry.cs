using System;
using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Home.StreamEntry
{
    public class AvatarStreamEntry
    {
        [JsonProperty("creation")] public DateTime CreationDateTime = DateTime.UtcNow;
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("type")] public int StreamEntryType { get; set; }
        [JsonProperty("highId")] public int SenderHighId { get; set; }
        [JsonProperty("lowId")] public int SenderLowId { get; set; }
        [JsonProperty("sender_name")] public string SenderName { get; set; }
        [JsonProperty("removed")] public bool IsRemoved { get; set; }
        [JsonProperty("new")] public bool IsNew { get; set; }

        [JsonIgnore] public int AgeSeconds => (int) (DateTime.UtcNow - CreationDateTime).TotalSeconds;

        [JsonIgnore]
        public long SenderId
        {
            get => ((long) SenderHighId << 32) | (SenderLowId & 0xFFFFFFFFL);
            set
            {
                SenderHighId = Convert.ToInt32(value >> 32);
                SenderLowId = (int) value;
            }
        }

        public virtual void Encode(IByteBuffer packet)
        {
            // TODO
        }

        public virtual void SetSender(Player player)
        {
            SenderName = player.Home.Name;
            SenderId = player.Home.Id;
        }
    }
}