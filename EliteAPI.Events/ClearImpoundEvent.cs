using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct ClearImpoundEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("ShipType")]
	public string ShipType { get; init; }
	
	[JsonProperty("ShipID")]
	public string ShipId { get; init; }
	
	[JsonProperty("ShipMarketID")]
	public string ShipMarketId { get; init; }
	
	[JsonProperty("MarkedID")]
	public string MarkedId { get; init; }
	
	[JsonProperty("MarketID")]
	public string MarketID { get; init; }
	
	[JsonProperty("System")]
	public string System { get; init; }
}