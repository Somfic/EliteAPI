using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteAPI.Event.Models;
using EliteAPI.Event.Processor;
using EliteAPI.Event.Provider;
using EliteAPI.Journal.Directory;
using EliteAPI.Journal.Processor;
using EliteAPI.Journal.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI
{
    /// <summary>
    /// EliteDangerousAPI base class
    /// </summary>
    public interface IEliteDangerousAPI
    {

        /// <summary>
        /// Whether the api is currently running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Initializes the api
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Starts the api
        /// </summary>
        Task StartAsync();
    }

    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IConfiguration _config;

        private readonly IEventProvider _eventProvider;
        private readonly IEventProcessor _eventProcessor;

        private readonly IJournalProvider _journalProvider;
        private readonly IJournalProcessor _journalProcessor;

        private readonly IJournalDirectoryProvider _journalDirectoryProvider;

        private DirectoryInfo JournalDirectory { get; set; }
        private FileInfo JournalFile { get; set; }
        private FileInfo StatusFile { get; set; }
        private IEnumerable<FileInfo> SupportFiles { get; set; }

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

                _journalProcessor = services.GetRequiredService<IJournalProcessor>();
            }
            catch (Exception ex)
            {
                InitializationException = ex;
            }
        }
        private Exception InitializationException { get; }

        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        private bool IsInitialized { get; set; }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            if (InitializationException != null)
            {
                _log?.LogCritical(InitializationException, "EliteAPI could not be initialized");
                throw InitializationException;
            }

            try
            {
                _log.LogInformation("Initializing EliteAPI v{version}", GetApiVersion());

                await CheckComputerOperatingSystem();
                await InitializeEventHandlers();
                await SetJournalDirectory();
                await SetStatusFile();
                await SetSupportFiles();
                await SetJournalFile();

                _journalProcessor.NewJournalEntry += async (sender, json) =>
                {
                    EventBase eventBase = await _eventProvider.ProcessJsonEvent(json);
                    await _eventProcessor.InvokeHandler(eventBase);
                };

                IsInitialized = true;
            }
            catch (Exception ex)
            {
                _log.LogCritical(ex, "EliteAPI could not be initialized");
                //throw;
            }
        }

        /// <inheritdoc />
        public async Task StartAsync()
        {
            if (!IsInitialized)
            {
                await InitializeAsync();
            }

            IsRunning = true;

            Task task = Task.Run(async () =>
            {
                while (IsRunning)
                {
                    await SetJournalFile();
                    await _journalProcessor.ProcessJournalFile(JournalFile);
                    await _journalProcessor.ProcessSupportFiles(SupportFiles);

                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }
            });
        }

        public void Stop()
        {

        }

        private async Task InitializeEventHandlers()
        {
            try
            {
                await _eventProcessor.RegisterHandlers();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not initialize event handlers");
                throw;
            }
        }

        private async Task SetJournalDirectory()
        {
            try
            {
                DirectoryInfo newJournalDirectory = await _journalDirectoryProvider.FindJournalDirectory();
                if (newJournalDirectory == null || JournalDirectory?.FullName == newJournalDirectory.FullName)
                {
                    return;
                }

                _log.LogInformation("Setting journal directory to {filePath}", newJournalDirectory.FullName);
                JournalDirectory = newJournalDirectory;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not find journal directory");
                throw;
            }

        }

        private async Task SetJournalFile()
        {
            try
            {
                FileInfo newJournalFile = await _journalProvider.FindJournalFile(JournalDirectory);

                if (JournalFile?.FullName == newJournalFile.FullName)
                {
                    return;
                }

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
                var newStatusFile = await _journalProvider.FindStatusFile(JournalDirectory);
                if (newStatusFile != null) { StatusFile = newStatusFile; }
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

        private string GetApiVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
