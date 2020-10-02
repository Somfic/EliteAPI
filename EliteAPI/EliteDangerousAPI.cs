using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Processor.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Journal.Provider.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    /// <inheritdoc />
    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        /// <inheritdoc />
        public Version Version { get; }

        /// <inheritdoc />
        public EventHandler Events { get; }

        public EliteDangerousAPI(IServiceProvider services)
        {
            try
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version;

                _log = services.GetRequiredService<ILogger<EliteDangerousAPI>>();
                _config = services.GetRequiredService<IConfiguration>();

                _eventProvider = services.GetRequiredService<IEventProvider>();
                _eventProcessors = services.GetRequiredService<IEnumerable<IEventProcessor>>();

                _journalProvider = services.GetRequiredService<IJournalProvider>();
                _journalDirectoryProvider = services.GetRequiredService<IJournalDirectoryProvider>();

                _journalProcessor = services.GetRequiredService<IJournalProcessor>();

                Events = services.GetRequiredService<EventHandler>();
            }
            catch (Exception ex)
            {
                InitializationException = ex;
            }
        }

        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IConfiguration _config;

        private readonly IEventProvider _eventProvider;
        private readonly IEnumerable<IEventProcessor> _eventProcessors;

        private readonly IJournalProvider _journalProvider;
        private readonly IJournalProcessor _journalProcessor;

        private readonly IJournalDirectoryProvider _journalDirectoryProvider;

        private DirectoryInfo JournalDirectory { get; set; }
        private FileInfo JournalFile { get; set; }
        private FileInfo StatusFile { get; set; }
        private IEnumerable<FileInfo> SupportFiles { get; set; }

        private Exception InitializationException { get; }

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
                _log.LogInformation("Initializing EliteAPI v{version}", Version.ToString());

                await CheckComputerOperatingSystem();
                await InitializeEventHandlers();
                await SetJournalDirectory();
                await SetJournalFile();

                _journalProcessor.NewJournalEntry += _journalProcessor_NewJournalEntry;

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

                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }
            });
        }

        public void Stop()
        {
            _journalProcessor.NewJournalEntry -= _journalProcessor_NewJournalEntry;
            IsRunning = false;
        }

        private async Task InitializeEventHandlers()
        {

            foreach (IEventProcessor eventProcessor in _eventProcessors)
            {
                try
                {
                    await eventProcessor.RegisterHandlers();
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, "Could not initialize event handler {name}", eventProcessor.GetType().FullName);
                    throw;
                }
            }
        }

        private async void _journalProcessor_NewJournalEntry(object sender, string e)
        {
            EventBase eventBase = await _eventProvider.ProcessJsonEvent(e);
            foreach (IEventProcessor eventProcessor in _eventProcessors)
            {
                await eventProcessor.InvokeHandler(eventBase);
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

        private Task CheckComputerOperatingSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _log.LogWarning("You are not running on a Windows machine, some features may not work properly");
            }

            return Task.CompletedTask;
        }
    }
}
