using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.RoutePlanner.Responses;
using EliteAPI.Web.Spansh.Utilities.Requests;
using EliteAPI.Web.Spansh.Utilities.Responses;
using Microsoft.Extensions.Logging;
using Somfic.Common;

namespace EliteAPI.Web.Spansh.Utilities;

public class UtilitiesApi : WebApiCategory
{
    private readonly ILogger<UtilitiesApi> _log;

    public UtilitiesApi(ILogger<UtilitiesApi> log, WebApi api) : base(api)
    {
        _log = log;
    }

    protected override string Endpoint => "";

    public async Task<WebApiResponse<WebApiResult<SystemResponse>>> System(SystemRequest request)
    {
        return await Execute<SystemRequest, SystemResponse>(request);
    }

    internal async Task<WebApiResponse<WebApiResult<JobResponse<T>>>> Job<T>(JobRequest request)
    {
        while (true)
        {
            var result = await Execute<JobRequest, JobResponse<T>>(request);

            if (result.IsError)
                return result;

            var response = result.Expect();

            if (response.Content.Status == "queued")
            {
                await Task.Delay(1000);
                continue;
            }

            return result;
        }
    }
    
    internal async Task<Result<TResponse>> FromJob<TResponse>(WebApiResponse<WebApiResult<JobResponse>> job) where TResponse : class, IJobResponse
    {
        var api = Api as SpanshApi;
        
        var result = await job.MapAsync(
            ok: x => api.Utilities.Job<NeutronResponse>(new JobRequest(x.Content.Job)),
            error: x => x
        );

        return result.Map<Result<TResponse>>(
            ok: x => x.Content.Result as TResponse,
            error: x => x);
    }
}