using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Utilities.Responses;

public class JobResponse<T> : IWebApiResponse
{
    [JsonProperty("result")]
    public T Result { get; init; }

    [JsonProperty("status")]
    public string Status { get; init; }
}

public class JobResponse : IWebApiResponse
{
    [JsonProperty("job")]
    public string Job { get; init; }

    [JsonProperty("status")]
    public string Status { get; init; }
}