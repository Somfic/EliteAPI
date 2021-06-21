using Microsoft.Extensions.Logging;

namespace EliteAPI_app.WebSockets.Logging
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