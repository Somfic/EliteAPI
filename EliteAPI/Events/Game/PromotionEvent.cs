using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct PromotionEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("Empire")]
	public long Empire { get; init; }

	[JsonProperty("Explore")]
	public int Explore { get; init; }

	[JsonProperty("Combat")]
	public int Combat { get; init; }

	[JsonProperty("Soldier")]
	public int Soldier { get; init; }

	[JsonProperty("Federation")]
	public int Federation { get; init; }

	[JsonProperty("Exobiologist")]
	public int Exobiologist { get; init; }

	[JsonProperty("Trade")]
	public int Trade { get; init; }
}
