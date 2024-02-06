using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CargoTransferEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Transfers")]
    public IReadOnlyCollection<Transfer> Transfers { get; init; }
}

public readonly struct Transfer
{
    [JsonProperty("Type")]
    public string Type { get; init; }

    [JsonProperty("Count")]
    public long Count { get; init; }

    [JsonProperty("Direction")]
    public string Direction { get; init; }
}