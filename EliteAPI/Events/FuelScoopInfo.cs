using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FuelScoopInfo : IEvent
    {
        internal static FuelScoopInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFuelScoopEvent(JsonConvert.DeserializeObject<FuelScoopInfo>(json, EliteAPI.Events.FuelScoopConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }
        [JsonProperty("Total")]
        public double Total { get; internal set; }
    }
}
