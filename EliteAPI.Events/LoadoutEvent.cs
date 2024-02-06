using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct LoadoutEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }

    [JsonProperty("ShipName")]
    public string ShipName { get; init; }

    [JsonProperty("ShipIdent")]
    public string ShipIdent { get; init; }

    [JsonProperty("HullValue")]
    public long HullValue { get; init; }

    [JsonProperty("ModulesValue")]
    public long ModulesValue { get; init; }

    [JsonProperty("HullHealth")]
    public double HullHealth { get; init; }

    [JsonProperty("UnladenMass")]
    public double UnladenMass { get; init; }

    [JsonProperty("CargoCapacity")]
    public long CargoCapacity { get; init; }

    [JsonProperty("MaxJumpRange")]
    public double MaxJumpRange { get; init; }

    [JsonProperty("FuelCapacity")]
    public FuelCapacityInfo FuelCapacity { get; init; }

    [JsonProperty("Rebuy")]
    public long Rebuy { get; init; }

    [JsonProperty("Modules")]
    public IReadOnlyCollection<ModuleInfo> Modules { get; init; }


    public readonly struct FuelCapacityInfo
    {
        [JsonProperty("Main")]
        public double Main { get; init; }

        [JsonProperty("Reserve")]
        public double Reserve { get; init; }
    }


    public readonly struct ModuleInfo
    {
        [JsonProperty("Slot")]
        public string Slot { get; init; }

        [JsonProperty("Item")]
        public string Item { get; init; }

        [JsonProperty("On")]
        public bool IsOn { get; init; }

        [JsonProperty("Priority")]
        public long Priority { get; init; }

        [JsonProperty("Value")]
        public long Value { get; init; }

        [JsonProperty("Health")]
        public double Health { get; init; }

        [JsonProperty("AmmoInClip")]
        public long AmmoInClip { get; init; }

        [JsonProperty("AmmoInHopper")]
        public long AmmoInHopper { get; init; }

        [JsonProperty("Engineering")]
        public EngineeringInfo Engineering { get; init; }
    }


    public readonly struct EngineeringInfo
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; init; }

        [JsonProperty("EngineerID")]
        public string EngineerId { get; init; }

        [JsonProperty("BlueprintID")]
        public string BlueprintId { get; init; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; init; }

        [JsonProperty("ExperimentalEffect")]
        public Localised ExperimentalEffect { get; init; }

        [JsonProperty("Level")]
        public long Level { get; init; }

        [JsonProperty("Quality")]
        public double Quality { get; init; }

        [JsonProperty("Modifiers")]
        public IReadOnlyCollection<ModifierInfo> Modifications { get; init; }
    }


    public readonly struct ModifierInfo
    {
        [JsonProperty("Label")]
        public string Label { get; init; }

        [JsonProperty("Value")]
        public double Value { get; init; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; init; }

        [JsonProperty("LessIsGood")]
        public long LessIsGood { get; init; }
    }
}