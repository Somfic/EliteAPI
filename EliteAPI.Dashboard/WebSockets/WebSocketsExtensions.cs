using System;
using EliteAPI_app.WebSockets.Handler;
using EliteAPI_app.WebSockets.Handshake;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI_app.WebSockets
{
    public static class WebSocketsExtensions
    {
        public static IApplicationBuilder UseWebSocketHandshake(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketHandshake>();
        }

        public static IServiceCollection AddWebSocketHandshake(this IServiceCollection services)
        {
            return services.AddSingleton<WebSocketHandler>();
        }
    }
}