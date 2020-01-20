using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayFastTrackInfo : IEvent
    {
        internal static PowerplayFastTrackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayFastTrackEvent(JsonConvert.DeserializeObject<PowerplayFastTrackInfo>(json, EliteAPI.Events.PowerplayFastTrackConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
