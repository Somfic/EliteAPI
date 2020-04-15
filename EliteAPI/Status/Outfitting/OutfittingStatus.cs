using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Outfitting
{
    public class OutfittingStatus : StatusBase
    {
        internal OutfittingStatus() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; internal set; }

        [JsonProperty("Items")]
        public IReadOnlyList<Item> Items { get; internal set; }

        internal override StatusBase Default => new OutfittingStatus();
    }
}
