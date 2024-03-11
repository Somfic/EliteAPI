using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MissionAbandonedEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Name")]
	public string Name { get; init; }
	
	[JsonProperty("MissionID")]
	public string MissionId { get; init; }
	
	[JsonProperty("LocalisedName")]
	public string LocalisedName { get; init; }
}