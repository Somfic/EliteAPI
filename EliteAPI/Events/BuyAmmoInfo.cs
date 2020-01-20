using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyAmmoInfo : IEvent
    {
        internal static BuyAmmoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyAmmoEvent(JsonConvert.DeserializeObject<BuyAmmoInfo>(json, EliteAPI.Events.BuyAmmoConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
