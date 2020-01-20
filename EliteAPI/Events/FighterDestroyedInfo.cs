using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FighterDestroyedInfo : IEvent
    {
        internal static FighterDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterDestroyedEvent(JsonConvert.DeserializeObject<FighterDestroyedInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
    }
}
