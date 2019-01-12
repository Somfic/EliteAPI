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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItem { get; set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }

        [JsonProperty("Quality")]
        public double Quality { get; set; }

        [JsonProperty("SwapOutItem")]
        public string SwapOutItem { get; set; }

        [JsonProperty("SwapOutItem_Localised")]
        public string SwapOutItemLocalised { get; set; }
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
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
