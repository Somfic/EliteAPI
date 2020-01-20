using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PayFinesInfo : IEvent
    {
        internal static PayFinesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayFinesEvent(JsonConvert.DeserializeObject<PayFinesInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
        [JsonProperty("AllFines")]
        public bool AllFines { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
    }
}
