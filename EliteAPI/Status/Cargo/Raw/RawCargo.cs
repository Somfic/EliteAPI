using System.Collections.Generic;

using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Status.Cargo.Raw
{
    public class RawCargo : EventBase<RawCargo>
    {
        [JsonProperty("Vessel")]
        public string Vessel { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Inventory")]
        public IReadOnlyList<CargoItem> Inventory { get; set; }
    }
}