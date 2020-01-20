using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SAAScanCompleteInfo : IEvent
    {
        internal static SAAScanCompleteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSAAScanCompleteEvent(JsonConvert.DeserializeObject<SAAScanCompleteInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }
        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; internal set; }
        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; internal set; }
    }
}
