using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class AfmuRepairsEvent : EventBase
    {
        internal AfmuRepairsEvent() { }

        public static AfmuRepairsEvent FromJson(string json) => JsonConvert.DeserializeObject<AfmuRepairsEvent>(json);


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
        public float Health { get; internal set; }


    }
}