using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CarrierJumpEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Docked")]
    public bool IsDocked { get; init; }

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


    public readonly struct StationEconomyInfo
    {
        [JsonProperty("Name")]
        public Localised Name { get; init; }

        [JsonProperty("Proportion")]
        public double Proportion { get; init; }
    }


    public readonly struct StationFactionInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }
    }
}