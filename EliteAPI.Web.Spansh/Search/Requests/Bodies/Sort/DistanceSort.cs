using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Search.Requests.Sort;

public class DistanceSort
{
    [JsonProperty("direction")]
    public string Direction { get; init; }
}