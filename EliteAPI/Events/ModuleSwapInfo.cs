using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleSwapInfo : IEvent
    {
        internal static ModuleSwapInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleSwapEvent(JsonConvert.DeserializeObject<ModuleSwapInfo>(json, EliteAPI.Events.ModuleSwapConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
