using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CollectCargoEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Type")]
	public Localised Type { get; init; }
	
	[JsonProperty("Stolen")]
	public bool IsStolen { get; init; }
	
	[JsonProperty("MissionID")]
	public string MissionID { get; init; }
}