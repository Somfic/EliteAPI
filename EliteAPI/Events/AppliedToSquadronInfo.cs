using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AppliedToSquadronInfo : EventBase
    {
        internal static AppliedToSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAppliedToSquadronEvent(JsonConvert.DeserializeObject<AppliedToSquadronInfo>(json, JsonSettings.Settings));

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
