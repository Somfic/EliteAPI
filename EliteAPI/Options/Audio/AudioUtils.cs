using System.IO;

namespace EliteAPI.Options.Audio;

public static class AudioUtils
{
    public static DirectoryInfo GetAudioDirectory() =>
        new(Path.Combine(OptionsUtils.GetOptionsDirectory().FullName, "Audio"));
}
