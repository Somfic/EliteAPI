using EliteAPI.Web.Models;

namespace EliteAPI.Web.Spansh.Utilities.Requests;

public class JobRequest : IJobRequest
{
    public JobRequest(string job)
    {
        Job = job;
    }

    public string Job { get; init; }
    public string Endpoint => $"results/{Job}";
    public HttpMethod Method => HttpMethod.Get;
}