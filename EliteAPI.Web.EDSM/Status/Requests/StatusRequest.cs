using EliteAPI.Web.Models;

namespace EliteAPI.Web.EDSM.Status.Requests;

public class StatusRequest : IWebApiRequest
{
    public string Endpoint => "/elite-server";
    public HttpMethod Method => HttpMethod.Get;
}