using Newtonsoft.Json;
using Somfic.Logging;
using System;
using System.IO;
using EliteAPI.Status;

namespace EliteAPI.Utilities
{
    internal static class StatusReader
    {
        public static T Read<T>(DirectoryInfo journal, string file) where T : StatusBase
        {
            string path = Path.Combine(journal.FullName, file);

            if (!File.Exists(path))
            {
                Logger.Debug($"{path} doesn't exists.");
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(FileReader.ReadAllText(path));
            }
            catch (Exception ex)
            {
                Logger.Warning($"Could not process {file}.", ex);
                return null;
            }
        }
    }
}

