using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// The modifier applied on a modification.
    /// </summary>
    public class LoadOutModifier
    {
        internal LoadOutModifier() { }

        /// <summary>
        /// The label of this modifier.
        /// </summary>
        /// <see cref="ModifierLabel"/>
        [JsonProperty("Label")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModifierLabel Label { get; internal set; }

        /// <summary>
        /// The value of this modifier.
        /// </summary>
        [JsonProperty("Value")]
        public float Value { get; internal set; }

        /// <summary>
        /// The value of this modifier as a string.
        /// </summary>
        [JsonProperty("Value")]
        public string ValueStr { get; internal set; }

        /// <summary>
        /// The original value before this modifier.
        /// </summary>
        [JsonProperty("OriginalValue")]
        public float OriginalValue { get; internal set; }

        /// <summary>
        /// Whether a lower value means better.
        /// </summary>
        /// <see cref="Value"/>
        [JsonProperty("LessIsGood")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool LessIsGood { get; internal set; }
    }
}