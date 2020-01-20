using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SupercruiseExitInfo : IEvent
    {
        internal static SupercruiseExitInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseExitEvent(JsonConvert.DeserializeObject<SupercruiseExitInfo>(json, EliteAPI.Events.SupercruiseExitConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("Body")]
        public string Body { get; internal set; }
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }
        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }
    }
}
