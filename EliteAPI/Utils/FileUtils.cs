using System;
using System.IO;
using System.Threading;

namespace EliteAPI.Utils;

public static class FileUtils
{
    private static readonly object FileLock = new();

    /// <summary>
    /// Writes content to a file with retry logic for handling temporary file locks.
    /// Uses a lock to prevent concurrent writes and FileShare.Read to allow readers.
    /// </summary>
    /// <param name="path">The file path to write to</param>
    /// <param name="content">The content to write</param>
    /// <param name="maxRetries">Maximum number of retry attempts (default: 3)</param>
    /// <param name="retryDelayMs">Delay between retries in milliseconds (default: 50)</param>
    /// <exception cref="IOException">Thrown if all retry attempts fail</exception>
    public static void WriteWithRetry(string path, string content, int maxRetries = 3, int retryDelayMs = 50)
    {
        lock (FileLock)
        {
            for (var i = 0; i < maxRetries; i++)
            {
                try
                {
                    using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
                    using var writer = new StreamWriter(stream);
                    writer.Write(content);
                    return;
                }
                catch (IOException) when (i < maxRetries - 1)
                {
                    Thread.Sleep(retryDelayMs);
                }
            }
        }
    }

    /// <summary>
    /// Appends content to a file with retry logic for handling temporary file locks.
    /// Uses a lock to prevent concurrent writes and FileShare.Read to allow readers.
    /// </summary>
    /// <param name="path">The file path to append to</param>
    /// <param name="content">The content to append</param>
    /// <param name="maxRetries">Maximum number of retry attempts (default: 3)</param>
    /// <param name="retryDelayMs">Delay between retries in milliseconds (default: 50)</param>
    /// <exception cref="IOException">Thrown if all retry attempts fail</exception>
    public static void AppendWithRetry(string path, string content, int maxRetries = 3, int retryDelayMs = 50)
    {
        lock (FileLock)
        {
            for (var i = 0; i < maxRetries; i++)
            {
                try
                {
                    using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read);
                    using var writer = new StreamWriter(stream);
                    writer.Write(content);
                    return;
                }
                catch (IOException) when (i < maxRetries - 1)
                {
                    Thread.Sleep(retryDelayMs);
                }
            }
        }
    }
}
