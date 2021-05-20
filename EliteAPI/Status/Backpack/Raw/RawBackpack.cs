using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Status.Backpack.Raw
{
    public class RawBackpack : EventBase<RawBackpack>
    {
        [JsonProperty("Items")]
        public IReadOnlyList<BackpackItem> Items { get; set; }

        [JsonProperty("Components")]
        public IReadOnlyList<BackpackItem> Components { get; set; }

        [JsonProperty("Consumables")]
        public IReadOnlyList<BackpackItem> Consumables { get; set; }

        [JsonProperty("Data")]
        public IReadOnlyList<BackpackItem> Data { get; set; }
    }
}