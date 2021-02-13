using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class EngineerCraftEvent : EventBase
    {
        internal EngineerCraftEvent() { }

        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("Module")]
        public string Module { get; private set; }

        [JsonProperty("IngredientInfos")]
        public IReadOnlyList<IngredientInfo> IngredientInfos { get; private set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; private set; }

        [JsonProperty("EngineerID")]
        public string EngineerId { get; private set; }

        [JsonProperty("BlueprintID")]
        public string BlueprintId { get; private set; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; private set; }

        [JsonProperty("Level")]
        public int Level { get; private set; }

        [JsonProperty("Quality")]
        public double Quality { get; private set; }

        [JsonProperty("ModifierInfos")]
        public IReadOnlyList<ModifierInfo> ModifierInfos { get; private set; }
        
        public class IngredientInfo
        {
            internal IngredientInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Count")]
            public long Count { get; private set; }

            [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
            public string NameLocalised { get; private set; }
        }

        public class ModifierInfo
        {
            internal ModifierInfo() { }

            [JsonProperty("Label")]
            public string Label { get; private set; }

            [JsonProperty("Value")]
            public double Value { get; private set; }

            [JsonProperty("OriginalValue")]
            public double OriginalValue { get; private set; }

            [JsonProperty("LessIsGood")]
            public long LessIsGood { get; private set; }
        }
    }

    public partial class EngineerCraftEvent
    {
        public static EngineerCraftEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EngineerCraftEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EngineerCraftEvent> EngineerCraftEvent;

        internal void InvokeEngineerCraftEvent(EngineerCraftEvent arg)
        {
            EngineerCraftEvent?.Invoke(this, arg);
        }
    }
}