using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using EliteAPI.Events;
using EliteAPI.Json;
using EventValueType = EliteAPI.Events.EventValueType;

namespace EliteAPI.Journals;

public static class JournalUtils
{
    public static List<EventPath> ToPaths(string json)
    {
        var eventName = JsonUtils.GetEventName(json);
        var paths = JsonUtils.FlattenJson(json);

        if (eventName == "Status")
        {
            // status events are at root level
            eventName = "";

            // remove event and timestamp
            paths.RemoveAll(p => p.Path == "event" || p.Path == "timestamp");

            // expand flags
            var flagsPath = paths.FirstOrDefault(p => p.Path == "Flags");
            var flagsValue = flagsPath.Equals(default(EventPath)) ? 0u : Convert.ToUInt32(flagsPath.Value);
            foreach (var flag in StatusUtils.GetFlags(flagsValue))
                paths.Add(new EventPath(flag.Key, flag.Value, EventValueType.Boolean));

            // expand flags2
            var flags2Path = paths.FirstOrDefault(p => p.Path == "Flags2");
            var flags2Value = flags2Path.Equals(default(EventPath)) ? 0u : Convert.ToUInt32(flags2Path.Value);
            foreach (var flag in StatusUtils.GetFlags2(flags2Value))
                paths.Add(new EventPath(flag.Key, flag.Value, EventValueType.Boolean));

            // replace pips array with individual pips
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[0]").WithPath("Pips.Systems"));
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[1]").WithPath("Pips.Engines"));
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[2]").WithPath("Pips.Weapons"));

            // replace balance with decimal type
            var balancePath = paths.FirstOrDefault(p => p.Path == "Balance");
            if (!balancePath.Equals(default(EventPath)))
            {
                paths.Remove(balancePath);
                paths.Add(new EventPath("Balance", Convert.ToDecimal(balancePath.Value), EventValueType.Decimal));
            }
        }

        return [.. paths.Select(p => p.WithPath($"EliteAPI.{eventName}.{p.Path}"))];
    }

    public static DirectoryInfo GetJournalsDirectory()
    {
        // 1) Explicit override – easiest way to point EliteAPI anywhere you want
        var envOverride = Environment.GetEnvironmentVariable("ELITE_JOURNAL_DIR");
        if (!string.IsNullOrWhiteSpace(envOverride) && Directory.Exists(envOverride))
            return new DirectoryInfo(envOverride);

        // 2) Linux / macOS – handle Proton path first
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Proton install path for Elite:
            var protonDir = Path.Combine(
                home,
                ".local", "share", "Steam", "steamapps", "compatdata", "359320",
                "pfx", "drive_c", "users", "steamuser",
                "Saved Games", "Frontier Developments", "Elite Dangerous");

            if (Directory.Exists(protonDir))
                return new DirectoryInfo(protonDir);

            // Fallback: try native Saved Games layout under $HOME
            var savedGames = Path.Combine(
                home, "Saved Games", "Frontier Developments", "Elite Dangerous");

            if (Directory.Exists(savedGames))
                return new DirectoryInfo(savedGames);
        }

        // 3) Windows – original behavior (simplified but equivalent)
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var result = SHGetKnownFolderPath(
                new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"),
                0,
                IntPtr.Zero,
                out var path);

            if (result == 0 && path != IntPtr.Zero)
            {
                var folderPath = Marshal.PtrToStringUni(path);
                if (!string.IsNullOrWhiteSpace(folderPath))
                    return new DirectoryInfo(
                        Path.Combine(folderPath, "Frontier Developments", "Elite Dangerous"));
            }

            var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            if (!string.IsNullOrWhiteSpace(userProfile))
                return new DirectoryInfo(
                    Path.Combine(userProfile, "Saved Games", "Frontier Developments", "Elite Dangerous"));

            return new DirectoryInfo(
                Path.Combine($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"));
        }

        // 4) Unknown OS – last resort
        var genericHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return new DirectoryInfo(
            Path.Combine(genericHome, "Saved Games", "Frontier Developments", "Elite Dangerous"));
    }

    public static void PrepareLocalisations(string json)
    {
        var matches = Regex.Matches(json, "\"([^\"]*?)\":\"([^\"]*?)\",[^\"]?\"([^\"]*?)_Localised\":\"([^\"]*)\"");

        foreach (Match match in matches)
        {
            var symbolKey = match.Groups[1].Value;
            var symbolValue = match.Groups[2].Value;
            var localisedKey = match.Groups[3].Value;
            var localisedValue = match.Groups[4].Value;

            if (symbolKey != localisedKey)
                continue;

            Localisation.SetLocalisedString(symbolValue, localisedValue);
        }
    }

    [DllImport("Shell32.dll")]
    private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags,
        IntPtr hToken, out IntPtr path);
}
