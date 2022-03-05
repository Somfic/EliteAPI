using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDSM.Commander.Requests;

public class RanksRequest : AuthenticatedRequest, IWebApiRequest
{
    public RanksRequest(string commanderName)
    {
        Name = commanderName;
    }

    [QueryParameter("commanderName")]
    public string Name { get; }

    public string Endpoint => "get-ranks";
    public HttpMethod Method => HttpMethod.Get;
}