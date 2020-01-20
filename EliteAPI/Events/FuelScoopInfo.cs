using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FuelScoopInfo : EventBase
    {
        internal static FuelScoopInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFuelScoopEvent(JsonConvert.DeserializeObject<FuelScoopInfo>(json, JsonSettings.Settings));

        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }
        [JsonProperty("Total")]
        public double Total { get; internal set; }
    }
}
