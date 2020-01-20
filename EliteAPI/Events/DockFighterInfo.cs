using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockFighterInfo : IEvent
    {
        internal static DockFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockFighterEvent(JsonConvert.DeserializeObject<DockFighterInfo>(json, EliteAPI.Events.DockFighterConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
