using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.WebSockets.Logging
{
    public class WebSocketLoggerProvider : ILoggerProvider
    {
        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return new WebSocketLogger(categoryName);
        }
    }
}