using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct EjectCargoEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("Type")]
	public LocalisedField Type { get; init; }

	[JsonProperty("Count")]
	public long Count { get; init; }

	[JsonProperty("Abandoned")]
	public bool IsAbandoned { get; init; }

	[JsonProperty("MissionID")]
	public string MissionID { get; init; }

	[JsonProperty("PowerplayOrigin")]
	public string PowerplayOrigin { get; init; }
}
