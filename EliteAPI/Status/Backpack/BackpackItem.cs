using Newtonsoft.Json;

namespace EliteAPI.Status.Backpack
{
    public class BackpackItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("OwnerID")]
        public string OwnerId { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }
    }
}