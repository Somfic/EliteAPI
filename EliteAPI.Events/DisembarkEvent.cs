using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct DisembarkEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("SRV")]
	public bool IsSrv { get; init; }
	
	[JsonProperty("Taxi")]
	public bool IsTaxi { get; init; }
	
	[JsonProperty("Multicrew")]
	public bool IsMulticrew { get; init; }
	
	[JsonProperty("StarSystem")]
	public string StarSystem { get; init; }
	
	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }
	
	[JsonProperty("Body")]
	public string Body { get; init; }
	
	[JsonProperty("BodyID")]
	public string BodyId { get; init; }
	
	[JsonProperty("OnStation")]
	public bool IsOnStation { get; init; }
	
	[JsonProperty("OnPlanet")]
	public bool IsOnPlanet { get; init; }
	
	[JsonProperty("StationName")]
	public string StationName { get; init; }
	
	[JsonProperty("StationType")]
	public string StationType { get; init; }
	
	[JsonProperty("MarketID")]
	public string MarketId { get; init; }
	
	[JsonProperty("ID")]
	public string ID { get; init; }
}