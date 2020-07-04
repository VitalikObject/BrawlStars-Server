using System.Collections.Generic;
using Newtonsoft.Json;

namespace BrawlStars.Logic
{
    internal class Calendar
    {
        [JsonProperty("events")] internal List<Event> Events = new List<Event>();
    }
}
