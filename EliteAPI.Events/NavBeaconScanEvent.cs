using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct NavBeaconScanEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("NumBodies")]
	public long NumBodies { get; init; }
	
	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }
}