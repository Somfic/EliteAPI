using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class LoadoutEvent : EventBase
    {
        internal LoadoutEvent() { }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; private set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; private set; }

        [JsonProperty("HullValue")]
        public long HullValue { get; private set; }
        
        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; private set; }

        [JsonProperty("ModuleInfosValue")]
        public long ModuleInfosValue { get; private set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; private set; }

        [JsonProperty("UnladenMass")]
        public double UnladenMass { get; private set; }

        [JsonProperty("CargoCapacity")]
        public long CargoCapacity { get; private set; }

        [JsonProperty("MaxJumpRange")]
        public double MaxJumpRange { get; private set; }

        [JsonProperty("FuelCapacity")]
        public FuelCapacityInfo FuelCapacity { get; private set; }

        [JsonProperty("Rebuy")]
        public long Rebuy { get; private set; }

        [JsonProperty("Modules")]
        public IReadOnlyList<ModuleInfo> Modules { get; private set; }
        
        public class FuelCapacityInfo
        {
            internal FuelCapacityInfo() { }

            [JsonProperty("Main")]
            public double Main { get; private set; }

            [JsonProperty("Reserve")]
            public double Reserve { get; private set; }
        }

        public class ModuleInfo
        {
            internal ModuleInfo() { }

            [JsonProperty("Slot")]
            public string Slot { get; private set; }

            [JsonProperty("Item")]
            public string Item { get; private set; }

            [JsonProperty("On")]
            public bool On { get; private set; }

            [JsonProperty("Priority")]
            public long Priority { get; private set; }

            [JsonProperty("Health")]
            public double Health { get; private set; }

            [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoInClip { get; private set; }

            [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoInHopper { get; private set; }

            [JsonProperty("EngineeringInfo", NullValueHandling = NullValueHandling.Ignore)]
            public EngineeringInfo Engineering { get; private set; }
        }

        public class EngineeringInfo
        {
            internal EngineeringInfo() { }

            [JsonProperty("Engineer")]
            public string Engineer { get; private set; }

            [JsonProperty("EngineerID")]
            public long EngineerId { get; private set; }

            [JsonProperty("BlueprintID")]
            public long BlueprintId { get; private set; }

            [JsonProperty("BlueprintName")]
            public string BlueprintName { get; private set; }

            [JsonProperty("Level")]
            public long Level { get; private set; }

            [JsonProperty("Quality")]
            public double Quality { get; private set; }

            [JsonProperty("ModifierInfos")]
            public IReadOnlyList<ModifierInfo> ModifierInfos { get; private set; }
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

    public partial class LoadoutEvent
    {
        public static LoadoutEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LoadoutEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<LoadoutEvent> LoadoutEvent;

        internal void InvokeLoadoutEvent(LoadoutEvent arg)
        {
            LoadoutEvent?.Invoke(this, arg);
        }
    }
}