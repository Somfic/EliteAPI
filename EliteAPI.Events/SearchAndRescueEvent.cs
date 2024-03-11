using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct SearchAndRescueEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Name")]
	public string Name { get; init; }
	
	[JsonProperty("Count")]
	public long Count { get; init; }
	
	[JsonProperty("Reward")]
	public long Reward { get; init; }
	
	[JsonProperty("MarketID")]
	public string MarketID { get; init; }
}