using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.EDSM.Commander.Responses;

public class CreditsResponse : IWebApiResponse
{
    internal CreditsResponse()
    {
    }

    [JsonProperty("msgnum")]
    public long Status { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; }
}