using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Provider;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI
{
    public interface IEliteDangerousAPI
    {
        Task StartAsync();
    }

    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly IEventProvider _eventProvider;
        private readonly IEventProcessor _eventProcessor;
        private readonly IJournalProvider _journalProvider;
        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        //private readonly IJournalProcesser _journalProcessor;

        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IConfiguration _config;

        public DirectoryInfo JournalDirectory { get; private set; }
        public FileInfo JournalFile { get; private set; }
        public FileInfo StatusFile { get; private set; }
        public IEnumerable<FileInfo> SupportFiles { get; private set; }

        public EliteDangerousAPI(IServiceProvider services)
        {
            try
            {
                _log = services.GetRequiredService<ILogger<EliteDangerousAPI>>();
                _config = services.GetRequiredService<IConfiguration>();

                _eventProvider = services.GetRequiredService<IEventProvider>();
                _eventProcessor = services.GetRequiredService<IEventProcessor>();

                _journalProvider = services.GetRequiredService<IJournalProvider>();
                _journalDirectoryProvider = services.GetRequiredService<IJournalDirectoryProvider>();
            }
            catch (Exception ex)
            {
                InitializationException = ex;
            }
        }
        private Exception InitializationException { get; }

        public async Task StartAsync()
        {
            if (InitializationException != null)
            {
                _log?.LogCritical(InitializationException, "EliteAPI could not be initialized");
                throw InitializationException;
            }

            try
            {
                _log.LogInformation("Starting EliteAPI v{version}", GetApiVersion());

                await CheckComputerOperatingSystem();
                await SetJournalDirectory();
                await SetJournalFile();
                await SetStatusFile();
                await SetSupportFiles(); // doesn't throw exception when there aren't any support files ??

                _log.LogInformation("EliteAPI is ready");
            }
            catch (Exception ex)
            {
                _log.LogCritical(ex, "EliteAPI could not be started");
            }
        }

        private async Task SetJournalDirectory()
        {
            try
            {
                var newJournalDirectory = await _journalDirectoryProvider.FindJournalDirectory();
                if (JournalDirectory?.FullName == newJournalDirectory.FullName) return;

                _log.LogInformation("Setting journal directory to {filePath}", newJournalDirectory.FullName);
                JournalDirectory = newJournalDirectory;
            }
            catch (Exception ex)
            {
                _log.LogError(ex,"Could not find journal directory");
                throw;
            }
            
        }

        private async Task SetJournalFile()
        {
            try
            {
                var newJournalFile = await _journalProvider.FindJournalFile(JournalDirectory);

                if (JournalFile?.FullName == newJournalFile.FullName) return;

                _log.LogInformation("Setting journal file to {filePath}", newJournalFile.Name);
                JournalFile = newJournalFile;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not find the active journal file");
                throw;
            }
        }

        private async Task SetStatusFile()
        {
            try
            {
                StatusFile = await _journalProvider.FindStatusFile(JournalDirectory);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not find the Status.json file");
                throw;
            }
        }


        private async Task SetSupportFiles()
        {
            try
            {
                SupportFiles = await _journalProvider.FindSupportFiles(JournalDirectory);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find support files");
            }
        }

        private Task CheckComputerOperatingSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _log.LogWarning("You are not running on a Windows machine, some features may not work properly");
            }

            return Task.CompletedTask;
        }

        private string GetApiVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
