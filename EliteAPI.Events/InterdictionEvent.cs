using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct InterdictionEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Success")]
	public bool IsSuccess { get; init; }
	
	[JsonProperty("IsPlayer")]
	public bool IsPlayer { get; init; }
	
	[JsonProperty("Faction")]
	public string Faction { get; init; }
	
	[JsonProperty("Submitted")]
	public bool HasSubmitted { get; init; }
	
	[JsonProperty("Interdicted")]
	public string Interdicted { get; init; }
	
	[JsonProperty("CombatRank")]
	public int CombatRank { get; init; }
	
	[JsonProperty("Power")]
	public string Power { get; init; }
}