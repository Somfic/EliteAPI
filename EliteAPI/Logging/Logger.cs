using System;

namespace EliteAPI.Logging
{
    public class Logger
    {
        public void LogInfo(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Info));
        }

        public void LogSuccess(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Success));
        }

        public void LogWarning(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Warning));
        }

        public void LogWarning(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Warning, ex));
        }

        public void LogError(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Error));
        }

        public void LogError(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Error, ex));
        }

        public void UseConsole()
        {
            Log += (sender, arg) =>
            {
                switch (arg.Severity)
                {
                    case Severity.Info:
                        Write(arg.Severity, ConsoleColor.Gray, arg.Message, arg.Exception);
                        break;

                    case Severity.Success:
                        Write(arg.Severity, ConsoleColor.Green, arg.Message, arg.Exception);
                        break;

                    case Severity.Warning:
                        Write(arg.Severity, ConsoleColor.DarkYellow, arg.Message, arg.Exception);
                        break;

                    case Severity.Error:
                        Write(arg.Severity, ConsoleColor.Red, arg.Message, arg.Exception);
                        break;
                }
            };
        }

        private void Write(Severity severity, ConsoleColor color, string content, Exception ex = null)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = color;
            Console.Write(severity);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(8, Console.CursorTop);
            Console.Write(": ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(content);
            
            if(ex != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(8, Console.CursorTop);
                Console.Write("+");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = color;
                Console.WriteLine($" {ex.Message} ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

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

        public LogMessage(string message, Severity severity, Exception exception)
        {
            Message = message;
            Severity = severity;
            Exception = exception;
        }

        public string Message { get; private set; }
        public Severity Severity { get; private set; }
        public Exception Exception { get; private set; }
    }

    public enum Severity { Info, Warning, Error, Success  }
}
