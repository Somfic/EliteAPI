using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierJumpRequestEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("CarrierID")]
	public string CarrierId { get; init; }

	[JsonProperty("SystemName")]
	public string SystemName { get; init; }

	[JsonProperty("Body")]
	public string Body { get; init; }

	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }

	[JsonProperty("BodyID")]
	public string BodyId { get; init; }

	[JsonProperty("DepartureTime")]
	public string DepartureTime { get; init; }
}
