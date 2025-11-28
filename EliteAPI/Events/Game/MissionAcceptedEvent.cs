using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MissionAcceptedEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("Faction")]
	public string Faction { get; init; }

	[JsonProperty("Name")]
	public string Name { get; init; }

	[JsonProperty("LocalisedName")]
	public string LocalisedName { get; init; }

	[JsonProperty("TargetType")]
	public LocalisedField TargetType { get; init; }

	[JsonProperty("TargetFaction")]
	public string TargetFaction { get; init; }

	[JsonProperty("DestinationSystem")]
	public string DestinationSystem { get; init; }

	[JsonProperty("DestinationStation")]
	public string DestinationStation { get; init; }

	[JsonProperty("Target")]
	public string Target { get; init; }

	[JsonProperty("Expiry")]
	public DateTime Expiry { get; init; }

	[JsonProperty("Wing")]
	public bool IsWing { get; init; }

	[JsonProperty("Influence")]
	public string Influence { get; init; }

	[JsonProperty("Reputation")]
	public string Reputation { get; init; }

	[JsonProperty("Reward")]
	public long Reward { get; init; }

	[JsonProperty("MissionID")]
	public string MissionId { get; init; }

	[JsonProperty("KillCount")]
	public long KillCount { get; init; }

	[JsonProperty("Commodity")]
	public string Commodity { get; init; }

	[JsonProperty("Count")]
	public int Count { get; init; }

	[JsonProperty("NewDestinationSystem")]
	public string NewDestinationSystem { get; init; }

	[JsonProperty("NewDestinationStation")]
	public string NewDestinationStation { get; init; }

	[JsonProperty("Donation")]
	public string Donation { get; init; }

	[JsonProperty("DestinationSettlement")]
	public string DestinationSettlement { get; init; }

	[JsonProperty("PassengerCount")]
	public int PassengerCount { get; init; }

	[JsonProperty("PassengerVIPs")]
	public bool HasPassengerVIPs { get; init; }

	[JsonProperty("PassengerWanted")]
	public bool HasPassengerWanted { get; init; }

	[JsonProperty("PassengerType")]
	public string PassengerType { get; init; }
}
