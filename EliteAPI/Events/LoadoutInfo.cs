using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class LoadoutInfo : IEvent
    {
        internal static LoadoutInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLoadoutEvent(JsonConvert.DeserializeObject<LoadoutInfo>(json, EliteAPI.Events.LoadoutConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }
        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }
        [JsonProperty("HullValue")]
        public long HullValue { get; internal set; }
        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; internal set; }
        [JsonProperty("HullHealth")]
        public double HullHealth { get; internal set; }
        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }
        [JsonProperty("Rebuy")]
        public long Rebuy { get; internal set; }
        [JsonProperty("Modules")]
        public List<Module> Modules { get; internal set; }
    }
}
