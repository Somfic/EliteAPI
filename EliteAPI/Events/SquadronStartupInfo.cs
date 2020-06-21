using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SquadronStartupInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; set; }

        [JsonProperty("CurrentRank")]
        public long CurrentRank { get; set; }

        internal static SquadronStartupInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSquadronStartupEvent(JsonConvert.DeserializeObject<SquadronStartupInfo>(json, JsonSettings.Settings));
        }
    }
}