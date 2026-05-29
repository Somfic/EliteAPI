using System.IO;

namespace EliteAPI.Options.Player;

public static class PlayerUtils
{
    public static DirectoryInfo GetPlayerDirectory() =>
        new(Path.Combine(OptionsUtils.GetOptionsDirectory().FullName, "Player"));
}
