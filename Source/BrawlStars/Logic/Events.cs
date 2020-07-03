using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BrawlStars.Logic
{
    internal class Event
    {
        [JsonProperty("boomboxEntry")] internal string BoomBoxEntry = string.Empty;

        [JsonProperty("endTime")] internal string EndTime = DateTime.UtcNow.ToString();

        [JsonProperty("eventEntryName")] internal string EventEntryName = string.Empty;

        [JsonProperty("functions")] internal List<Functions> Functions = new List<Functions>();
        [JsonProperty("id")] internal int ID;

        [JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Ignore)]
        internal string Image = string.Empty;

        [JsonProperty("inboxEntryId")] internal int InboxEntryID;

        [JsonProperty("localization", DefaultValueHandling = DefaultValueHandling.Ignore)]
        internal string Localization = string.Empty;

        [JsonProperty("name")] internal string Name = string.Empty;

        [JsonProperty("notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
        internal string Notification = string.Empty;

        [JsonProperty("sc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        internal string SCFile = string.Empty;

        [JsonProperty("showUpcoming")] internal int ShowUpcoming = 1;

        [JsonProperty("startTime")] internal string StarTime = DateTime.UtcNow.ToString();

        [JsonProperty("visibleTime")] internal string VisibleTime = DateTime.UtcNow.ToString();
    }
}
