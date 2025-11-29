using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct ShipyardBuyEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("ShipType")]
	public LocalisedField ShipType { get; init; }

	[JsonProperty("ShipPrice")]
	public long ShipPrice { get; init; }

	[JsonProperty("StoreOldShip")]
	public string StoreOldShip { get; init; }

	[JsonProperty("StoreShipID")]
	public string StoreShipId { get; init; }

	[JsonProperty("MarketID")]
	public string MarketId { get; init; }

	[JsonProperty("SellOldShip")]
	public string SellOldShip { get; init; }

	[JsonProperty("SellShipID")]
	public string SellShipID { get; init; }

	[JsonProperty("SellPrice")]
	public int SellPrice { get; init; }
}
