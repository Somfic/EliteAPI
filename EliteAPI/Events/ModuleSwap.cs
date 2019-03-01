namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleSwapInfo
    {
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

    public partial class ModuleSwapInfo
    {
        public static ModuleSwapInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleSwapEvent(JsonConvert.DeserializeObject<ModuleSwapInfo>(json, EliteAPI.Events.ModuleSwapConverter.Settings));
    }

    public static class ModuleSwapSerializer
    {
        public static string ToJson(this ModuleSwapInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleSwapConverter.Settings);
    }

    internal static class ModuleSwapConverter
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
