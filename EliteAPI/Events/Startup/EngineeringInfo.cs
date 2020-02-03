using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// The engineering that has been done on a module.
    /// </summary>
    public class EngineeringInfo
    {
        internal EngineeringInfo() { }

        /// <summary>
        /// The name of the engineer.
        /// </summary>
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        /// <summary>
        /// The id of the engineer.
        /// </summary>
        [JsonProperty("EngineerID")]
        public int EngineerId { get; internal set; }

        /// <summary>
        /// The id of the blueprint.
        /// </summary>
        [JsonProperty("BlueprintID")]
        public int BlueprintId { get; internal set; }

        /// <summary>
        /// The name of the blueprint.
        /// </summary>
        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }

        /// <summary>
        /// The level of the modification.
        /// </summary>
        [JsonProperty("Level")]
        public int Level { get; internal set; }

        /// <summary>
        /// The quality of the modification.
        /// </summary>
        [JsonProperty("Quality")]
        public float Quality { get; internal set; }

        /// <summary>
        /// The experimental effect of the modification, if any.
        /// </summary>
        [JsonProperty("ExperimentalEffect", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffect { get; internal set; }

        /// <summary>
        /// The localised experimental effect of the modification, if any.
        /// </summary>
        [JsonProperty("ExperimentalEffect_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffectLocalised { get; internal set; }

        /// <summary>
        /// A list of modifiers for this modification, if any.
        /// </summary>
        [JsonProperty("Modifiers")]
        public IReadOnlyList<LoadOutModifier> Modifiers { get; internal set; }
    }
}