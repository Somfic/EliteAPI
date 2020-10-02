using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ModuleSwapEvent : EventBase
    {
        internal ModuleSwapEvent() { }

        public static ModuleSwapEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleSwapEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("FromSlot")]
        public string FromSlot { get; internal set; }

        [JsonProperty("ToSlot")]
        public string ToSlot { get; internal set; }

        [JsonProperty("FromItem")]
        public string FromItem { get; internal set; }

        [JsonProperty("FromItem_Localised")]
        public string FromItemLocalised { get; internal set; }

        [JsonProperty("ToItem")]
        public string ToItem { get; internal set; }

        [JsonProperty("ToItem_Localised")]
        public string ToItemLocalised { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        
    }
}