using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SquadronCreatedInfo : EventBase
    {
        internal static SquadronCreatedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSquadronCreatedEvent(JsonConvert.DeserializeObject<SquadronCreatedInfo>(json, JsonSettings.Settings));

        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}
