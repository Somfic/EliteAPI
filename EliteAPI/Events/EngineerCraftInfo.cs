using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EngineerCraftInfo : EventBase
    {
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
        public float Quality { get; internal set; }

        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; internal set; }

        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; internal set; }

        [JsonProperty("Modifiers")]
        public List<Modifier> Modifiers { get; internal set; }

        internal static EngineerCraftInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEngineerCraftEvent(JsonConvert.DeserializeObject<EngineerCraftInfo>(json, JsonSettings.Settings));
        }
    }
}