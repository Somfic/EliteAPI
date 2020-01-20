using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UnderAttackInfo : IEvent
    {
        internal static UnderAttackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUnderAttackEvent(JsonConvert.DeserializeObject<UnderAttackInfo>(json, EliteAPI.Events.UnderAttackConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Target")]
        public string Target { get; internal set; }
    }
}
