using System;
using System.IO;
using System.Text;
using System.Threading;

namespace EliteAPI.Logging
{
    public class Logger
    {
        private string DirectoryPath = "";

        /// <summary>
        /// Creates a new log entry with a severity of Info.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogInfo(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Info));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Success.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogSuccess(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Success));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Warning.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogWarning(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Warning));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Warning.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        /// <param name="ex">The linked exception that caused the warning.</param>
        public void LogWarning(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Warning, ex));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Error.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogError(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Error));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Error.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        /// <param name="ex">The linked exception that caused the error.</param>
        public void LogError(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Error, ex));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Debug.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogDebug(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Debug));
        }
       
        /// <summary>
        /// Creates a new log entry with a severity of Debug.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        /// <param name="ex">The linked exception that caused the debug.</param>
        public void LogDebug(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Debug, ex));
        }
    
        /// <summary>
        /// Outputs the logs to console.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Outputs the logs to an external log file.
        /// </summary>
        /// <param name="directory">The directory in which to save the log files.</param>
        /// <returns></returns>
        public Logger UseLogFile(DirectoryInfo directory)
        {
            DirectoryPath = directory.FullName;

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
                    File.AppendAllText(DirectoryPath + $"\\EliteAPI.{DateTime.Now.ToShortDateString()}.log", DateTime.Now.ToLongTimeString() + " : " + s.ToString() + Environment.NewLine);
                    return;
                }
                catch { Thread.Sleep(100); }
            }
        }

        public event EventHandler<LogMessage> Log;
    }

    public class LogMessage
    {
        /// <summary>
        /// Creates a new log message.
        /// </summary>
        /// <param name="message">The content of the message.</param>
        /// <param name="severity">The severity of the message.</param>
        public LogMessage(string message, Severity severity)
        {
            Message = message;
            Severity = severity;
        }

        /// <summary>
        /// Creates a new log message with an exception.
        /// </summary>
        /// <param name="message">The content of the message.</param>
        /// <param name="severity">The severity of the message.</param>
        /// <param name="exception">The exception with which the message is linked.</param>
        public LogMessage(string message, Severity severity, Exception exception)
        {
            Message = message;
            Severity = severity;
            Exception = exception;
        }

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// The severity of the message.
        /// </summary>
        public Severity Severity { get; private set; }

        /// <summary>
        /// The exception linked with this messsage. 
        /// </summary>
        public Exception Exception { get; private set; }
    }

    /// <summary>
    /// The severity levle of the message.
    /// </summary>
    public enum Severity { Info, Warning, Error, Success, Debug }
}
