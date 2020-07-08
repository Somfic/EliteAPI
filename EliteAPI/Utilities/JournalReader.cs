using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EliteAPI.Utilities
{
    internal static class JournalReader
    {
        public static bool HasCatchedUp { get; private set; }

        private static bool ShouldBeWatching { get; set; }

        internal static void StartWatching(DirectoryInfo dir, bool catchUp)
        {
            ShouldBeWatching = true;

            Task.Run(() =>
            {
                FileInfo lastJournal = null;

                List<string> processedLogs = new List<string>();
                Dictionary<string, string> lastEntry = EliteDangerousAPI.SupportFiles.ToDictionary(supportFile => supportFile, supportFile => "");


                while (ShouldBeWatching)
                {
                    try
                    {

                        // Get the last changed journal file.
                        FileInfo newJournal = JournalDirectory.GetActiveJournalFile(dir);

                        if (lastJournal == null || lastJournal.FullName != newJournal.FullName)
                        {
                            // We're reading from a different file.
                            Logger.Debug($"{newJournal.Name} selected.");
                            lastJournal = newJournal;

                            processedLogs = new List<string>();
                        }

                        if (!HasCatchedUp && catchUp)
                        {
                            Logger.Debug("Catching up on past events.");
                        }

                        foreach (string log in FileReader.ReadAllLines(newJournal.FullName))
                        {
                            if (processedLogs.Contains(log))
                            {
                                continue;
                            }

                            // New log entry.
                            processedLogs.Add(log);
                            JournalEntry?.Invoke(null, log);
                        }

                        if (!HasCatchedUp)
                        {
                            HasCatchedUp = true;

                            if (catchUp)
                            {
                                Logger.Debug("Catched up on past events.");
                            }
                        }

                        // Process the 
                        foreach (string supportFile in EliteDangerousAPI.SupportFiles)
                        {
                            string path = Path.Combine(dir.FullName, supportFile);

                            if (!File.Exists(path)) continue;

                            string log = FileReader.ReadAllText(path);

                            if (lastEntry[supportFile] == log) continue;

                            // New log entry.
                            Enum.TryParse(supportFile.Substring(0, supportFile.Length - 5), out SupportFile file);
                            SupportEntry?.Invoke(null, (file, log));
                            lastEntry[supportFile] = log;
                        }

                        // Check again after 250ms.
                        Thread.Sleep(250);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Could not update from log files.", ex);
                    }
                }
            });
        }

        internal static void StopWatching()
        {
            ShouldBeWatching = false;
        }

        internal static event EventHandler<string> JournalEntry;

        internal static event EventHandler<(SupportFile, string)> SupportEntry;
    }
}
