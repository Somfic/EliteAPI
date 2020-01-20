using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SupercruiseExitInfo : EventBase
    {
        internal static SupercruiseExitInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseExitEvent(JsonConvert.DeserializeObject<SupercruiseExitInfo>(json, JsonSettings.Settings));

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
