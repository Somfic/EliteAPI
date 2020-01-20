using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CargoDepotInfo : IEvent
    {
        internal static CargoDepotInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCargoDepotEvent(JsonConvert.DeserializeObject<CargoDepotInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
        [JsonProperty("UpdateType")]
        public string UpdateType { get; internal set; }
        [JsonProperty("CargoType")]
        public string CargoType { get; internal set; }
        [JsonProperty("CargoType_Localised")]
        public string CargoTypeLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("StartMarketID")]
        public long StartMarketId { get; internal set; }
        [JsonProperty("EndMarketID")]
        public long EndMarketId { get; internal set; }
        [JsonProperty("ItemsCollected")]
        public long ItemsCollected { get; internal set; }
        [JsonProperty("ItemsDelivered")]
        public long ItemsDelivered { get; internal set; }
        [JsonProperty("TotalItemsToDeliver")]
        public long TotalItemsToDeliver { get; internal set; }
        [JsonProperty("Progress")]
        public double Progress { get; internal set; }
    }
}
