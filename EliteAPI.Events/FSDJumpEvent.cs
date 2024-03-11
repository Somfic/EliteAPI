using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct FsdJumpEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }
	
	[JsonProperty("event")]
	public string Event { get; init; }
	
	[JsonProperty("StarSystem")]
	public string StarSystem { get; init; }
	
	[JsonProperty("SystemAddress")]
	public string SystemAddress { get; init; }
	
	[JsonProperty("StarPos")]
	public IReadOnlyCollection<double> StarPos { get; init; }
	
	[JsonProperty("SystemAllegiance")]
	public string SystemAllegiance { get; init; }
	
	[JsonProperty("SystemEconomy")]
	public Localised SystemEconomy { get; init; }
	
	[JsonProperty("SystemSecondEconomy")]
	public Localised SystemSecondEconomy { get; init; }
	
	[JsonProperty("SystemGovernment")]
	public Localised SystemGovernment { get; init; }
	
	[JsonProperty("SystemSecurity")]
	public Localised SystemSecurity { get; init; }
	
	[JsonProperty("Population")]
	public long Population { get; init; }
	
	[JsonProperty("Body")]
	public string Body { get; init; }
	
	[JsonProperty("BodyID")]
	public string BodyId { get; init; }
	
	[JsonProperty("BodyType")]
	public string BodyType { get; init; }
	
	[JsonProperty("JumpDist")]
	public double JumpDist { get; init; }
	
	[JsonProperty("FuelUsed")]
	public double FuelUsed { get; init; }
	
	[JsonProperty("FuelLevel")]
	public double FuelLevel { get; init; }
	
	[JsonProperty("Taxi")]
	public bool IsTaxi { get; init; }
	
	[JsonProperty("Multicrew")]
	public bool IsMulticrew { get; init; }
	
	[JsonProperty("SystemFaction")]
	public SystemFactionInfo SystemFaction { get; init; }
	
	[JsonProperty("Factions")]
	public IReadOnlyCollection<FactionInfo> Factions { get; init; }
	
	[JsonProperty("Conflicts")]
	public IReadOnlyCollection<ConflictInfo> Conflicts { get; init; }
	
	
	public readonly struct FactionInfo
	{
		[JsonProperty("Name")]
		public string Name { get; init; }
		
		[JsonProperty("FactionState")]
		public string FactionState { get; init; }
		
		[JsonProperty("Government")]
		public string Government { get; init; }
		
		[JsonProperty("Influence")]
		public double Influence { get; init; }
		
		[JsonProperty("Allegiance")]
		public string Allegiance { get; init; }
		
		[JsonProperty("Happiness")]
		public Localised Happiness { get; init; }
		
		[JsonProperty("MyReputation")]
		public double MyReputation { get; init; }
		
		[JsonProperty("PendingStates")]
		public IReadOnlyCollection<PendingStateInfo> PendingStates { get; init; }
		
		[JsonProperty("RecoveringStates")]
		public IReadOnlyCollection<RecoveringStateInfo> RecoveringStates { get; init; }
		
		[JsonProperty("ActiveStates")]
		public IReadOnlyCollection<ActiveStateInfo> ActiveStates { get; init; }
	}
	
	
	public readonly struct ActiveStateInfo
	{
		[JsonProperty("State")]
		public string State { get; init; }
	}
	
	
	public readonly struct PendingStateInfo
	{
		[JsonProperty("State")]
		public string State { get; init; }
		
		[JsonProperty("Trend")]
		public double Trend { get; init; }
	}
	
	
	public readonly struct RecoveringStateInfo
	{
		[JsonProperty("State")]
		public string State { get; init; }
		
		[JsonProperty("Trend")]
		public double Trend { get; init; }
	}
	
	
	public readonly struct SystemFactionInfo
	{
		[JsonProperty("Name")]
		public string Name { get; init; }
		
		[JsonProperty("FactionState")]
		public string FactionState { get; init; }
	}
	
	
	public readonly struct ConflictInfo
	{
		[JsonProperty("WarType")]
		public string WarType { get; init; }
		
		[JsonProperty("Status")]
		public string Status { get; init; }
		
		[JsonProperty("Faction1")]
		public ConflictFactionInfo Faction1 { get; init; }
		
		[JsonProperty("Faction2")]
		public ConflictFactionInfo Faction2 { get; init; }
	}
	
	
	public readonly struct ConflictFactionInfo
	{
		[JsonProperty("Name")]
		public string Name { get; init; }
		
		[JsonProperty("Stake")]
		public string Stake { get; init; }
		
		[JsonProperty("WonDays")]
		public long WonDays { get; init; }
	}
	
	[JsonProperty("PowerplayState")]
	public string PowerplayState { get; init; }
	
	[JsonProperty("BoostUsed")]
	public int BoostUsed { get; init; }
}