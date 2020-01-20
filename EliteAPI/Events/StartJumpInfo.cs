using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class StartJumpInfo : IEvent
    {
        internal static StartJumpInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStartJumpEvent(JsonConvert.DeserializeObject<StartJumpInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("JumpType")]
        public string JumpType { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }
    }
}
