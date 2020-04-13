using Somfic.Logging;
using System.IO;

namespace EliteAPI.Status
{
    public class StatusReader
    {
        internal const string STATUS = "Status.json";
        internal const string CARGO = "Cargo.json";
        internal const string MARKET = "Market.json";
        internal const string MODULES = "ModulesInfo.json";
        internal const string OUTFITTING = "Outfitting.json";
        internal const string SHIPYARD = "Shipyard.json";

        internal StatusReader(EliteDangerousAPI api, string file)
        {
            this.api = api;

            path = new FileInfo(Path.Combine(api.JournalDirectory.FullName, file));
            CheckFile(true);
        }

        public StatusResult Read()
        {
            // If we couldn't read at the constructor, check again.
            if(!IsReading && !CheckFile()) { return null; }

            return null;
        }

        private bool CheckFile(bool log = false)
        {
            if (log) { Logger.Debug($"Checking '{path.Name}'."); }

            if (!path.Exists && path.Name != STATUS)
            {
                // All non-critical files (everything except Status.json).
                if (log) { Logger.Warning($"'{path.Name}' couldn't be found.", new FileNotFoundException("Status file could not be found.", path.FullName)); }
                return false;
            }
            
            if (!path.Exists)
            {
                // Status.json is missing.
                if (log) { Logger.Error($"'{path.Name}' couldn't be found.", new FileNotFoundException("Essential status file could not be found.", path.FullName)); }
                return false;
            }

            IsReading = true;
            return true;
        }

        private readonly EliteDangerousAPI api;

        private readonly FileInfo path;

        public bool IsReading { get; private set; }
    }

    public interface StatusResult
    {

    }
}
