using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayDeliverInfo : IEvent
    {
        internal static PowerplayDeliverInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDeliverEvent(JsonConvert.DeserializeObject<PowerplayDeliverInfo>(json, EliteAPI.Events.PowerplayDeliverConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
