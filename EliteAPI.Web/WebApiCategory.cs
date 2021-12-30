using System.Reflection;
using System.Web;
using EliteAPI.Web.Abstractions;
using EliteAPI.Web.Attributes;
using EliteAPI.Web.Exceptions;
using EliteAPI.Web.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Web;

public abstract class WebApiCategory : IWebApiCategory
{
    private readonly ILogger<WebApiCategory> _log;

    protected WebApiCategory(WebApi api)
    {
        Api = api;
        Http = api.Services.GetRequiredService<IHttpClientFactory>().CreateClient(); //todo: config through name here?
        _log = api.Services.GetRequiredService<ILogger<WebApiCategory>>();
    }

    protected WebApi Api { get; }
    protected HttpClient Http { get; }

    public abstract string Endpoint { get; }

    /// <inheritdoc />
    public async Task<WebApiResponse<TResponse>> Execute<TRequest, TResponse>() where TResponse : IWebApiResponse
        where TRequest : IWebApiRequest
    {
        try
        {
            var request = ActivatorUtilities.CreateInstance<TRequest>(Api.Services);
            return await Execute<TRequest, TResponse>(request);
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "Could not instantiate default value for web request object");
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<WebApiResponse<TResponse>> Execute<TRequest, TResponse>(TRequest? request)
        where TResponse : IWebApiResponse where TRequest : IWebApiRequest
    {
        if (request == null)
            return await Execute<TRequest, TResponse>();

        var requestMessage = BuildRequest(this, request);

        // Execute the request
        var response = await Http.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            var errorObject = JObject.Parse(errorContent);
            var error = errorObject["error"]?.ToString() ?? "Unknown error";

            var ex = new WebApiException(error, response);

            _log.LogWarning(ex, "Response does not indicate success");
        }

        // Deserialize the response
        var body = await response.Content.ReadAsJsonAsync<TResponse>();

        return new WebApiResponse<TResponse>(response, body);
    }

    private HttpRequestMessage BuildRequest(WebApiCategory category, IWebApiRequest request)
    {
        // Trim the url segments
        var baseUri = category.Api.BaseUrl.Trim('/');
        var categoryEndpoint = category.Endpoint.Trim('/');
        var requestEndpoint = request.Endpoint.Trim('/');

        var apiPart = $"{categoryEndpoint}/{requestEndpoint}".Replace("//", "/").Trim('/');

        // Build the request URI
        var uriBuilder = new UriBuilder($"{baseUri}/{apiPart}");

        // Create a query builder
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        // Find all the properties with the QueryParameter attribute
        var queryProperties = request
            .GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetCustomAttributes(typeof(QueryParameterAttribute), true).Any());

        // Add the query parameters
        foreach (var property in queryProperties)
        {
            var key = property.GetCustomAttribute<QueryParameterAttribute>()?.Key;
            var value = GetPropertyValue(property, request);

            query.Add(key, value);
        }

        // Apply the query parameters
        uriBuilder.Query = query.ToString();

        // Extract the URI
        var uri = uriBuilder.Uri;

        //todo: add headers
        //todo: add body

        return new HttpRequestMessage(request.Method, uri);
    }

    public string GetPropertyValue(PropertyInfo property, object instance)
    {
        var value = property.GetValue(instance)?.ToString();

        var attribute = property.GetCustomAttribute<SecretAttribute>();

        if (attribute != null)
        {
            var key = attribute.Key;

            if (Api.HasSecret(key))
                value = Api.GetSecret(key);
            else
                _log.LogWarning("Secret key {Key} not found in secrets", key);
        }

        return value;
    }
}