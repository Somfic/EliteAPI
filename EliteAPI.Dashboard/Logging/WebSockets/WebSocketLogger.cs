using System;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.Logging.WebSockets
{
    public class WebSocketLogger : ILogger
    {
        private readonly string _categoryName;

        public WebSocketLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) => true;

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            WebSocketLogs.Invoke(this, logLevel, eventId, _categoryName, exception, formatter(state, exception));
        }
    }
}