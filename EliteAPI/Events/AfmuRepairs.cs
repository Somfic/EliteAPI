namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AfmuRepairsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Module")]
        public string Module { get; set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; set; }

        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; set; }

        [JsonProperty("Health")]
        public double Health { get; set; }
    }

    public partial class AfmuRepairsInfo
    {
        public static AfmuRepairsInfo Process(string json) => EventHandler.InvokeAfmuRepairsEvent(JsonConvert.DeserializeObject<AfmuRepairsInfo>(json, EliteAPI.Events.AfmuRepairsConverter.Settings));
    }

    public static class AfmuRepairsSerializer
    {
        public static string ToJson(this AfmuRepairsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.AfmuRepairsConverter.Settings);
    }

    internal static class AfmuRepairsConverter
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
