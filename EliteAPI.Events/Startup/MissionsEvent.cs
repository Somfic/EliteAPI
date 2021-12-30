using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;

namespace EliteAPI.Events;

public readonly struct MissionsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Active")]
    public IReadOnlyCollection<MissionInfo> Active { get; init; }

    [JsonProperty("Failed")]
    public IReadOnlyCollection<MissionInfo> Failed { get; init; }

    [JsonProperty("Complete")]
    public IReadOnlyCollection<MissionInfo> Complete { get; init; }


    public readonly struct MissionInfo
    {
        [JsonProperty("MissionID")]
        public string MissionId { get; init; }

        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("PassengerMission")]
        public bool IsPassengerMission { get; init; }

        [JsonProperty("Expires")]
        public long Expires { get; init; }
    }
}