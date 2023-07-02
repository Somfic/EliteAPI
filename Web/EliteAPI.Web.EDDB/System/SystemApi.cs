using EliteAPI.Web.EDDB.System.Requests;
using EliteAPI.Web.EDDB.System.Responses;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDDB.System;

[Obsolete("EDDB has shut down their API. This API will be removed in a future version of EliteAPI.", true)]
public class SystemApi : WebApiCategory
{
    public SystemApi(WebApi api) : base(api)
    {
    }
    
    public async Task<WebApiResponse<IReadOnlyList<SystemResponse>>> Query(string system)
    {
        return await Execute<SystemRequest, IReadOnlyList<SystemResponse>>(new SystemRequest(system));
    }

    public override string Endpoint => "system";
}