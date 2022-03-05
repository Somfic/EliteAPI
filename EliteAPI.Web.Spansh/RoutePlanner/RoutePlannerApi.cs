using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.RoutePlanner.Requests;
using EliteAPI.Web.Spansh.RoutePlanner.Responses;
using EliteAPI.Web.Spansh.Utilities.Requests;
using EliteAPI.Web.Spansh.Utilities.Responses;

namespace EliteAPI.Web.Spansh.RoutePlanner;

public class RoutePlannerApi : WebApiCategory
{
    public RoutePlannerApi(WebApi api) : base(api)
    {
    }

    public override string Endpoint => "";

    public async Task<WebApiResponse<JobResponse<NeutronResponse>>> Neutron(NeutronRequest request)
    {
        var api = Api as SpanshApi;

        var jobResult = await Execute<NeutronRequest, JobResponse>(request);
        return await api.Utilities.Job<NeutronResponse>(new JobRequest(jobResult.Content.Job));
    }
}