using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class MaterialsInfo : EventBase
    {
        internal MaterialsInfo() { }

        /// <summary>
        /// A list of raw materials, grouped by name.
        /// </summary>
        /// <see cref="MaterialInfo"/>
        [JsonProperty("Raw")]
        public IReadOnlyList<MaterialInfo> Raw { get; internal set; }

        /// <summary>
        /// A list of manufactured materials, grouped by name.
        /// </summary>
        /// <see cref="MaterialInfo"/>
        [JsonProperty("Manufactured")]
        public IReadOnlyList<MaterialInfo> Manufactured { get; internal set; }

        /// <summary>
        /// A list of encoded materials, grouped by name.
        /// </summary>
        /// <see cref="MaterialInfo"/>
        [JsonProperty("Encoded")]
        public IReadOnlyList<MaterialInfo> Encoded { get; internal set; }

        internal static MaterialsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, JsonSettings.Settings));
        }
    }

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