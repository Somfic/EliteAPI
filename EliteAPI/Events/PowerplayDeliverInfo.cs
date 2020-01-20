using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayDeliverInfo : EventBase
    {
        internal static PowerplayDeliverInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDeliverEvent(JsonConvert.DeserializeObject<PowerplayDeliverInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}
