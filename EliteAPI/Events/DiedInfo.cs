using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DiedInfo : EventBase
    {
        internal static DiedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDiedEvent(JsonConvert.DeserializeObject<DiedInfo>(json, JsonSettings.Settings));

        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }
        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }
        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }
        [JsonProperty("KillerRank")]
        public string KillerRank { get; internal set; }
    }
}
