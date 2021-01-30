using System.Collections.Generic;

using Newtonsoft.Json;

namespace EliteAPI.Status.Cargo.Raw
{
    internal class RawCargo
    {
        [JsonProperty("Vessel")]
        public string Vessel { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoItem> Inventory { get; set; }
    }
}