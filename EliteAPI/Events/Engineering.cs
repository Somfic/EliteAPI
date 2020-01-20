using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Engineering
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }
        [JsonProperty("EngineerID")]
        public ulong EngineerId { get; internal set; }
        [JsonProperty("BlueprintID")]
        public ulong BlueprintId { get; internal set; }
        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }
        [JsonProperty("Level")]
        public long Level { get; internal set; }
        [JsonProperty("Quality")]
        public double Quality { get; internal set; }
        [JsonProperty("ExperimentalEffect", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffect { get; internal set; }
        [JsonProperty("ExperimentalEffect_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffectLocalised { get; internal set; }
        [JsonProperty("Modifiers")]
        public List<LoadOutModifier> Modifiers { get; internal set; }
    }
}