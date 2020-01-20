using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UnderAttackInfo : EventBase
    {
        internal static UnderAttackInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeUnderAttackEvent(JsonConvert.DeserializeObject<UnderAttackInfo>(json, JsonSettings.Settings));

        [JsonProperty("Target")]
        public string Target { get; internal set; }
    }
}
