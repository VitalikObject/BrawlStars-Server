using DotNetty.Buffers;
using Newtonsoft.Json;

namespace BrawlStars.Logic.Home.Slots.Items
{
    public class DataSlot
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("cnt")] public int Count { get; set; }

        /// <summary>
        ///     Encodes this dataslot
        /// </summary>
        /// <param name="buffer"></param>
        public virtual void Encode(IByteBuffer buffer)
        {
            buffer.WriteInt(Id);
            buffer.WriteInt(Count);
        }
    }
}