using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.EDSM.Status.Responses;

public class StatusResponse : IWebApiResponse
{
    [JsonProperty("lastUpdate")]
    public DateTime LastUpdate { get; init; }

    [JsonProperty("type")]
    public string Type { get; init; }

    [JsonProperty("message")]
    public string Message { get; init; }

    [JsonProperty("status")]
    public long Status { get; init; }
}