using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EliteAPI.Configuration.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Options.Directory.Abstractions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Options.Directory
{
    public class OptionsDirectoryProvider : IOptionsDirectoryProvider
    {
        private readonly ILogger<IOptionsDirectoryProvider> _log;
        private readonly IConfiguration _config;
        private readonly IEliteDangerousApiConfiguration _codeConfig;

        public OptionsDirectoryProvider(ILogger<IOptionsDirectoryProvider> log, IConfiguration config, IEliteDangerousApiConfiguration codeConfig)
        {
            _log = log;
            _config = config;
            _codeConfig = codeConfig;
        }

        /// <inheritdoc />
        public Task<DirectoryInfo> FindOptionsDirectory()
        {
            var configDirectory = GetConfigDirectory();
            var codeConfigDirectory = GetCodeConfigDirectory();
            var defaultDirectory = GetDefaultDirectory();

            var exception = CheckDirectoryValidity(configDirectory);
            if (exception == null) return Task.FromResult(configDirectory);

            if (!(exception is NullReferenceException)) _log.LogDebug(exception, "The option directory provided by the file configuration is invalid");

            exception = CheckDirectoryValidity(codeConfigDirectory);
            if (exception == null) { return Task.FromResult(codeConfigDirectory); }

            if (!(exception is NullReferenceException)) _log.LogDebug(exception, "The option directory provided by the code configuration is invalid");

            if (configDirectory?.FullName != defaultDirectory.FullName)
            {
                if (!(exception is NullReferenceException))
                    _log.LogWarning(exception, "The option directory provided by the configuration is invalid");
                else
                    _log.LogDebug("No configuration value for OptionsPath set, defaulting to standard");

                exception = CheckDirectoryValidity(defaultDirectory);
                if (exception == null) return Task.FromResult(defaultDirectory);
            }

            _log.LogDebug(exception,
                "No valid options directory could not be found, please specify the correct options directory in the configuration");

            return Task.FromException<DirectoryInfo>(exception);
        }

        private Exception CheckDirectoryValidity(DirectoryInfo directory)
        {
            if (directory == null) return new NullReferenceException();

            if (!directory.Exists)
            {
                var exception = new OptionsDirectoryNotFoundException("The options directory does not exist");
                exception.Data.Add("Path", directory.FullName);
                return exception;
            }

            var directories = directory.GetDirectories();

            if (directories.Count(x => x.Name == "Bindings") == 0)
            {
                var exception = new OptionsDirectoryNotFoundException("Directory does not contain the Bindings directory");
                exception.Data.Add("Path", directory.FullName);
                return exception;
            }

            return null;
        }

        private DirectoryInfo GetDefaultDirectory()
        {
            try { return new DirectoryInfo(Path.Combine(GetLocalAppDataDirectory(), "Frontier Developments/Elite Dangerous/Options")); }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get default options directory");
                return null;
            }
        }

        private DirectoryInfo GetCodeConfigDirectory()
        {
            try { return !string.IsNullOrWhiteSpace(_codeConfig.OptionsPath) ? new DirectoryInfo(_codeConfig.OptionsPath) : null; }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get options directory");
                return null;
            }
        }

        private DirectoryInfo GetConfigDirectory()
        {
            try
            {
                var suggestedPath = _config.GetSection("EliteAPI")["OptionsPath"];
                return !string.IsNullOrWhiteSpace(suggestedPath) ? new DirectoryInfo(suggestedPath) : null;
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not get options directory");
                return null;
            }
        }

        private static string GetLocalAppDataDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
    }
}