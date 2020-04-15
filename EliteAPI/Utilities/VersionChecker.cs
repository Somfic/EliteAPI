using Somfic.Logging;
using Somfic.Version;
using Somfic.Version.Github;

namespace EliteAPI.Utilities
{
    internal static class VersionChecker
    {
        internal static bool CheckVersion()
        {
            Logger.Debug("Checking for new updates on github.com/EliteAPI/EliteAPI.");
            VersionController version = new GithubVersionControl("EliteAPI", "EliteAPI");

            Logger.Log($"Latest version: {version.Latest} (current: {version.This}).");

            if (version.This >= version.Latest)
            {
                return false;
            }

            Logger.Log($"A new update ({version.Latest}) is available. Visit github.com/EliteAPI/EliteAPI to download the latest version.");
            return true;

        }
    }
}
