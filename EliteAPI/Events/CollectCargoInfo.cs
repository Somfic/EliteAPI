using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CollectCargoInfo : EventBase
    {
        internal static CollectCargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCollectCargoEvent(JsonConvert.DeserializeObject<CollectCargoInfo>(json, JsonSettings.Settings));

        [JsonProperty("Type")]
        public string Type { get; internal set; }
        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }
        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }
    }
}
