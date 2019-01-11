namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FSSSignalDiscoveredInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("SignalName")]
        public string SignalName { get; set; }

        [JsonProperty("SignalName_Localised")]
        public string SignalNameLocalised { get; set; }

        [JsonProperty("USSType")]
        public string UssType { get; set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [JsonProperty("SpawningState")]
        public string SpawningState { get; set; }

        [JsonProperty("SpawningState_Localised")]
        public string SpawningStateLocalised { get; set; }

        [JsonProperty("SpawningFaction")]
        public string SpawningFaction { get; set; }

        [JsonProperty("ThreatLevel")]
        public long ThreatLevel { get; set; }

        [JsonProperty("TimeRemaining")]
        public double TimeRemaining { get; set; }
    }

    public partial class FSSSignalDiscoveredInfo
    {
        public static FSSSignalDiscoveredInfo Process(string json) => EventHandler.InvokeFSSSignalDiscoveredEvent(JsonConvert.DeserializeObject<FSSSignalDiscoveredInfo>(json, EliteAPI.Events.FSSSignalDiscoveredConverter.Settings));
    }

    public static class FSSSignalDiscoveredSerializer
    {
        public static string ToJson(this FSSSignalDiscoveredInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSSSignalDiscoveredConverter.Settings);
    }

    internal static class FSSSignalDiscoveredConverter
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
