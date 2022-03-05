using EliteAPI.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WebApiServiceCollectionExtensions
{
    /// <summary>Adds EliteAPI services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddWebApi<T>(this IServiceCollection services) where T : WebApi
    {
        services.AddHttpClient(typeof(T).Name);

        services.TryAddSingleton<T>();

        return services;
    }

    // todo: add overload with configuration
}