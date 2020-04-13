using Newtonsoft.Json;

namespace EliteAPI.Status.Outfitting
{
    public class Item
    {
        internal Item () { }

        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }
    }
}