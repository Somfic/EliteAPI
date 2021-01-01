using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EliteAPI.Status.Market.Raw
{
    internal class RawMarket
    {
        [JsonProperty("MarketID")]
        public string MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Items")]
        public IReadOnlyList<Commodity> Commodities { get; set; }
    }
}