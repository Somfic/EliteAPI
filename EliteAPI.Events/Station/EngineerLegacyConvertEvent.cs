using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct EngineerLegacyConvertEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Slot")]
    public string Slot { get; init; }

    [JsonProperty("Module")]
    public string Module { get; init; }

    [JsonProperty("Engineer")]
    public string Engineer { get; init; }

    [JsonProperty("EngineerID")]
    public string EngineerId { get; init; }

    [JsonProperty("BlueprintID")]
    public string BlueprintId { get; init; }

    [JsonProperty("BlueprintName")]
    public string BlueprintName { get; init; }

    [JsonProperty("Level")]
    public long Level { get; init; }

    [JsonProperty("Quality")]
    public double Quality { get; init; }

    [JsonProperty("Modifiers")]
    public IReadOnlyCollection<ModifierInfo> Modifiers { get; init; }

    [JsonProperty("IsPreview")]
    public bool IsPreview { get; init; }
    
    public readonly struct ModifierInfo
    {
        [JsonProperty("Label")]
        public string Label { get; init; }

        [JsonProperty("Value")]
        public double Value { get; init; }

        [JsonProperty("ValueStr")]
        public string ValueString { get; init; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; init; }

        [JsonProperty("LessIsGood")]
        public long LessIsGood { get; init; }
    }
}