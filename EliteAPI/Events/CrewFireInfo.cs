using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CrewFireInfo : EventBase
    {
        internal static CrewFireInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewFireEvent(JsonConvert.DeserializeObject<CrewFireInfo>(json, JsonSettings.Settings));

        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
    }
}
