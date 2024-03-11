using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct JoinACrewEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Captain")]
	public string Captain { get; init; }
	
	[JsonProperty("Telepresence")]
	public bool IsInTelepresence { get; init; }
}