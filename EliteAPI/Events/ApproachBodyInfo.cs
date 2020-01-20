using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ApproachBodyInfo : IEvent
    {
        internal static ApproachBodyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeApproachBodyEvent(JsonConvert.DeserializeObject<ApproachBodyInfo>(json, EliteAPI.Events.ApproachBodyConverter.Settings));

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
    }
}
