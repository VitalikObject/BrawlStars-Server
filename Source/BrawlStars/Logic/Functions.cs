using Newtonsoft.Json;

namespace BrawlStars.Logic
{
    internal class Functions
    {
        [JsonProperty("name")] internal string Name = string.Empty;

        [JsonProperty("parameters")] internal string[] Parameters;
    }
}
