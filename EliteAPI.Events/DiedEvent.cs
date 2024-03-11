using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct DiedEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("KillerName")]
	public string KillerName { get; init; }
	
	[JsonProperty("KillerShip")]
	public string KillerShip { get; init; }
	
	[JsonProperty("KillerRank")]
	public string KillerRank { get; init; }
}