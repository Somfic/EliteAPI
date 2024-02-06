using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MaterialsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Raw")]
    public IReadOnlyCollection<RawInfo> Raw { get; init; }

    [JsonProperty("Manufactured")]
    public IReadOnlyCollection<EncodedInfo> Manufactured { get; init; }

    [JsonProperty("Encoded")]
    public IReadOnlyCollection<EncodedInfo> Encoded { get; init; }


    public readonly struct EncodedInfo
    {
        [JsonProperty("Name")]
        public Localised Name { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }
    }


    public readonly struct RawInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }
    }
}