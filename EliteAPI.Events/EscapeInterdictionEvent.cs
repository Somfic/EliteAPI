using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct EscapeInterdictionEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Interdictor")]
	public string Interdictor { get; init; }
	
	[JsonProperty("IsPlayer")]
	public bool IsPlayer { get; init; }
	
	[JsonProperty("IsThargoid")]
	public bool IsThargoid { get; init; }
}