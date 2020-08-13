using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FSSSignalDiscoveredEvent : EventBase
    {
        internal FSSSignalDiscoveredEvent() { }
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
        public float TimeRemaining { get; internal set; }

        
    }
}