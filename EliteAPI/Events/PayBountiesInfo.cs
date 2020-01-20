using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PayBountiesInfo : IEvent
    {
        internal static PayBountiesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayBountiesEvent(JsonConvert.DeserializeObject<PayBountiesInfo>(json, EliteAPI.Events.PayBountiesConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }
        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }
}
