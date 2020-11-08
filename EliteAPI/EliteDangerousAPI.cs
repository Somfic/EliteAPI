using EliteAPI.Abstractions;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Processor.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Journal.Provider.Abstractions;
using EliteAPI.Status.Models;
using EliteAPI.Status.Models.Abstractions;
using EliteAPI.Status.Processor.Abstractions;
using EliteAPI.Status.Provider.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    /// <inheritdoc />
    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        /// <inheritdoc />
        public bool HasCatchedUp { get; private set; }

        /// <inheritdoc />
        public Version Version { get; }

        /// <inheritdoc />
        public EventHandler Events { get; }

        /// <inheritdoc />
        public IShipStatus Status { get; private set; }

        public EliteDangerousAPI(IServiceProvider services)
        {
            try
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version;

                _log = services.GetRequiredService<ILogger<EliteDangerousAPI>>();
                _config = services.GetRequiredService<IConfiguration>();

                _eventProvider = services.GetRequiredService<IEventProvider>();
                _eventProcessors = services.GetRequiredService<IEnumerable<IEventProcessor>>();

                _journalDirectoryProvider = services.GetRequiredService<IJournalDirectoryProvider>();

                _journalProvider = services.GetRequiredService<IJournalProvider>();
                _journalProcessor = services.GetRequiredService<IJournalProcessor>();

                _statusProvider = services.GetRequiredService<IStatusProvider>();
                _statusProcessor = services.GetRequiredService<IStatusProcessor>();

                Events = services.GetRequiredService<EventHandler>();
                Status = services.GetRequiredService<IShipStatus>();
            }
            catch (Exception ex)
            {
                PreInitializationException = ex;
            }
        }

        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IConfiguration _config;

        private readonly IEventProvider _eventProvider;
        private readonly IEnumerable<IEventProcessor> _eventProcessors;

        private readonly IJournalProvider _journalProvider;
        private readonly IJournalProcessor _journalProcessor;

        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        private readonly IStatusProvider _statusProvider;
        private readonly IStatusProcessor _statusProcessor;

        private DirectoryInfo JournalDirectory { get; set; }
        private FileInfo JournalFile { get; set; }
        private FileInfo StatusFile { get; set; }
        private FileInfo CargoFile { get; set; }
        private FileInfo MarketFile { get; set; }
        private FileInfo OutfittingFile { get; set; }
        private FileInfo ShipyardFile { get; set; }

        private Exception PreInitializationException { get; }
        private Exception InitializationException { get; set; }

        private bool IsInitialized { get; set; }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            if (PreInitializationException != null)
            {
                _log?.LogCritical(PreInitializationException, "EliteAPI could not load required services");
                throw PreInitializationException;
            }

            if (IsInitialized)
            {
                return;
            }

            try
            {
                _log.LogInformation("Initializing EliteAPI v{version}", Version.ToString());

                await CheckComputerOperatingSystem();
                await InitializeEventHandlers();
                await SetJournalDirectory();
                await SetJournalFile();
                await SetSupportFiles();

                _journalProcessor.NewJournalEntry += _journalProcessor_NewJournalEntry;

                _log.LogDebug("EliteAPI has initialized");
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "EliteAPI could not be initialized");
                InitializationException = ex;
            }

            IsInitialized = true;
        }

        /// <inheritdoc />
        public async Task StartAsync()
        {
            if (!IsInitialized)
            {
                await InitializeAsync();
            }

            if (InitializationException != null)
            {
                _log.LogCritical(InitializationException, "EliteAPI could not be started");
                await StopAsync();
                return;
            }

            IsRunning = true;

            Task task = Task.Run(async () =>
            {
                while (IsRunning)
                {
                    await DoTick();
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }
            });

            _log.LogInformation("EliteAPI has started");
        }

        private bool _isFirstTick = true;
        private async Task DoTick()
        {
            try
            {
                await SetSupportFiles();
                await _statusProcessor.ProcessStatusFile(StatusFile);
                await _statusProcessor.ProcessCargoFile(CargoFile);
                await _statusProcessor.ProcessMarketFile(MarketFile);
                await _statusProcessor.ProcessOutfittingFile(OutfittingFile);
                await _statusProcessor.ProcessShipyardFile(ShipyardFile);

                await SetJournalFile();
                await _journalProcessor.ProcessJournalFile(JournalFile, !HasCatchedUp);

                if (!HasCatchedUp)
                {
                    _log.LogInformation("EliteAPI has catched up to current session");
                    HasCatchedUp = true;
                }
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not do tick");
            }
        }

        public Task StopAsync()
        {
            _journalProcessor.NewJournalEntry -= _journalProcessor_NewJournalEntry;

            IsRunning = false;
            IsInitialized = false;

            return Task.CompletedTask;
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
                    _log.LogWarning(ex, "Could not initialize event handler {name}", eventProcessor.GetType().FullName);
                    throw;
                }
            }
        }

        private async void _journalProcessor_NewJournalEntry(object sender, JournalEntry e)
        {
            try
            {
                EventBase eventBase = await _eventProvider.ProcessJsonEvent(e.Json);
                foreach (IEventProcessor eventProcessor in _eventProcessors)
                {
                    await eventProcessor.InvokeHandler(eventBase, e.IsWhileCatchingUp);
                }
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not execute event");
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
                _log.LogWarning(ex, "Could not find journal directory");
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
                _log.LogWarning(ex, "Could not find the active journal file");
                throw;
            }
        }

        private async Task SetSupportFiles()
        {
            try
            {
                StatusFile = await _statusProvider.FindStatusFile(JournalDirectory);
                CargoFile = await _statusProvider.FindCargoFile(JournalDirectory);
                MarketFile = await _statusProvider.FindMarketFile(JournalDirectory);
                OutfittingFile = await _statusProvider.FindOutfittingFile(JournalDirectory);
                ShipyardFile = await _statusProvider.FindShipyardFile(JournalDirectory);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not set support files");
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
