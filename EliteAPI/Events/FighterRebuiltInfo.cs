using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FighterRebuiltInfo : IEvent
    {
        internal static FighterRebuiltInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterRebuiltEvent(JsonConvert.DeserializeObject<FighterRebuiltInfo>(json, EliteAPI.Events.FighterRebuiltConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
    }
}
