namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ModuleRetrieveInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItem { get; internal set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public double Quality { get; internal set; }

        [JsonProperty("SwapOutItem")]
        public string SwapOutItem { get; internal set; }

        [JsonProperty("SwapOutItem_Localised")]
        public string SwapOutItemLocalised { get; internal set; }
    }

    public partial class ModuleRetrieveInfo
    {
        public static ModuleRetrieveInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleRetrieveEvent(JsonConvert.DeserializeObject<ModuleRetrieveInfo>(json, EliteAPI.Events.ModuleRetrieveConverter.Settings));
    }

    public static class ModuleRetrieveSerializer
    {
        public static string ToJson(this ModuleRetrieveInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ModuleRetrieveConverter.Settings);
    }

    internal static class ModuleRetrieveConverter
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
