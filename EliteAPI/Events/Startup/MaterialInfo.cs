using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// Contains information about grouped material.
    /// </summary>
    /// <see cref="MaterialsInfo"/>
    public class MaterialInfo
    {
        internal MaterialInfo() { }

        /// <summary>
        /// The name of the material.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The localised name of the material.
        /// </summary>
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        /// <summary>
        /// The amount of materials in this group.
        /// </summary>
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}