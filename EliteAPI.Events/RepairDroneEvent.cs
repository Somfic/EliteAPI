using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

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