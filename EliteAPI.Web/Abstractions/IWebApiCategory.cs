using EliteAPI.Web.Models;

namespace EliteAPI.Web.Abstractions;

public interface IWebApiCategory
{
    /// <summary>Executes a HTTP request.</summary>
    /// <typeparam name="TRequest">The generic <see cref="IWebApiRequest" /> type. The request will be instantiated using the provider <see cref="IServiceProvider" /></typeparam>
    /// <typeparam name="TResponse">The generic <see cref="IWebApiResponse" /> type</typeparam>
    /// <returns>The parsed generic <see cref="WebResponse{T}" /> with the type <see cref="IWebApiResponse" /> response</returns>
    internal Task<WebApiResult<TResponse>> Execute<TRequest, TResponse>()
        where TResponse : IWebApiResponse where TRequest : IWebApiRequest;

    /// <summary>Executes a HTTP request.</summary>
    /// <param name="request">The instance of the <see cref="IWebApiRequest" /> type</param>
    /// <typeparam name="TRequest">The generic <see cref="IWebApiRequest" /> type</typeparam>
    /// <typeparam name="TResponse">The generic <see cref="IWebApiResponse" /> type</typeparam>
    /// <returns>The parsed generic <see cref="WebResponse{T}" /> with the type <see cref="IWebApiResponse" /> response</returns>
    /// <exception cref="NullReferenceException">Throws a <see cref="NullReferenceException" /> if the body could not be parsed into</exception>
    internal Task<WebApiResult<TResponse>> Execute<TRequest, TResponse>(TRequest? request)
        where TResponse : IWebApiResponse where TRequest : IWebApiRequest;
}