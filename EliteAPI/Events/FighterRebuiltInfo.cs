using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FighterRebuiltInfo : EventBase
    {
        internal static FighterRebuiltInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterRebuiltEvent(JsonConvert.DeserializeObject<FighterRebuiltInfo>(json, JsonSettings.Settings));

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }
    }
}
