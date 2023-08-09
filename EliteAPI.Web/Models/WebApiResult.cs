using System.Net;
using System.Net.Http.Headers;

namespace EliteAPI.Web.Models;

public readonly struct WebApiResult<T> where T : IWebApiResponse
{
    private readonly HttpResponseMessage _response;
    private readonly Exception _exception;

    public WebApiResult(HttpResponseMessage response, (T parsed, string raw) result)
    {
        _response = response;
        Content = result.parsed;
        RawContent = result.raw;
    }

    public T Content { get; }
    public string RawContent { get; }
    public HttpContentHeaders ContentHeaders { get; }
    public HttpResponseHeaders Headers { get; }
    public bool IsSuccessStatusCode { get; }
    public Version Version { get; }
    public HttpStatusCode StatusCode { get; }
    public string? ReasonPhrase { get; }

    public void EnsureSuccessStatusCode()
    {
        _response.EnsureSuccessStatusCode();
    }
}