using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CrewHireEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Name")]
	public string Name { get; init; }
	
	[JsonProperty("Faction")]
	public string Faction { get; init; }
	
	[JsonProperty("Cost")]
	public long Cost { get; init; }
	
	[JsonProperty("CombatRank")]
	public long CombatRank { get; init; }
	
	[JsonProperty("CrewID")]
	public string CrewID { get; init; }
}