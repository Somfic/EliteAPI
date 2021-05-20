using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Status.Backpack.Raw
{
    public class RawShipyard : EventBase<RawShipyard>
    {
        [JsonProperty("MarketID")]
        public string MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool HasHorizons { get; set; }

        [JsonProperty("AllowCobraMkIV")]
        public bool AllowsCobraMk4 { get; set; }

        [JsonProperty("PriceList")]
        public IReadOnlyList<ShipyardDeal> Deals { get; set; }
    }
}