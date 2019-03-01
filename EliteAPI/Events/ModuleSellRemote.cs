namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleSellRemoteInfo
    {
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

    public partial class ModuleSellRemoteInfo
    {
        public static ModuleSellRemoteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleSellRemoteEvent(JsonConvert.DeserializeObject<ModuleSellRemoteInfo>(json, EliteAPI.Events.ModuleSellRemoteConverter.Settings));
    }

    public static class ModuleSellRemoteSerializer
    {
        public static string ToJson(this ModuleSellRemoteInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleSellRemoteConverter.Settings);
    }

    internal static class ModuleSellRemoteConverter
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
