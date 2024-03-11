using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ShipyardSellEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("ShipType")]
	public string ShipType { get; init; }
	
	[JsonProperty("SellShipID")]
	public string SellShipId { get; init; }
	
	[JsonProperty("ShipPrice")]
	public long ShipPrice { get; init; }
	
	[JsonProperty("System")]
	public string System { get; init; }
	
	[JsonProperty("MarketID")]
	public string MarketID { get; init; }
	
	[JsonProperty("ShipMarketID")]
	public string ShipMarketID { get; init; }
}