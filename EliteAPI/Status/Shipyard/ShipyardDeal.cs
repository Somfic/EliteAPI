using Newtonsoft.Json;

namespace EliteAPI.Status.Shipyard
{
    public class ShipyardDeal
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; set; }
    }
}