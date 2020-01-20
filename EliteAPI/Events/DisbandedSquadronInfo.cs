using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DisbandedSquadronInfo : EventBase
    {
        internal static DisbandedSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDisbandedSquadronEvent(JsonConvert.DeserializeObject<DisbandedSquadronInfo>(json, JsonSettings.Settings));

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
