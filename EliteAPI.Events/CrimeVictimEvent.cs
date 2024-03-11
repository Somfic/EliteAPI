using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CrimeVictimEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("Offender")]
	public string Offender { get; init; }
	
	[JsonProperty("CrimeType")]
	public string CrimeType { get; init; }
	
	[JsonProperty("Bounty")]
	public long Bounty { get; init; }
	
	[JsonProperty("Fine")]
	public int Fine { get; init; }
}