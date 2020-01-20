using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SupercruiseEntryInfo : EventBase
    {
        internal static SupercruiseEntryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseEntryEvent(JsonConvert.DeserializeObject<SupercruiseEntryInfo>(json, JsonSettings.Settings));

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
    }
}
