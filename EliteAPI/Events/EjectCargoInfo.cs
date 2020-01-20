using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EjectCargoInfo : IEvent
    {
        internal static EjectCargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEjectCargoEvent(JsonConvert.DeserializeObject<EjectCargoInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        [JsonProperty("Abandoned")]
        public bool Abandoned { get; internal set; }
    }
}
