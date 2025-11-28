using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CollectCargoEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("Type")]
	public LocalisedField Type { get; init; }

	[JsonProperty("Stolen")]
	public bool IsStolen { get; init; }

	[JsonProperty("MissionID")]
	public string MissionID { get; init; }
}
