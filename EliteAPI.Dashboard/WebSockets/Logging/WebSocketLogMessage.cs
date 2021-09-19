using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.WebSockets.Logging
{
    public readonly struct WebSocketLogMessage
    {
        public DateTime Timestamp { get; }

        public string LogLevel { get; }

        public EventId EventId { get; }

        public string Category { get; }

        public Exception Exception { get; }

        public string ExceptionType { get; }

        public string Message { get; }

        public WebSocketLogMessage(LogLevel logLevel, EventId eventId, string category, Exception exception,
            string message) : this()
        {
            LogLevel = logLevel.ToString();
            EventId = eventId;
            Category = category;
            Exception = exception;
            ExceptionType = GetPrettyExceptionName(exception);
            Message = message;
            Timestamp = DateTime.Now;
        }

        private string GetPrettyExceptionName(Exception ex)
        {
            if (ex == null)
            {
                return "";
            }

            string output = Regex.Replace(ex.GetType().Name, @"\p{Lu}", m => " " + m.Value.ToLowerInvariant());

            output = ex.GetType().Name == "Exception" ? "Exception" : output.Replace("exception", "");

            output = output.Trim();
            output = char.ToUpperInvariant(output[0]) + output.Substring(1);
            switch (output)
            {
                case "I o":
                    output = "IO";
                    break;
                case "My sql":
                    output = "MySQL";
                    break;
                case "Sql":
                    output = "SQL";
                    break;
            }

            return output;
        }
    }
}