using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.Spansh.Utilities.Requests;

public class SystemRequest : IWebApiRequest
{
    public SystemRequest(string query)
    {
        Query = query;
    }

    [QueryParameter("q")]
    public string Query { get; init; }

    public string Endpoint => "systems";
    public HttpMethod Method => HttpMethod.Post;
}