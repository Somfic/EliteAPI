using EliteAPI.Server;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class EliteServerServiceCollectionExtensions
{
    /// <summary>Adds EliteAPI Server services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEliteApiServer(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services), "Service collection cannot be null.");

        services.TryAddSingleton<EliteDangerousApiServer>();

        return services;
    }
}