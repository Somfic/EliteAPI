using System.Collections.Generic;

using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Status.Outfitting.Raw
{
    public class RawOutfitting : EventBase<RawOutfitting>
    {
        [JsonProperty("MarketID")]
        public string MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; set; }

        [JsonProperty("Items")]
        public IReadOnlyList<OutfittingItem> Deals { get; set; }
    }
}