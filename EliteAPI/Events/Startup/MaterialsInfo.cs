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
        /// <see cref="MaterialsMaterial"/>
        [JsonProperty("Raw")]
        public IReadOnlyList<MaterialsMaterial> Raw { get; internal set; }

        /// <summary>
        /// A list of manufactured materials, grouped by name.
        /// </summary>
        /// <see cref="MaterialsMaterial"/>
        [JsonProperty("Manufactured")]
        public IReadOnlyList<MaterialsMaterial> Manufactured { get; internal set; }

        /// <summary>
        /// A list of encoded materials, grouped by name.
        /// </summary>
        /// <see cref="MaterialsMaterial"/>
        [JsonProperty("Encoded")]
        public IReadOnlyList<MaterialsMaterial> Encoded { get; internal set; }

        internal static MaterialsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, JsonSettings.Settings));
        }
    }
}