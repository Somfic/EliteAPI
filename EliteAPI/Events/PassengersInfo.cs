using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class PassengersInfo : EventBase
    {
        internal static PassengersInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePassengersEvent(JsonConvert.DeserializeObject<PassengersInfo>(json, JsonSettings.Settings));

        [JsonProperty("Manifest")]
        public List<Manifest> Manifest { get; internal set; }
    }
}
