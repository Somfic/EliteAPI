using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SelfDestructInfo : IEvent
    {
        internal static SelfDestructInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSelfDestructEvent(JsonConvert.DeserializeObject<SelfDestructInfo>(json, EliteAPI.Events.SelfDestructConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
