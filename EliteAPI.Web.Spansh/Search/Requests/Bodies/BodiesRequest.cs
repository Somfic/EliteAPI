using System.Runtime.Serialization;
using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.Search.Requests.Sort;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Search.Requests;

public class BodiesRequest : IWebApiRequest
{
    [JsonProperty("filters")]
    public FilterOptions Filters { get; init; } = new();

    [JsonProperty("sort")]
    public ICollection<SortOption> Sorting { get; init; } = new List<SortOption> { new() }.ToArray();

    [JsonProperty("reference_system")]
    public string ReferenceSystem { get; init; } = "Sol";
    
    [JsonProperty("size")]
    public long Size { get; init; } = 50;

    [JsonProperty("page")]
    public long Page { get; init; } = 0;
    
    public class FilterOptions
    {
        [JsonProperty("atmosphere", NullValueHandling = NullValueHandling.Ignore)]
        public AtmosphereFilter? Atmosphere { get; init; }

        [JsonProperty("distance", NullValueHandling = NullValueHandling.Ignore)]
        public MinMaxFilter? Distance { get; init; }
    }
    
    public class SortOption
    {
        [JsonProperty("distance")]
        public DistanceSort Distance { get; init; } = new() { Direction = "asc" };
    }

    public string Endpoint => "bodies/search";
    public HttpMethod Method => HttpMethod.Post;
}