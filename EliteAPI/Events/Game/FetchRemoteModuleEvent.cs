using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FetchRemoteModuleEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StorageSlot")]
    public string StorageSlot { get; init; }

    [JsonProperty("StoredItem")]
    public LocalisedField StoredItem { get; init; }

    [JsonProperty("ServerId")]
    public string ServerId { get; init; }

    [JsonProperty("TransferCost")]
    public long TransferCost { get; init; }

    [JsonProperty("TransferTime")]
    public long TransferTime { get; init; }

    [JsonProperty("Ship")]
    public string Ship { get; init; }

    [JsonProperty("ShipID")]
    public string ShipId { get; init; }
}
