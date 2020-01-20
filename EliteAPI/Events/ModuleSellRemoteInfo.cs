using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleSellRemoteInfo : IEvent
    {
        internal static ModuleSellRemoteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleSellRemoteEvent(JsonConvert.DeserializeObject<ModuleSellRemoteInfo>(json, EliteAPI.Events.ModuleSellRemoteConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }
        [JsonProperty("SellItem")]
        public string SellItem { get; internal set; }
        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; internal set; }
        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }
        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
    }
}
