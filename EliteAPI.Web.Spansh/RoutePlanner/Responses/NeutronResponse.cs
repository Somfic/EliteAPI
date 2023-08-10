using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.RoutePlanner.Responses;

public class NeutronResponse
{
    [JsonProperty("destination_system")]
    public string DestinationSystem { get; init; }

    [JsonProperty("distance")]
    public double Distance { get; init; }

    [JsonProperty("efficiency")]
    public long Efficiency { get; init; }

    [JsonProperty("job")]
    public string Job { get; init; }

    [JsonProperty("range")]
    public long Range { get; init; }

    [JsonProperty("source_system")]
    public string SourceSystem { get; init; }

    [JsonProperty("system_jumps")]
    public IReadOnlyCollection<SystemJump> SystemJumps { get; init; }

    [JsonProperty("total_jumps")]
    public long TotalJumps { get; init; }

    [JsonProperty("via")]
    public string[] Via { get; init; }

    public class SystemJump
    {
        [JsonProperty("distance_jumped")]
        public double DistanceJumped { get; init; }

        [JsonProperty("distance_left")]
        public double DistanceLeft { get; init; }

        [JsonProperty("id64")]
        public long Id { get; init; }

        [JsonProperty("jumps")]
        public long Jumps { get; init; }

        [JsonProperty("neutron_star")]
        public bool NeutronStar { get; init; }

        [JsonProperty("system")]
        public string System { get; init; }

        [JsonProperty("x")]
        public double X { get; init; }

        [JsonProperty("y")]
        public double Y { get; init; }

        [JsonProperty("z")]
        public double Z { get; init; }
    }
}