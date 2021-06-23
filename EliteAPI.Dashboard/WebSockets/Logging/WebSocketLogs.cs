using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.WebSockets.Logging
{
    public static class WebSocketLogs
    {
        private static readonly IList<WebSocketLogMessage> _logs = new List<WebSocketLogMessage>();

        public static event EventHandler<WebSocketLogMessage> OnLog;

        internal static void Invoke(object sender, LogLevel logLevel, EventId eventId, string categoryName,
            Exception ex, string message)
        {
            WebSocketLogMessage logMessage = new WebSocketLogMessage(logLevel, eventId, categoryName, ex, message);

            // Only send EliteAPI related log messages
            if (!logMessage.Category.StartsWith("EliteAPI."))
                return;

            if (logMessage.Category.StartsWith("EliteAPI.Dashboard"))
                return;

            if (logLevel == LogLevel.Trace)
                return;

            _logs.Add(logMessage);
            OnLog?.Invoke(sender, logMessage);
        }
    }
}