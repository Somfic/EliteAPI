using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct EndCrewSessionEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("OnCrime")]
	public bool IsCrime { get; init; }
	
	[JsonProperty("Telepresence")]
	public bool IsInTelepresence { get; init; }
}