using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct DockedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("StationName")]
    public string StationName { get; init; }

    [JsonProperty("StationType")]
    public string StationType { get; init; }

    [JsonProperty("StarSystem")]
    public string StarSystem { get; init; }

    [JsonProperty("SystemAddress")]
    public string SystemAddress { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("StationFaction")]
    public StationFactionInfo StationFaction { get; init; }

    [JsonProperty("StationGovernment")]
    public LocalisedField StationGovernment { get; init; }

    [JsonProperty("StationAllegiance")]
    public string StationAllegiance { get; init; }

    [JsonProperty("StationServices")]
    public IReadOnlyCollection<string> StationServices { get; init; }

    [JsonProperty("StationEconomy")]
    public LocalisedField StationEconomy { get; init; }

    [JsonProperty("StationEconomies")]
    public IReadOnlyCollection<StationEconomyInfo> StationEconomies { get; init; }

    [JsonProperty("DistFromStarLS")]
    public double DistanceFromStarInLightSeconds { get; init; }

    [JsonProperty("ActiveFine")]
    public bool HasActiveFine { get; init; }

    [JsonProperty("Taxi")]
    public bool IsTaxi { get; init; }

    [JsonProperty("Multicrew")]
    public bool IsMulticrew { get; init; }

    [JsonProperty("LandingPads")]
    public LandingPadsInfo LandingPads { get; init; }


    public readonly struct LandingPadsInfo
    {
        [JsonProperty("Small")]
        public long Small { get; init; }

        [JsonProperty("Medium")]
        public long Medium { get; init; }

        [JsonProperty("Large")]
        public long Large { get; init; }
    }


    public readonly struct StationEconomyInfo
    {
        [JsonProperty("Name")]
        public LocalisedField Name { get; init; }

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

    [JsonProperty("Wanted")]
    public bool IsWanted { get; init; }

    [JsonProperty("CockpitBreach")]
    public bool HasBreachedCockpit { get; init; }

    [JsonProperty("StationState")]
    public string StationState { get; init; }
}
