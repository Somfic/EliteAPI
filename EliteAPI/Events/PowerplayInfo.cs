using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayInfo : IEvent
    {
        internal static PowerplayInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayEvent(JsonConvert.DeserializeObject<PowerplayInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Rank")]
        public long Rank { get; internal set; }
        [JsonProperty("Merits")]
        public long Merits { get; internal set; }
        [JsonProperty("Votes")]
        public long Votes { get; internal set; }
        [JsonProperty("TimePledged")]
        public long TimePledged { get; internal set; }
    }
}
