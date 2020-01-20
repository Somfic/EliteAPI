using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class EngineerCraftInfo : EventBase
    {
        internal static EngineerCraftInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerCraftEvent(JsonConvert.DeserializeObject<EngineerCraftInfo>(json, JsonSettings.Settings));

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("Module")]
        public string Module { get; internal set; }
        [JsonProperty("ApplyExperimentalEffect")]
        public string ApplyExperimentalEffect { get; internal set; }
        [JsonProperty("Ingredients")]
        public List<Ingredient> Ingredients { get; internal set; }
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }
        [JsonProperty("EngineerID")]
        public long EngineerId { get; internal set; }
        [JsonProperty("BlueprintID")]
        public long BlueprintId { get; internal set; }
        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }
        [JsonProperty("Level")]
        public long Level { get; internal set; }
        [JsonProperty("Quality")]
        public double Quality { get; internal set; }
        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; internal set; }
        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; internal set; }
        [JsonProperty("Modifiers")]
        public List<Modifier> Modifiers { get; internal set; }
    }
}
