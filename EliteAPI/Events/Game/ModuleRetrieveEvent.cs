using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ModuleRetrieveEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("MarketID")]
	public string MarketId { get; init; }

	[JsonProperty("Slot")]
	public string Slot { get; init; }

	[JsonProperty("RetrievedItem")]
	public LocalisedField RetrievedItem { get; init; }

	[JsonProperty("Ship")]
	public string Ship { get; init; }

	[JsonProperty("ShipID")]
	public string ShipId { get; init; }

	[JsonProperty("Hot")]
	public bool IsHot { get; init; }

	[JsonProperty("EngineerModifications")]
	public string EngineerModifications { get; init; }

	[JsonProperty("Level")]
	public int Level { get; init; }

	[JsonProperty("Quality")]
	public double Quality { get; init; }

	[JsonProperty("SwapOutItem")]
	public string SwapOutItem { get; init; }
}
