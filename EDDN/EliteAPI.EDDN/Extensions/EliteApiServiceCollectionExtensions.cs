using System;
using EliteAPI.EDDN;
using EliteAPI.EDDN.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class EliteDangerousApiEddnExtensions
{
    /// <summary>Adds EDDN services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEddnBridge(this IServiceCollection services)
    {
        return services.AddEddnBridge(null);
    }

    /// <summary>Adds EDDN services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="EliteDangerousApiEddnOptions" /> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEddnBridge(this IServiceCollection services,
        Action<EliteDangerousApiEddnOptions>? configure)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services), "Service collection cannot be null.");
    
        // todo: configure eddn   

        services.AddHttpClient();
        services.AddSingleton<EliteDangerousApiEddnBridge>();

        return services;
    }
}