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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("StoredItem")]
        public string StoredItem { get; internal set; }

        [JsonProperty("StoredItem_Localised")]
        public string StoredItemLocalised { get; internal set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
    }

    public partial class FetchRemoteModuleInfo
    {
        public static FetchRemoteModuleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFetchRemoteModuleEvent(JsonConvert.DeserializeObject<FetchRemoteModuleInfo>(json, EliteAPI.Events.FetchRemoteModuleConverter.Settings));
    }

    public static class FetchRemoteModuleSerializer
    {
        public static string ToJson(this FetchRemoteModuleInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FetchRemoteModuleConverter.Settings);
    }

    internal static class FetchRemoteModuleConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
