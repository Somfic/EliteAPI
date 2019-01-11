namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FetchRemoteModuleInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; set; }

        [JsonProperty("StoredItem")]
        public string StoredItem { get; set; }

        [JsonProperty("StoredItem_Localised")]
        public string StoredItemLocalised { get; set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }
    }

    public partial class FetchRemoteModuleInfo
    {
        public static FetchRemoteModuleInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeFetchRemoteModuleEvent(JsonConvert.DeserializeObject<FetchRemoteModuleInfo>(json, EliteAPI.Events.FetchRemoteModuleConverter.Settings));
    }

    public static class FetchRemoteModuleSerializer
    {
        public static string ToJson(this FetchRemoteModuleInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FetchRemoteModuleConverter.Settings);
    }

    internal static class FetchRemoteModuleConverter
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
