namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AfmuRepairsInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }
    }

    public partial class AfmuRepairsInfo
    {
        public static AfmuRepairsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAfmuRepairsEvent(JsonConvert.DeserializeObject<AfmuRepairsInfo>(json, EliteAPI.Events.AfmuRepairsConverter.Settings));
    }

    

    internal static class AfmuRepairsConverter
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
