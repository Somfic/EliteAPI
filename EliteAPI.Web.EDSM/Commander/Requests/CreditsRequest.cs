using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDSM.Commander.Requests;

public class CreditsRequest : AuthenticatedRequest, IWebApiRequest
{
    public CreditsRequest(string commanderName, string? period = null)
    {
        CommanderName = commanderName;
        Period = period;
    }

    [QueryParameter("commanderName")]
    public string CommanderName { get; }

    [QueryParameter("period")]
    public string? Period { get; } //todo: enum

    public string Endpoint => "get-credits";
    public HttpMethod Method => HttpMethod.Get;
}