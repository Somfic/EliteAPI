using System;
using EliteAPI.Discord;
using EliteAPI.Discord.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class EliteDangerousApiDiscordExtensions
{
    /// <summary>Adds Discord Rich Presence services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDiscordRichPresence(this IServiceCollection services)
    {
        return services.AddDiscordRichPresence(null);
    }

    /// <summary>Adds Discord Rich Presence services to the specified <see cref="IServiceCollection" />.</summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">The <see cref="EliteDangerousApiDiscordOptions" /> configuration delegate.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDiscordRichPresence(this IServiceCollection services,
        Action<EliteDangerousApiDiscordOptions>? configure)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services), "Service collection cannot be null.");
    
        // todo: configure rich presence   

        services.AddSingleton<EliteDangerousApiDiscordRichPresence>();

        return services;
    }
}