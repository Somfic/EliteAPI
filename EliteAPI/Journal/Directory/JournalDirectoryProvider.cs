using EliteAPI.Exceptions;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Provider;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EliteAPI.Journal.Directory
{
    /// <inheritdoc />
    public class JournalDirectoryProvider : IJournalDirectoryProvider
    {
        private readonly IConfiguration _config;
        private readonly ILogger<JournalProvider> _log;

        public JournalDirectoryProvider(IServiceProvider services)
        {
            _config = services.GetRequiredService<IConfiguration>();
            _log = services.GetRequiredService<ILogger<JournalProvider>>();
        }

        /// <inheritdoc />
        public Task<DirectoryInfo> FindJournalDirectory()
        {
            var configDirectory = GetConfigDirectory();
            var defaultDirectory = GetDefaultDirectory();

            var exception = CheckDirectoryValidity(configDirectory);
            if (exception == null) return Task.FromResult(configDirectory);

            if (configDirectory?.FullName != defaultDirectory.FullName)
            {
                if (!(exception is NullReferenceException))
                    _log.LogWarning(exception, "The journal directory provided by the configuration is invalid");
                else
                    _log.LogDebug("No configuration value for JournalPath set, defaulting to standard");

                exception = CheckDirectoryValidity(defaultDirectory);
                if (exception == null) return Task.FromResult(defaultDirectory);
            }

            _log.LogDebug(exception,
                "No valid journal directory could not be found, please specify the correct journal directory in the configuration");

            return Task.FromException<DirectoryInfo>(exception);
        }

        private Exception CheckDirectoryValidity(DirectoryInfo directory)
        {
            if (directory == null) return new NullReferenceException();

            if (!directory.Exists)
            {
                var exception = new JournalDirectoryNotFoundException("The journal directory does not exist");
                exception.Data.Add("Path", directory.FullName);
                return exception;
            }

            if (directory.GetFiles("Journal.*.log").Length == 0)
            {
                var exception = new JournalFileNotFoundException("No journal files could be found in the directory");
                exception.Data.Add("Path", directory.FullName);
                return exception;
            }

            return null;
        }

        private DirectoryInfo GetDefaultDirectory()
        {
            try
            {
                return new DirectoryInfo(Path.Combine(GetSavedGamesDirectory(), "Frontier Developments/Elite Dangerous"));
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get default journal directory");
                return null;
            }
        }

        private DirectoryInfo GetConfigDirectory()
        {
            try
            {
                var suggestedPath = _config.GetSection("EliteAPI")["JournalPath"];
                return !string.IsNullOrWhiteSpace(suggestedPath) ? new DirectoryInfo(suggestedPath) : null;
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get config journal directory");
                return null;
            }
        }

        private string GetSavedGamesDirectory()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var result = SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0,
                        new IntPtr(0),
                        out var path);
                    if (result > 0) return Marshal.PtrToStringUni(path);
                }

                var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
                if (!string.IsNullOrWhiteSpace(userProfile)) return Path.Combine(userProfile, "Saved Games");

                return Path.Combine($@"C:\Users\{Environment.UserName}\Saved Games");
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get Saved Games directory");
                throw;
            }
        }

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags,
            IntPtr hToken, out IntPtr ppszPath);
    }
}