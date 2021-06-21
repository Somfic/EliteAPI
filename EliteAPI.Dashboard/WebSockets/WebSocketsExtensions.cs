using EliteAPI.Dashboard.WebSockets.Handler;
using EliteAPI.Dashboard.WebSockets.Handshake;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI.Dashboard.WebSockets
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