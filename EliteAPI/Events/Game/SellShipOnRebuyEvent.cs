using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct SellShipOnRebuyEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("ShipType")]
	public string ShipType { get; init; }

	[JsonProperty("System")]
	public string System { get; init; }

	[JsonProperty("SellShipId")]
	public string SellShipId { get; init; }

	[JsonProperty("SellShipPrice")]
	public long SellShipPrice { get; init; }

	[JsonProperty("ShipPrice")]
	public int ShipPrice { get; init; }
}
