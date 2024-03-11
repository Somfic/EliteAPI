using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct StartJumpEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("JumpType")]
	public string JumpType { get; init; }
	
	[JsonProperty("StarSystem")]
	public string StarSystem { get; init; }
	
	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }
	
	[JsonProperty("StarClass")]
	public string StarClass { get; init; }
	
	[JsonProperty("Taxi")]
	public bool IsInTaxi { get; init; }
}