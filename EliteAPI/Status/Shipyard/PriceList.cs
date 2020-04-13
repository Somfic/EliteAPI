using Newtonsoft.Json;

namespace EliteAPI.Status.Shipyard
{
    public class PriceList
    {
        internal PriceList() { }

        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; internal set; }
    }
}