using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct CommunityGoalJoinEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("System")]
    public string System { get; init; }

    [JsonProperty("CGID")]
    public string Id { get; init; }
}