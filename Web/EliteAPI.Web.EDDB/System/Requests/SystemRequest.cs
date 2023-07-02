using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDDB.System.Requests;

[Obsolete("EDDB has shut down their API. This API will be removed in a future version of EliteAPI.", true)]
public class SystemRequest : IWebApiRequest
{
    public string Endpoint => "search";
    public HttpMethod Method => HttpMethod.Get;

    public SystemRequest(string system)
    {
        Query = system;
    }
    
    [QueryParameter("system[name]")]
    public string Query { get; }
}