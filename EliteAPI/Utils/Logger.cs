using System;
using System.Collections.Generic;
using System.IO;

namespace EliteAPI.Utils;

public static class Log
{
    private static readonly object _fileLock = new();
    private static readonly object _listenerLock = new();
    private static string? _logFilePath;
    private static readonly List<Action<LogMessage>> _listeners = [];

    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }

    public record LogMessage(DateTime Timestamp, LogLevel Level, string Message);

    /// <summary>
    /// Sets the log file path. If not set, logs will be written to a default location.
    /// </summary>
    public static void SetLogFilePath(string path)
    {
        // create directory if it doesn't exist
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory!);

        // if file doesn't exist, create it
        if (!File.Exists(path))
            File.Create(path).Dispose();

        lock (_fileLock)
        {
            _logFilePath = path;
        }
    }

    /// <summary>
    /// Adds a listener that will be called whenever a log message is written.
    /// </summary>
    public static void AddListener(Action<LogMessage> listener)
    {
        lock (_listenerLock)
        {
            _listeners.Add(listener);
        }
    }

    /// <summary>
    /// Removes a previously registered listener.
    /// </summary>
    public static void RemoveListener(Action<LogMessage> listener)
    {
        lock (_listenerLock)
        {
            _listeners.Remove(listener);
        }
    }

    /// <summary>
    /// Removes all registered listeners.
    /// </summary>
    public static void ClearListeners()
    {
        lock (_listenerLock)
        {
            _listeners.Clear();
        }
    }

    /// <summary>
    /// Logs a debug message
    /// </summary>
    public static void Debug(string message)
    {
        Write(LogLevel.Debug, message);
    }

    /// <summary>
    /// Logs an informational message
    /// </summary>
    public static void Info(string message)
    {
        Write(LogLevel.Info, message);
    }

    /// <summary>
    /// Logs a warning message
    /// </summary>
    public static void Warning(string message)
    {
        Write(LogLevel.Warning, message);
    }

    /// <summary>
    /// Logs an error message
    /// </summary>
    public static void Error(string message)
    {
        Write(LogLevel.Error, message);
    }

    /// <summary>
    /// Logs an error with exception details
    /// </summary>
    public static void Error(string message, Exception exception)
    {
        Write(LogLevel.Error, $"{message}: {exception}");
    }

    /// <summary>
    /// Logs a message with the specified log level
    /// </summary>
    public static void Write(LogLevel level, string message)
    {
        var timestamp = DateTime.Now;
        var logEntry = $"[{timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}";

        // Write to file in a thread-safe manner
        lock (_fileLock)
        {
            try
            {
                var logPath = GetLogFilePath();
                var directory = Path.GetDirectoryName(logPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(logPath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // If we can't write to the log file, at least write to console
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        // Notify listeners in a thread-safe manner
        List<Action<LogMessage>> listenersCopy;
        lock (_listenerLock)
        {
            listenersCopy = [.. _listeners];
        }

        var logMessage = new LogMessage(timestamp, level, message);
        foreach (var listener in listenersCopy)
        {
            SafeInvoke.Invoke("logging", listener, logMessage);
        }
    }

    private static string GetLogFilePath()
    {
        if (!string.IsNullOrEmpty(_logFilePath))
            return _logFilePath!;

        // Default log file path in the user's temp directory
        var defaultPath = Path.Combine(Path.GetTempPath(), "EliteAPI", "eliteapi.log");
        return defaultPath;
    }
}
