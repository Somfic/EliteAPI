using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct RepairDroneEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("HullRepaired")]
	public double HullRepaired { get; init; }

	[JsonProperty("CockpitRepaired")]
	public double CockpitRepaired { get; init; }

	[JsonProperty("CorrosionRepaired")]
	public double CorrosionRepaired { get; init; }
}
