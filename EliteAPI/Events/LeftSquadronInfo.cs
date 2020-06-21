using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class LeftSquadronInfo : EventBase
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }

        internal static LeftSquadronInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLeftSquadronEvent(JsonConvert.DeserializeObject<LeftSquadronInfo>(json, JsonSettings.Settings));
        }
    }
}