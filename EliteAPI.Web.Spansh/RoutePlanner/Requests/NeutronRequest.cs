using EliteAPI.Web.Attributes;
using EliteAPI.Web.Models;

namespace EliteAPI.Web.Spansh.RoutePlanner.Requests;

public class NeutronRequest : IWebApiRequest
{
    public NeutronRequest(string from, string to, int range = 10)
    {
        From = from;
        To = to;
        Range = range;
    }

    [QueryParameter("efficiency")]
    public int Efficiency { get; init; } = 60;

    [QueryParameter("range")]
    public int Range { get; init; }

    [QueryParameter("from")]
    public string From { get; init; }
    
    [QueryParameter("via")]
    public string Via { get; init; }

    [QueryParameter("to")]
    public string To { get; init; }

    public string Endpoint => "route";
    public HttpMethod Method => HttpMethod.Post;
}