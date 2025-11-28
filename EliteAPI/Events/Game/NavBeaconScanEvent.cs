using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

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
