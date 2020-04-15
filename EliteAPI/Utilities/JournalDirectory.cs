using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Somfic.Logging;

namespace EliteAPI.Utilities
{
    internal static class JournalDirectory
    {
        internal static DirectoryInfo GetStandardDirectory()
        {
            DirectoryInfo fallBackDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            // Don't try to find the special folder if not on Windows.
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return fallBackDirectory;
            }

            int result = UnsafeNativeMethods.SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out IntPtr path);
            if (result < 0) return fallBackDirectory;
            try { return new DirectoryInfo(Marshal.PtrToStringUni(path) + "/Frontier Developments/Elite Dangerous"); }
            catch { return fallBackDirectory; }

        }

        internal static bool CheckDirectory(DirectoryInfo dir)
        {
            Logger.Debug($"Checking Journal directory {dir.FullName}.");

            // Check if exists.
            if (!dir.Exists)
            {
                Logger.Warning("The Journal directory does not exist.", new DirectoryNotFoundException($"The directory {dir.FullName} could not be found."));
                return false;
            }

            // Check if has Journal files
            const string filter = "Journal.*.log";
            if (dir.GetFiles(filter).Length == 0)
            {
                Logger.Warning("The Journal directory does not contain any Journal log files.", new FileNotFoundException($"No {filter} file could be found.", Path.Combine(dir.FullName, filter)));
                return false;
            }

            // Check if has Status.json file
            if (dir.GetFiles("Status.json").Length != 1)
            {
                Logger.Warning("The Journal directory does not contain a Status.json.", new FileNotFoundException($"No Status.json file could be found.", Path.Combine(dir.FullName, "Status.json")));
                return false;
            }

            // Check the other support files.
            foreach (string supportFile in EliteDangerousAPI.SupportFiles)
            {
                if (supportFile == "Status.json") { continue; }
                if (dir.GetFiles(supportFile).Length != 1)
                {
                    Logger.Debug($"The Journal directory does not contain a {supportFile}.", new FileNotFoundException($"No {supportFile} file could be found.", Path.Combine(dir.FullName, supportFile)));
                }
            }

            return true;
        }
    }
}
