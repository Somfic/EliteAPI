using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.RoutePlanner.Requests;
using EliteAPI.Web.Spansh.RoutePlanner.Responses;
using EliteAPI.Web.Spansh.Utilities.Requests;
using EliteAPI.Web.Spansh.Utilities.Responses;
using Microsoft.Extensions.Logging;
using Somfic.Common;

namespace EliteAPI.Web.Spansh.RoutePlanner;

public class RoutePlannerApi : WebApiCategory
{
    private readonly ILogger<RoutePlannerApi> _log;

    public RoutePlannerApi(WebApi api, ILogger<RoutePlannerApi> log) : base(api)
    {
        _log = log;
    }

    protected override string Endpoint => "";

    public async Task<Result<NeutronResponse>> Neutron(NeutronRequest request)
    {
        var api = Api as SpanshApi;
        
        var job = await Execute<NeutronRequest, JobResponse>(request);
        
        return await api.Utilities.FromJob<NeutronResponse>(job);
    }
    
}