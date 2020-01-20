using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    //{ "timestamp":"2019-10-15T17:50:50Z", "event":"FSDTarget", "Name":"Crucis Sector JC-V b2-5", "SystemAddress":11666607580601, "RemainingJumpsInRoute":2 }

    public class FSDTargetInfo : IEvent
    {
        internal static FSDTargetInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSDTargetEvent(JsonConvert.DeserializeObject<FSDTargetInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }
        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; internal set; }
    }
}
