using System;
using System.IO;
using System.Text;
using System.Threading;

namespace EliteAPI.Logging
{
    public class Logger
    {
        private string DirectoryPath = "";

        private string LogFile = "";

        private readonly EliteDangerousAPI EliteAPI;
        private Severity MinType = Severity.Debug;

        public Logger(EliteDangerousAPI api)
        {
            EliteAPI = api;
            api.OnError += (sender, e) => LogError($"EliteAPI could not start: {e.Item1}.", e.Item2);
            api.OnReady += (sender, e) => LogSuccess($"EliteAPI is ready.");
        }

        /// <summary>
        /// Creates a new log entry with a severity of Info.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogInfo(object s)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Info));
        }

        /// <summary>
        /// Creates a new log entry with a severity of Info.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        /// <param name="ex">The linked exception that caused the log.</param>
        public void LogInfo(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Info, ex));
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
        /// Creates a new log entry with a severity of Success.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        /// <param name="ex">The linked exception that caused the log.</param>
        public void LogSuccess(object s, Exception ex)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Success, ex));
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
        /// Creates a new log entry with a severity of Debug for events.
        /// </summary>
        /// <param name="s">The content of the log.</param>
        public void LogDebugEvent(object s, object x)
        {
            Log?.Invoke(this, new LogMessage(s.ToString(), Severity.Debug));

            string currentEvent = Newtonsoft.Json.JsonConvert.SerializeObject(x);
            Log?.Invoke(this, new LogMessage(currentEvent, Severity.DebugEvent));
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

        public Logger UseConsole(Severity type)
        {
            MinType = type;
            return UseConsole();
        }

        /// <summary>
        /// Outputs the logs to console.
        /// </summary>
        /// <returns></returns>
        public Logger UseConsole()
        {
            Log += (sender, arg) =>
            {
                if (arg.Severity <= MinType)
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

                        case Severity.DebugEvent:
                            Write(Severity.Debug, ConsoleColor.DarkGray, arg.Message, arg.Exception);
                            break;
                    }
                };
            };

            return this;
        }

        /// <summary>
        /// Outputs the logs to an external log file.
        /// </summary>
        /// <param name="directory">The directory in which to save the log files.</param>
        /// <returns></returns>
        public Logger UseLogFile(string directory)
        {
            if(!Directory.Exists(directory)) { LogError($"Path '{directory}' could not be found for logging."); return this; }

            DirectoryPath = directory;

            string date = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}";

            int i = 1;
            while (true) {
                if (!File.Exists(DirectoryPath + $"\\EliteAPI.{date}.{i}.log"))
                {
                    LogFile = DirectoryPath + $"\\EliteAPI.{date}.{i}.log";
                    break;
                } else
                {
                    i++;
                }
            }

            try { File.WriteAllText(LogFile, ""); }
            catch (Exception ex) { LogError($"Could not use {LogFile} as log file. Proceeding without logging.", ex); return this; }

            WriteToLog("======= NEW LOG ENTRY =======");
            EliteAPI.OnQuit += (sender, arg) => WriteToLog("======== END OF LOG =========");

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

                    case Severity.DebugEvent:
                        WriteLog(arg.Message);
                        break;
                }
            };

            LogInfo($"Logging to {LogFile}.");

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

            if (severity == Severity.Error || severity == Severity.Warning || severity == Severity.Success)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = color;
            }
            else { Console.ForegroundColor = color; }
            Console.WriteLine($" {content} ");

            if (ex != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Black; ;
                Console.SetCursorPosition(8, Console.CursorTop);
                Console.Write("|");
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = color;
                Console.WriteLine($" {ex.Message} ");
                Console.BackgroundColor = ConsoleColor.Black;

                if (ex.StackTrace != null)
                {
                    string[] trace = ex.StackTrace.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string x in trace)
                    {
                        string m = x.Trim();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Black; ;
                        Console.SetCursorPosition(8, Console.CursorTop);
                        Console.Write("|");
                        Console.SetCursorPosition(10, Console.CursorTop);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = color;
                        Console.WriteLine($" {m} ");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void WriteLog(Severity severity, string content, Exception ex = null)
        {
            StringBuilder s = new StringBuilder("                     ");
            s.Insert(0, DateTime.Now.ToLongTimeString() + " :");
            s.Insert(11, severity.ToString());
            s.Insert(19, $": " + content);

            WriteToLog(s);

            if (ex != null)
            {
                s = new StringBuilder("                     ");
                s.Insert(19, "| " + ex.Message);
                WriteToLog(s);

                if (ex.StackTrace != null) { 
                    string[] trace = ex.StackTrace.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string x in trace)
                    {
                        string m = x.Trim();
                        s = new StringBuilder("                     ");
                        s.Insert(19, "| " + m);
                        WriteToLog(s);
                    }
                }
            }
        }

        private void WriteLog(string content)
        {
            StringBuilder s = new StringBuilder("                     ");
            s.Insert(19, $"| " + content);

            WriteToLog(s);
        }

        private void WriteToLog(object s)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    File.AppendAllText(LogFile, $"{s.ToString()}{Environment.NewLine}");
                    return;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); }
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
    public enum Severity
    {
        Success, Error, Warning, Info, Debug, DebugEvent
    }
}
