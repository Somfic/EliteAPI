using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BuyAmmoInfo : EventBase
    {
        internal static BuyAmmoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyAmmoEvent(JsonConvert.DeserializeObject<BuyAmmoInfo>(json, JsonSettings.Settings));

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
}
