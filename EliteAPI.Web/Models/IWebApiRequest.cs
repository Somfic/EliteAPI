using Newtonsoft.Json;

namespace EliteAPI.Web.Models;

[JsonObject(MemberSerialization.OptIn)]
public interface IWebApiRequest
{
    /// <summary>The endpoint of the request, based on the category.</summary>
    public string Endpoint { get; }

    /// <summary>The HTTP method of the request.</summary>
    public HttpMethod Method { get; }
}