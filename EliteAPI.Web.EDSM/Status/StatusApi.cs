using EliteAPI.Web.EDSM.Status.Requests;
using EliteAPI.Web.EDSM.Status.Responses;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDSM.Status;

public class StatusApi : WebApiCategory
{
    public StatusApi(WebApi api) : base(api)
    {
    }

    public override string Endpoint => "api-status-v1";

    public async Task<WebApiResponse<StatusResponse>> Status()
    {
        return await Execute<StatusRequest, StatusResponse>();
    }
}