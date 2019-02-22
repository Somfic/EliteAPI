using System;
using System.IO;
using System.Text;
using System.Threading;

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

        public void LogDebug(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Debug));
        }

        public void LogDebug(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Debug, ex));
        }

        public Logger UseConsole()
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

                    case Severity.Debug:
                        Write(arg.Severity, ConsoleColor.DarkGray, arg.Message, arg.Exception);
                        break;
                }
            };

            return this;
        }

        public Logger UseLogFile()
        {
            WriteToLog("======= NEW LOG ENTRY =======");

            Log += (sender, arg) =>
            {
                switch (arg.Severity)
                {
                    case Severity.Info:
                        WriteLog(arg.Severity, arg.Message, arg.Exception);
                        break;

                    case Severity.Success:
                        WriteLog(arg.Severity, arg.Message, arg.Exception);
                        break;

                    case Severity.Warning:
                        WriteLog(arg.Severity, arg.Message, arg.Exception);
                        break;

                    case Severity.Error:
                        WriteLog(arg.Severity, arg.Message, arg.Exception);
                        break;

                    case Severity.Debug:
                        WriteLog(arg.Severity, arg.Message, arg.Exception);
                        break;
                }
            };

            return this;
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
                Console.Write(">");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = color;
                Console.WriteLine($" {ex.Message} ");
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        private void WriteLog(Severity severity, string content, Exception ex  = null)
        {
            StringBuilder s = new StringBuilder("        ");
            s.Insert(0, severity.ToString());
            s.Insert(8, ": " + content);

            WriteToLog(s);

            if(ex != null)
            {
                s = new StringBuilder("        ");
                s.Insert(8, "> " + ex.Message);
                WriteToLog(s);

                s = new StringBuilder("        ");
                s.Insert(8, "> " + ex.StackTrace);
                WriteToLog(s);
            }
        }

        private void WriteToLog(object s)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    File.AppendAllText($"EliteAPI.{DateTime.Now.ToShortDateString()}.log", DateTime.Now.ToLongTimeString() + " : " + s.ToString() + Environment.NewLine);
                    return;
                }
                catch { Thread.Sleep(100); }
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

    public enum Severity { Info, Warning, Error, Success,
        Debug
    }
}
