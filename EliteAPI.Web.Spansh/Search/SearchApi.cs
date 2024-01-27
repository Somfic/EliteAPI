using EliteAPI.Web.Spansh.RoutePlanner.Requests;
using EliteAPI.Web.Spansh.RoutePlanner.Responses;
using EliteAPI.Web.Spansh.Search.Requests;
using EliteAPI.Web.Spansh.Search.Responses.Bodies;
using EliteAPI.Web.Spansh.Utilities.Responses;
using Microsoft.Extensions.Logging;
using Somfic.Common;

namespace EliteAPI.Web.Spansh.Search;

public class SearchApi : WebApiCategory
{
    private readonly ILogger<SearchApi> _log;

    public SearchApi(WebApi api, ILogger<SearchApi> log) : base(api)
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

    public async Task<Result<BodiesResponse>> Bodies(BodiesRequest request)
    {
        var api = Api as SpanshApi;
        var response = await Execute<BodiesRequest, BodiesResponse>(request);
        
        return response.Map<Result<BodiesResponse>>(
            ok: x => x.Content,
            error: x => x);
    }
    
}