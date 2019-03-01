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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("SignalName")]
        public string SignalName { get; internal set; }

        [JsonProperty("SignalName_Localised")]
        public string SignalNameLocalised { get; internal set; }

        [JsonProperty("USSType")]
        public string UssType { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }

        [JsonProperty("SpawningState")]
        public string SpawningState { get; internal set; }

        [JsonProperty("SpawningState_Localised")]
        public string SpawningStateLocalised { get; internal set; }

        [JsonProperty("SpawningFaction")]
        public string SpawningFaction { get; internal set; }

        [JsonProperty("ThreatLevel")]
        public long ThreatLevel { get; internal set; }

        [JsonProperty("TimeRemaining")]
        public double TimeRemaining { get; internal set; }
    }

    public partial class FSSSignalDiscoveredInfo
    {
        public static FSSSignalDiscoveredInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSSignalDiscoveredEvent(JsonConvert.DeserializeObject<FSSSignalDiscoveredInfo>(json, EliteAPI.Events.FSSSignalDiscoveredConverter.Settings));
    }

    public static class FSSSignalDiscoveredSerializer
    {
        public static string ToJson(this FSSSignalDiscoveredInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FSSSignalDiscoveredConverter.Settings);
    }

    internal static class FSSSignalDiscoveredConverter
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
