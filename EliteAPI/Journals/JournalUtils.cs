using System;
using System.IO;
using System.Runtime.InteropServices;
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
