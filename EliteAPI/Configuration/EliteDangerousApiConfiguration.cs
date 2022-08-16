using System;
using System.IO;
using System.Runtime.InteropServices;
using EliteAPI.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Configuration;

/// <inheritdoc />
public class EliteDangerousApiConfiguration : IEliteDangerousApiConfiguration
{
    private readonly IConfiguration _config;
    private readonly ILogger<EliteDangerousApiConfiguration> _log;

    private IConfiguration _lastConfig;

    /// <summary>Creates a new instance of <see cref="EliteDangerousApiConfiguration" /></summary>
    public EliteDangerousApiConfiguration(ILogger<EliteDangerousApiConfiguration> log, IConfiguration config)
    {
        _log = log;
        _config = config;
    }

    /// <inheritdoc />
    public string JournalsPath { get; private set; }

    /// <inheritdoc />
    public string JournalPattern { get; private set; }

    /// <inheritdoc />
    public string OptionsPath { get; private set; }

    /// <inheritdoc />
    public void Apply()
    {
        _log.LogTrace("Applying configuration");

        JournalsPath = _config.GetValue("EliteAPI:JournalsPath",
            Path.Combine(GetSavedGamesPath(), "Frontier Developments", "Elite Dangerous"));
        
        OptionsPath = _config.GetValue("EliteAPI:OptionsPath",
            Path.Combine(GetLocalAppDataPath(), "Frontier Developments", "Elite Dangerous", "Options"));
        
        JournalPattern = _config.GetValue("EliteAPI:JournalPattern", "Journal.*.log");

        if (!Directory.Exists(JournalsPath))
            _log.LogWarning(new DirectoryNotFoundException($"{JournalsPath} does not exist."),
                "The specified journals directory could not be found");

        if (!Directory.Exists(OptionsPath))
            _log.LogWarning(new DirectoryNotFoundException($"{OptionsPath} does not exist."),
                "The specified options directory could not be found");
    }

    private string GetSavedGamesPath()
    {
        try
        {
            // If we're on Windows, we can use the registry to get the path
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var result = SHGetKnownFolderPath(
                    new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"),
                    0,
                    new IntPtr(0),
                    out var path);

                // If we got a path, return it
                if (result == 0)
                    return Marshal.PtrToStringUni(path);
            }

            // Otherwise, we'll get the path using userprofile
            var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");

            // If we got a path, return it
            if (!string.IsNullOrWhiteSpace(userProfile))
                return Path.Combine(userProfile, "Saved Games");

            // Last resort, return the default
            return Path.Combine($@"C:\Users\{Environment.UserName}\Saved Games");
        }
        catch (Exception ex)
        {
            _log.LogDebug(ex, "Could not get the Saved Games directory");
            throw;
        }
    }

    private string GetLocalAppDataPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }

    [DllImport("Shell32.dll")]
    private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags,
        IntPtr hToken, out IntPtr path);
}