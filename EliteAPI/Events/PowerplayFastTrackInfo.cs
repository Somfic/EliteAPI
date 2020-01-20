using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayFastTrackInfo : EventBase
    {
        internal static PowerplayFastTrackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayFastTrackEvent(JsonConvert.DeserializeObject<PowerplayFastTrackInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
