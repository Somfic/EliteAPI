using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DockingTimeoutEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("StationName")]
	public string StationName { get; init; }

	[JsonProperty("MarketID")]
	public string MarketID { get; init; }

	[JsonProperty("StationType")]
	public string StationType { get; init; }
}
