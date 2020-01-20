using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FSSSignalDiscoveredInfo : IEvent
    {
        internal static FSSSignalDiscoveredInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSSSignalDiscoveredEvent(JsonConvert.DeserializeObject<FSSSignalDiscoveredInfo>(json, EliteAPI.Events.FSSSignalDiscoveredConverter.Settings));

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
}
