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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("FromSlot")]
        public string FromSlot { get; set; }

        [JsonProperty("ToSlot")]
        public string ToSlot { get; set; }

        [JsonProperty("FromItem")]
        public string FromItem { get; set; }

        [JsonProperty("FromItem_Localised")]
        public string FromItemLocalised { get; set; }

        [JsonProperty("ToItem")]
        public string ToItem { get; set; }

        [JsonProperty("ToItem_Localised")]
        public string ToItemLocalised { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }
    }

    public partial class ModuleSwapInfo
    {
        public static ModuleSwapInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeModuleSwapEvent(JsonConvert.DeserializeObject<ModuleSwapInfo>(json, EliteAPI.Events.ModuleSwapConverter.Settings));
    }

    public static class ModuleSwapSerializer
    {
        public static string ToJson(this ModuleSwapInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleSwapConverter.Settings);
    }

    internal static class ModuleSwapConverter
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
