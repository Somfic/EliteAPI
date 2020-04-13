using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Shipyard
{
    public class ShipyardStatus : EventBase, IStatus
    {
        internal ShipyardStatus() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; internal set; }

        [JsonProperty("AllowCobraMkIV")]
        public bool AllowCobraMkIv { get; internal set; }

        [JsonProperty("PriceList")]
        public IReadOnlyList<PriceList> PriceList { get; internal set; }
    }
}
