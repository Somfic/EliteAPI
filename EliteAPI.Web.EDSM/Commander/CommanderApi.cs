using EliteAPI.Web.EDSM.Commander.Requests;
using EliteAPI.Web.EDSM.Commander.Responses;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDSM.Commander;

public class CommanderApi : WebApiCategory
{
    public CommanderApi(WebApi api) : base(api)
    {
    }

    public override string Endpoint => "api-commander-v1";

    public async Task<WebApiResponse<RanksResponse>> Ranks(RanksRequest? request = null)
    {
        return await Execute<RanksRequest, RanksResponse>(request);
    }

    public async Task<WebApiResponse<CreditsResponse>> Credits(CreditsRequest? request = null)
    {
        return await Execute<CreditsRequest, CreditsResponse>(request);
    }
}