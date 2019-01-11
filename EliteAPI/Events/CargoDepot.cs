namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CargoDepotInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; set; }

        [JsonProperty("UpdateType")]
        public string UpdateType { get; set; }

        [JsonProperty("CargoType")]
        public string CargoType { get; set; }

        [JsonProperty("CargoType_Localised")]
        public string CargoTypeLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("StartMarketID")]
        public long StartMarketId { get; set; }

        [JsonProperty("EndMarketID")]
        public long EndMarketId { get; set; }

        [JsonProperty("ItemsCollected")]
        public long ItemsCollected { get; set; }

        [JsonProperty("ItemsDelivered")]
        public long ItemsDelivered { get; set; }

        [JsonProperty("TotalItemsToDeliver")]
        public long TotalItemsToDeliver { get; set; }

        [JsonProperty("Progress")]
        public double Progress { get; set; }
    }

    public partial class CargoDepotInfo
    {
        public static CargoDepotInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeCargoDepotEvent(JsonConvert.DeserializeObject<CargoDepotInfo>(json, EliteAPI.Events.CargoDepotConverter.Settings));
    }

    public static class CargoDepotSerializer
    {
        public static string ToJson(this CargoDepotInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CargoDepotConverter.Settings);
    }

    internal static class CargoDepotConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
