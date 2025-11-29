using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct FssSignalDiscoveredEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }

	[JsonProperty("SignalName")]
	public string SignalName { get; init; }

	[JsonProperty("SignalType")]
	public string SignalType { get; init; }

	[JsonProperty("IsStation")]
	public bool IsStation { get; init; }

	[JsonProperty("USSType")]
	public string USSType { get; init; }

	[JsonProperty("SpawningState")]
	public string SpawningState { get; init; }

	[JsonProperty("SpawningFaction")]
	public string SpawningFaction { get; init; }

	[JsonProperty("ThreatLevel")]
	public int ThreatLevel { get; init; }

	[JsonProperty("TimeRemaining")]
	public double TimeRemaining { get; init; }
}
