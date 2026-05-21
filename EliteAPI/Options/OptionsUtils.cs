using System;
using System.IO;
using System.Runtime.InteropServices;

namespace EliteAPI.Options;

public static class OptionsUtils
{
    public static DirectoryInfo GetOptionsDirectory()
    {
        // 1) Explicit override – easiest way to point EliteAPI anywhere you want
        var envOverride = Environment.GetEnvironmentVariable("ELITE_OPTIONS_DIR");
        if (!string.IsNullOrWhiteSpace(envOverride) && Directory.Exists(envOverride))
            return new DirectoryInfo(envOverride);

        // 2) Linux / macOS – check Proton path first
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Proton options path:
            // ~/.local/share/Steam/steamapps/compatdata/359320/pfx/drive_c/users/steamuser/AppData/Local/Frontier Developments/Elite Dangerous/Options
            var protonOptions = Path.Combine(
                home,
                ".local", "share", "Steam", "steamapps", "compatdata", "359320",
                "pfx", "drive_c", "users", "steamuser",
                "AppData", "Local", "Frontier Developments", "Elite Dangerous", "Options");

            if (Directory.Exists(protonOptions))
                return new DirectoryInfo(protonOptions);
        }

        // 3) Fallback – original LocalApplicationData behavior
        var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return new DirectoryInfo(Path.Combine(localAppData, "Frontier Developments", "Elite Dangerous", "Options"));
    }
}
