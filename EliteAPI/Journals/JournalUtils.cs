using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using EliteAPI.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Journals;

public static class JournalUtils
{
    public static string GetEventName(string json)
    {
        var obj = JObject.Parse(json);
        if (obj.TryGetValue("event", out var eventNameToken))
            return eventNameToken.ToString();

        return string.Empty;
    }

    public static List<JsonPath> ToPaths(string json)
    {
        var eventName = GetEventName(json);
        var paths = JsonUtils.FlattenJson(json);

        if (eventName == "Status")
        {
            // status events are at root level
            eventName = "";

            // remove event and timestamp
            paths.RemoveAll(p => p.Path == "event" || p.Path == "timestamp");

            // expand flags
            foreach (var flag in StatusUtils.GetFlags((int)(paths.FirstOrDefault(p => p.Path == "Flags").Value as long? ?? 0)))
                paths.Add(new JsonPath(flag.Key, flag.Value, JsonType.Boolean));

            // expand flags2
            foreach (var flag in StatusUtils.GetFlags2((int)(paths.FirstOrDefault(p => p.Path == "Flags2").Value as long? ?? 0)))
                paths.Add(new JsonPath(flag.Key, flag.Value, JsonType.Boolean));

            // replace pips array with individual pips
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[0]").WithPath("Pips.Systems"));
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[1]").WithPath("Pips.Engines"));
            paths.Add(paths.FirstOrDefault(p => p.Path == "Pips[2]").WithPath("Pips.Weapons"));

            // replace balance with decimal type
            var balancePath = paths.FirstOrDefault(p => p.Path == "Balance");
            if (!balancePath.Equals(default(JsonPath)))
            {
                paths.Remove(balancePath);
                paths.Add(new JsonPath("Balance", Convert.ToDecimal(balancePath.Value), JsonType.Decimal));
            }
        }

        return [.. paths.Select(p => p.WithPath($"EliteAPI.{eventName}.{p.Path}"))];
    }

    public static DirectoryInfo GetJournalsDirectory()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // on windows, use registry
            var result = SHGetKnownFolderPath(
                new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"),
                0,
                new IntPtr(0),
                out var path);

            if (result == 0 && path != IntPtr.Zero)
            {
                var folderPath = Marshal.PtrToStringUni(path);
                if (!string.IsNullOrWhiteSpace(folderPath))
                    return new DirectoryInfo(Path.Combine(folderPath, "Frontier Developments", "Elite Dangerous"));
            }
        }

        // get through userprofile
        var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
        if (!string.IsNullOrWhiteSpace(userProfile))
            return new DirectoryInfo(Path.Combine(userProfile, "Saved Games", "Frontier Developments", "Elite Dangerous"));

        // last resort, hardcoded with C:\ drive, hopefully we'll never reach this..
        return new DirectoryInfo(Path.Combine($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"));
    }

    [DllImport("Shell32.dll")]
    private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags,
        IntPtr hToken, out IntPtr path);
}
