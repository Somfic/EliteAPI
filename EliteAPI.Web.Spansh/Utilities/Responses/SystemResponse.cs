using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.Utilities.Responses;

public class SystemResponse : IWebApiResponse
{
    [JsonProperty("root")] // Json root attribute
    public string[] Systems { get; init; }
}