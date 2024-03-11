using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MissionRedirectedEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("MissionID")]
	public string MissionId { get; init; }
	
	[JsonProperty("Name")]
	public string Name { get; init; }
	
	[JsonProperty("NewDestinationStation")]
	public string NewDestinationStation { get; init; }
	
	[JsonProperty("NewDestinationSystem")]
	public string NewDestinationSystem { get; init; }
	
	[JsonProperty("OldDestinationStation")]
	public string OldDestinationStation { get; init; }
	
	[JsonProperty("OldDestinationSystem")]
	public string OldDestinationSystem { get; init; }
	
	[JsonProperty("LocalisedName")]
	public string LocalisedName { get; init; }
}