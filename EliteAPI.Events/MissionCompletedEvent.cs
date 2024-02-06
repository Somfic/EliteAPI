using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MissionCompletedEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Faction")]
    public string Faction { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("MissionID")]
    public string MissionId { get; init; }

    [JsonProperty("TargetType")]
    public Localised TargetType { get; init; }

    [JsonProperty("TargetFaction")]
    public string TargetFaction { get; init; }

    [JsonProperty("NewDestinationSystem")]
    public string NewDestinationSystem { get; init; }

    [JsonProperty("DestinationSystem")]
    public string DestinationSystem { get; init; }

    [JsonProperty("NewDestinationStation")]
    public string NewDestinationStation { get; init; }

    [JsonProperty("DestinationStation")]
    public string DestinationStation { get; init; }

    [JsonProperty("Target")]
    public string Target { get; init; }

    [JsonProperty("Reward")]
    public long Reward { get; init; }

    [JsonProperty("FactionEffects")]
    public IReadOnlyCollection<FactionEffectInfo> FactionEffects { get; init; }


    public readonly struct FactionEffectInfo
    {
        [JsonProperty("Faction")]
        public string Faction { get; init; }

        [JsonProperty("Effects")]
        public IReadOnlyCollection<EffectInfo> Effects { get; init; }

        [JsonProperty("Influence")]
        public IReadOnlyCollection<InfluenceInfo> Influence { get; init; }

        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; init; }

        [JsonProperty("Reputation")]
        public string Reputation { get; init; }
    }


    public readonly struct EffectInfo
    {
        [JsonProperty("Effect")]
        public Localised Effect { get; init; }

        [JsonProperty("Trend")]
        public string Trend { get; init; }
    }


    public readonly struct InfluenceInfo
    {
        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; init; }

        [JsonProperty("Trend")]
        public string Trend { get; init; }

        [JsonProperty("Influence")]
        public string Influence { get; init; }
    }
}