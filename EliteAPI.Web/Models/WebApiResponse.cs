using System.Net;
using System.Net.Http.Headers;

namespace EliteAPI.Web.Models;

public class WebApiResponse<T> where T : IWebApiResponse
{
    private readonly HttpResponseMessage _response;

    public WebApiResponse(HttpResponseMessage response, (T parsed, string raw) result)
    {
        _response = response;
        Headers = response.Headers;
        ContentHeaders = response.Content.Headers;
        ReasonPhrase = response.ReasonPhrase;
        Version = response.Version;
        StatusCode = response.StatusCode;
        TrailingHeaders = response.TrailingHeaders;
        IsSuccessStatusCode = response.IsSuccessStatusCode;
        Content = result.parsed;
        RawContent = result.raw;
    }

    public T Content { get; }
    public string RawContent { get; }
    public HttpContentHeaders ContentHeaders { get; }
    public HttpResponseHeaders Headers { get; }
    public bool IsSuccessStatusCode { get; }
    public Version Version { get; }
    public HttpResponseHeaders TrailingHeaders { get; }
    public HttpStatusCode StatusCode { get; }
    public string? ReasonPhrase { get; }

    public void EnsureSuccessStatusCode()
    {
        _response.EnsureSuccessStatusCode();
    }
}