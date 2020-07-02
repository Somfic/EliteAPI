using Somfic.Logging;
using System;
using System.IO;

namespace EliteAPI.Utilities
{
    public static class JournalReader
    {
        private static FileSystemWatcher journalWatcher { get; set; }
        private static DateTime lastRead { get; set; } = DateTime.MinValue;

        public static void StartWatching(DirectoryInfo dir)
        {
            // Check if the directory is valid.
            if (!JournalDirectory.CheckDirectory(dir))
            {
                return;
            }

            // Create a new journal watcher.
            journalWatcher = new FileSystemWatcher
            {
                Path = dir.FullName,
                //Filter = "Journal.*.log",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size
        };

            // Subscribe to events.
            journalWatcher.Changed += JournalWatcher_Changed;
            journalWatcher.Created += JournalWatcher_Created;

            // Start watching.
            journalWatcher.EnableRaisingEvents = true;

            Logger.Debug($"Monitoring {dir.FullName}.");
        }

        public static void StopWatching()
        {
            // Stop watching.
            journalWatcher.EnableRaisingEvents = false;

            // Unsubscribe from events.
            journalWatcher.Changed -= JournalWatcher_Changed;
            journalWatcher.Created -= JournalWatcher_Created;

            // Dispose.
            journalWatcher.Dispose();

            Logger.Debug($"Stopped monitoring journal directory.");
        }

        public static void JournalWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Logger.Debug("OnCreated triggered.", e);
        }

        public static void JournalWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime == lastRead) { return; }

            lastRead = lastWriteTime;

            Logger.Debug("OnChanged triggered.", e);
        }

        internal static event EventHandler<string> LogEntry;
    }
}
