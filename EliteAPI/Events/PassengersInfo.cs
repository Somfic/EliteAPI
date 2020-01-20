using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class PassengersInfo : IEvent
    {
        internal static PassengersInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, EliteAPI.Events.PassengersConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; internal set; }
    }
}
