using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct LocationEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Longitude")]
    public double Longitude { get; init; }

    [JsonProperty("Latitude")]
    public double Latitude { get; init; }

    [JsonProperty("DistFromStarLS")]
    public double DistanceFromStarInLightSeconds { get; init; }

    [JsonProperty("Docked")]
    public bool IsDocked { get; init; }

    [JsonProperty("Taxi")]
    public bool IsInTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsInMultiCrew { get; init; }

    [JsonProperty("InSRV")]
    public bool IsInSrv { get; init; }

    [JsonProperty("OnFoot")]
    public bool IsOnFoot { get; init; }

    [JsonProperty("StationName")]
    public string StationName { get; init; }

    [JsonProperty("StationType")]
    public string StationType { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("StationFaction")]
    public StationFactionInfo StationFaction { get; init; }

    [JsonProperty("StationGovernment")]
    public Localised StationGovernment { get; init; }

    [JsonProperty("StationAllegiance")]
    public string StationAllegiance { get; init; }

    [JsonProperty("StationServices")]
    public IReadOnlyCollection<string> StationServices { get; init; }

    [JsonProperty("StationEconomy")]
    public Localised StationEconomy { get; init; }

    [JsonProperty("StationEconomies")]
    public IReadOnlyCollection<StationEconomyInfo> StationEconomies { get; init; }

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

    [JsonProperty("Powers")]
    public IReadOnlyCollection<string> Powers { get; init; }

    [JsonProperty("PowerplayState")]
    public string PowerplayState { get; init; }

    [JsonProperty("Factions")]
    public IReadOnlyCollection<FactionInfo> Factions { get; init; }

    [JsonProperty("SystemFaction")]
    public StationFactionInfo SystemFaction { get; init; }

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

        [JsonProperty("ActiveStates")]
        public IReadOnlyCollection<FactionStateInfo> ActiveStates { get; init; }

        [JsonProperty("RecoveringStates")]
        public IReadOnlyCollection<FactionStateInfo> RecoveringStates { get; init; }
    }


    public readonly struct FactionStateInfo
    {
        [JsonProperty("State")]
        public string State { get; init; }

        [JsonProperty("Trend")]
        public long Trend { get; init; }
    }


    public readonly struct StationEconomyInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; init; }

        [JsonProperty("Proportion")]
        public double Proportion { get; init; }
    }


    public readonly struct StationFactionInfo
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
}