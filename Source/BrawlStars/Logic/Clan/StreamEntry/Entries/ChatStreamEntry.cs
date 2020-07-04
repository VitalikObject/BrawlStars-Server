using BrawlStars.Utilities.Netty;
using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Clan.StreamEntry.Entries
{
    public class ChatStreamEntry : AllianceStreamEntry
    {
        public ChatStreamEntry()
        {
            StreamEntryType = 2;
        }

        [JsonProperty("msg")] public string Message { get; set; }

        public override void Encode(IByteBuffer packet)
        {
            base.Encode(packet);

            packet.WriteScString(Message);
        }
    }
}