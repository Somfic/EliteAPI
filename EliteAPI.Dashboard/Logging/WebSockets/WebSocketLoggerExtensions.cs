using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.Logging.WebSockets
{
    public static class WebSocketLoggerExtensions
    {
        public static ILoggingBuilder AddWebSocketLogger(this ILoggingBuilder builder)
        {
            builder.AddProvider(new WebSocketLoggerProvider());
            return builder;
        }
    }
}