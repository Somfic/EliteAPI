using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AfmuRepairsInfo : IEvent
    {
        internal static AfmuRepairsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAfmuRepairsEvent(JsonConvert.DeserializeObject<AfmuRepairsInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        /// <summary>
        /// The name of the module
        /// </summary>
        [JsonProperty("Module")]
        public string Module { get; internal set; }
        /// <summary>
        /// The local name of the module
        /// </summary>
        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }
        /// <summary>
        /// Whether modules are now fully repaired
        /// </summary>
        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; internal set; }
        /// <summary>
        /// Value between 0 and 1.
        /// </summary>
        [JsonProperty("Health")]
        public double Health { get; internal set; }
    }
}
