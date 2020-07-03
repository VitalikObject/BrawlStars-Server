using System.Collections.Generic;
using Newtonsoft.Json;

namespace BrawlStars.Logic
{
    internal class Brawler
    {
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)] internal string name = string.Empty;

        [JsonProperty("skin", DefaultValueHandling = DefaultValueHandling.Ignore)] internal string Skin = string.Empty;

        [JsonProperty("hassSkin")] internal bool HassSkin;

        [JsonProperty("trophies")] internal int Trophies;

        [JsonProperty("highestTrophies")] internal int HighestTrophies;

        [JsonProperty("power")] internal int Power;
 
        [JsonProperty("rank")] internal int rank;
    }
}