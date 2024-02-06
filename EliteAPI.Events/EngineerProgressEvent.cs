using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct EngineerProgressEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Engineers")]
    public IReadOnlyCollection<EngineerInfo> Engineers { get; init; }
    
    public readonly struct EngineerInfo
    {
        [JsonProperty("Engineer")]
        public string EngineerEngineer { get; init; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; init; }

        [JsonProperty("Progress")]
        public string Progress { get; init; }

        [JsonProperty("RankProgress")]
        public long RankProgress { get; init; }

        [JsonProperty("Rank")]
        public long Rank { get; init; }
    }
}