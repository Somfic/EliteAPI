using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class NpcCrewPaidWageInfo : IEvent
    {
        internal static NpcCrewPaidWageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeNpcCrewPaidWageEvent(JsonConvert.DeserializeObject<NpcCrewPaidWageInfo>(json, EliteAPI.Events.NpcCrewPaidWageConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; internal set; }
        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}
