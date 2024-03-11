using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CrewFireEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Name")]
	public string Name { get; init; }
	
	[JsonProperty("CrewID")]
	public string CrewID { get; init; }
}