using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Logging
{
    public class Logger
    {
        public void LogInfo(string s)
        {
            Log?.Invoke(this, new LogMessage(s, Severity.Info));
        }

        public void LogWarning(string s)
        {
            Log?.Invoke(this, new LogMessage(s, Severity.Warning));
        }

        public void LogError(string s)
        {
            Log?.Invoke(this, new LogMessage(s, Severity.Error));
        }

        public event EventHandler<LogMessage> Log;
    }

    public class LogMessage
    {
        public LogMessage(string message, Severity severity)
        {
            Message = message;
            Severity = severity;
        }

        public string Message { get; private set; }
        public Severity Severity { get; private set; }
    }

    public enum Severity { Info, Warning, Error }
}
