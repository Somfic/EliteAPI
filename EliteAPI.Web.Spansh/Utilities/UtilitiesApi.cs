using EliteAPI.Web.Models;
using EliteAPI.Web.Spansh.Utilities.Requests;
using EliteAPI.Web.Spansh.Utilities.Responses;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Web.Spansh.Utilities;

public class UtilitiesApi : WebApiCategory
{
    private readonly ILogger<UtilitiesApi> _log;

    public UtilitiesApi(ILogger<UtilitiesApi> log, WebApi api) : base(api)
    {
        _log = log;
    }

    public override string Endpoint => "";

    public async Task<WebApiResponse<SystemResponse>> System(SystemRequest request)
    {
        return await Execute<SystemRequest, SystemResponse>(request);
    }

    public async Task<WebApiResponse<JobResponse<T>>> Job<T>(JobRequest request)
    {
        while (true)
        {
            var result = await Execute<JobRequest, JobResponse<T>>(request);

            if (result.Content.Status == "queued" && result.IsSuccessStatusCode)
            {
                await Task.Delay(1000);
                continue;
            }

            return result;
        }
    }
}