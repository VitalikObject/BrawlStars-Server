using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Clan.StreamEntry.Entries
{
    public class AllianceEventStreamEntry : AllianceStreamEntry
    {
        public enum Type
        {
            Kick = 1,
            Accepted = 2,
            Join = 3,
            Leave = 4,
            Promote = 5,
            Demote = 6
        }

        public AllianceEventStreamEntry()
        {
            StreamEntryType = 4;
        }

        [JsonProperty("eventType")] public Type EventType { get; set; }
        [JsonProperty("targetHighId")] public int TargetHighId { get; set; }
        [JsonProperty("targetLowId")] public int TargetLowId { get; set; }
        [JsonProperty("targetName")] public string TargetName { get; set; }

        public override void Encode(IByteBuffer packet)
        {
            base.Encode(packet);

            // TODO
        }

        public void SetTarget(Player target)
        {
            TargetHighId = target.Home.HighId;
            TargetLowId = target.Home.LowId;
            TargetName = target.Home.Name;
        }
    }
}