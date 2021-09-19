using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using EliteAPI.Abstractions;
using EliteAPI.Configuration.Abstractions;
using EliteAPI.Event.Processor.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Journal.Processor.Abstractions;
using EliteAPI.Journal.Provider.Abstractions;
using EliteAPI.Options.Bindings.Models;
using EliteAPI.Options.Directory.Abstractions;
using EliteAPI.Options.Processor.Abstractions;
using EliteAPI.Options.Provider.Abstractions;
using EliteAPI.Status.Backpack.Abstractions;
using EliteAPI.Status.Cargo.Abstractions;
using EliteAPI.Status.Commander.Abstractions;
using EliteAPI.Status.Market.Abstractions;
using EliteAPI.Status.Modules.Abstractions;
using EliteAPI.Status.NavRoute.Abstractions;
using EliteAPI.Status.Outfitting.Abstractions;
using EliteAPI.Status.Processor.Abstractions;
using EliteAPI.Status.Provider.Abstractions;
using EliteAPI.Status.Ship.Abstractions;
using EliteAPI.Status.Shipyard.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using EventHandler = EliteAPI.Event.Handler.EventHandler;

namespace EliteAPI
{
    [Obsolete("Use EliteDangerousApi instead", true)]
    public class EliteDangerousAPI { }

    /// <inheritdoc />
    public class EliteDangerousApi : IEliteDangerousApi
    {
        private readonly IEliteDangerousApiConfiguration _codeConfig;
        private readonly IConfiguration _config;

        private readonly IEnumerable<IEventProcessor> _eventProcessors;

        private readonly IEventProvider _eventProvider;

        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        private readonly IJournalProcessor _journalProcessor;
        private readonly IJournalProvider _journalProvider;

        private readonly ILogger<EliteDangerousApi> _log;
        private readonly IStatusProcessor _statusProcessor;
        private readonly IStatusProvider _statusProvider;

        private readonly IOptionsDirectoryProvider _optionsDirectoryProvider;
        private readonly IOptionsProvider _optionsProvider;
        private readonly IOptionsProcessor _optionsProcessor;

        /// <summary>
        /// Creates a new EliteDangerousAPI class
        /// </summary>
        /// <param name="services"> ServiceProvider </param>
        public EliteDangerousApi(IServiceProvider services)
        {
            try
            {
                _log = services.GetRequiredService<ILogger<EliteDangerousApi>>();

                Events = services.GetRequiredService<EventHandler>();
                Ship = services.GetRequiredService<IShip>();
                Commander = services.GetRequiredService<ICommander>();
                NavRoute = services.GetRequiredService<INavRoute>();
                Cargo = services.GetRequiredService<ICargo>();
                Market = services.GetRequiredService<IMarket>();
                Modules = services.GetRequiredService<IModules>();
                Backpack = services.GetRequiredService<IBackpack>();
                Shipyard = services.GetRequiredService<IShipyard>();
                Outfitting = services.GetRequiredService<IOutfitting>();
                Bindings = services.GetRequiredService<IBindings>();

                Version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Split('+')[0];

                _config = services.GetRequiredService<IConfiguration>();
                _codeConfig = services.GetRequiredService<IEliteDangerousApiConfiguration>();

                _eventProvider = services.GetRequiredService<IEventProvider>();
                _eventProcessors = services.GetRequiredService<IEnumerable<IEventProcessor>>();

                _journalDirectoryProvider = services.GetRequiredService<IJournalDirectoryProvider>();

                _journalProvider = services.GetRequiredService<IJournalProvider>();
                _journalProcessor = services.GetRequiredService<IJournalProcessor>();

                _statusProvider = services.GetRequiredService<IStatusProvider>();
                _statusProcessor = services.GetRequiredService<IStatusProcessor>();

                _optionsDirectoryProvider = services.GetRequiredService<IOptionsDirectoryProvider>();
                _optionsProvider = services.GetRequiredService<IOptionsProvider>();
                _optionsProcessor = services.GetRequiredService<IOptionsProcessor>();
            }
            catch (Exception ex) { PreInitializationException = ex; }
        }

        private DirectoryInfo JournalDirectory { get; set; }
        private DirectoryInfo OptionsDirectory { get; set; }
        private FileInfo JournalFile { get; set; }
        private FileInfo StatusFile { get; set; }
        private FileInfo CargoFile { get; set; }
        private FileInfo MarketFile { get; set; }
        private FileInfo BackpackFile { get; set; }
        private FileInfo OutfittingFile { get; set; }
        private FileInfo ShipyardFile { get; set; }
        private FileInfo NavRouteFile { get; set; }
        private FileInfo ModulesInfoFile { get; set; }
        private FileInfo BindingsFile { get; set; }
        private IList<string> DisabledSupportFiles { get; set; }
        private Exception PreInitializationException { get; }
        private Exception InitializationException { get; set; }

        /// <inheritdoc />
        public bool IsInitialized { get; private set; }

        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        /// <inheritdoc />
        public bool HasCatchedUp { get; private set; }

        /// <inheritdoc />
        public string Version { get; }

        /// <inheritdoc />
        public EventHandler Events { get; }

        /// <inheritdoc />
        public IShip Ship { get; }
        
        /// <inheritdoc />
        public ICommander Commander { get; }

        /// <inheritdoc />
        public IBackpack Backpack { get; }
        
        /// <inheritdoc />
        public IShipyard Shipyard { get; }

        /// <inheritdoc />
        public INavRoute NavRoute { get; }

        /// <inheritdoc />
        public ICargo Cargo { get; }

        /// <inheritdoc />
        public IMarket Market { get; }

        /// <inheritdoc />
        public IModules Modules { get; }

        /// <inheritdoc />
        public IOutfitting Outfitting { get; }
        
        /// <inheritdoc />
        public IBindings Bindings { get; }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            if (PreInitializationException != null)
            {
                _log?.LogCritical(PreInitializationException, "EliteAPI could not load required services");
                throw PreInitializationException;
            }

            if (IsInitialized) return;

            try
            {
                _log.LogInformation("Initializing EliteAPI v{version}", Version);

                DisabledSupportFiles = new List<string>();

                await CheckComputerOperatingSystem();
                await InitializeEventHandlers();
                await SetJournalDirectory();
                await SetOptionsDirectory();
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
            if (!IsInitialized) await InitializeAsync();

            if (InitializationException != null)
            {
                _log.LogCritical(InitializationException, "EliteAPI could not be started");
                OnError?.Invoke(this, InitializationException);
                await StopAsync();
                return;
            }

            IsRunning = true;

            var delay = TimeSpan.FromMilliseconds(500);
            if (_codeConfig.TickFrequency != TimeSpan.Zero) delay = _codeConfig.TickFrequency;

            var task = Task.Run(async () =>
            {
                _log.LogInformation("EliteAPI has started");
                OnStart?.Invoke(this, EventArgs.Empty);

                while (IsRunning)
                {
                    await DoTick();
                    await Task.Delay(delay);
                }

                OnStop?.Invoke(this, EventArgs.Empty);
            });
        }


        /// <inheritdoc />
        public Task StopAsync()
        {
            _journalProcessor.NewJournalEntry -= _journalProcessor_NewJournalEntry;

            IsRunning = false;
            IsInitialized = false;
            HasCatchedUp = false;

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public event System.EventHandler OnCatchedUp;

        /// <inheritdoc />
        public event System.EventHandler OnStart;

        /// <inheritdoc />
        public event System.EventHandler OnStop;

        /// <inheritdoc />
        public event EventHandler<Exception> OnError;

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
                await _statusProcessor.ProcessBackpackFile(BackpackFile);
                await _statusProcessor.ProcessNavRouteFile(NavRouteFile);
                await _statusProcessor.ProcessModulesFile(ModulesInfoFile);
                
                await _optionsProcessor.ProcessBindingsFile(BindingsFile);

                await SetJournalFile();
                await _journalProcessor.ProcessJournalFile(JournalFile, !HasCatchedUp);

                if (!HasCatchedUp)
                {
                    _log.LogInformation("EliteAPI has caught up to current session");
                    OnCatchedUp?.Invoke(this, EventArgs.Empty);
                    HasCatchedUp = true;
                }
            }
            catch (Exception ex) { _log.LogWarning(ex, "Could not do tick"); }
        }

        private async Task InitializeEventHandlers()
        {
            _log.LogTrace("Initializing event handlers");
            foreach (var eventProcessor in _eventProcessors)
                try { await eventProcessor.RegisterHandlers(); }
                catch (Exception ex)
                {
                    _log.LogWarning(ex, "Could not initialize event handler {name}", eventProcessor.GetType().FullName);
                    throw;
                }
        }

        private async void _journalProcessor_NewJournalEntry(object sender, JournalEntry e)
        {
            try
            {
                var eventBase = await _eventProvider.ProcessJsonEvent(e.Json);
                foreach (var eventProcessor in _eventProcessors) await eventProcessor.InvokeHandler(eventBase, e.IsWhileCatchingUp);
            }
            catch (Exception ex) { _log.LogWarning(ex, "Could not execute event"); }
        }

        private async Task SetJournalDirectory()
        {
            try
            {
                var newJournalDirectory = await _journalDirectoryProvider.FindJournalDirectory();
                if (newJournalDirectory == null || JournalDirectory?.FullName == newJournalDirectory.FullName) return;

                _log.LogInformation("Setting journal directory to {filePath}", newJournalDirectory.FullName);
                JournalDirectory = newJournalDirectory;
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find journal directory");
                throw;
            }
        }
        
        private async Task SetOptionsDirectory()
        {
            try
            {
                var newOptionsDirectory = await _optionsDirectoryProvider.FindOptionsDirectory();
                if (newOptionsDirectory == null || OptionsDirectory?.FullName == newOptionsDirectory.FullName) return;

                _log.LogInformation("Setting options directory to {filePath}", newOptionsDirectory.FullName);
                OptionsDirectory = newOptionsDirectory;
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find options directory");
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

                if (!newJournalFile.Name.Contains("Journal"))
                    _log.LogWarning(new InvalidJournalFileException($"The selected journal file '{newJournalFile.Name}' does not match standard naming conventions"), "Invalid journal file detected, errors may occur");

                JournalFile = newJournalFile;
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find the active journal file");
                throw;
            }
        }

        private string lastPresetErrorname = "";
        private async Task SetSupportFiles()
        {
            try
            {
                if (!DisabledSupportFiles.Contains("Status")) StatusFile = await _statusProvider.FindStatusFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("Cargo")) CargoFile = await _statusProvider.FindCargoFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("Market")) MarketFile = await _statusProvider.FindMarketFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("Outfitting")) OutfittingFile = await _statusProvider.FindOutfittingFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("Shipyard")) ShipyardFile = await _statusProvider.FindShipyardFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("NavRoute")) NavRouteFile = await _statusProvider.FindNavRouteFile(JournalDirectory);
                
                if (!DisabledSupportFiles.Contains("Backpack")) BackpackFile = await _statusProvider.FindBackpackFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("ModulesInfo")) ModulesInfoFile = await _statusProvider.FindModulesFile(JournalDirectory);

                if (!DisabledSupportFiles.Contains("Bindings"))
                {
                    BindingsFile = await _optionsProvider.FindActiveBindingsFile(OptionsDirectory);
                    lastPresetErrorname = "";
                }
            }
            catch (StatusFileNotFoundException ex)
            {
                _log.LogWarning(ex, "Status.json file support has been disabled");
                DisabledSupportFiles.Add("Status");
            }
            catch (CargoFileNotFoundException ex)
            {
                _log.LogDebug(ex, "Cargo.json file support has been disabled");
                DisabledSupportFiles.Add("Cargo");
            }
            catch (MarketFileNotFoundException ex)
            {
                _log.LogDebug(ex, "Market.json file support has been disabled");
                DisabledSupportFiles.Add("Market");
            }
            catch (OutfittingFileNotFoundException ex)
            {
                _log.LogDebug(ex, "Outfitting.json file support has been disabled");
                DisabledSupportFiles.Add("Outfitting");
            }
            catch (ShipyardFileNotFoundException ex)
            {
                _log.LogDebug(ex, "Shipyard.json file support has been disabled");
                DisabledSupportFiles.Add("Shipyard");
            }
            catch (NavRouteFileNotFoundException ex)
            {
                _log.LogDebug(ex, "NavRoute.json file support has been disabled");
                DisabledSupportFiles.Add("NavRoute");
            }
            catch (ModulesInfoFileNotFoundException ex)
            {
                _log.LogDebug(ex, "ModulesInfo.json file support has been disabled");
                DisabledSupportFiles.Add("ModulesInfo");
            }
            catch (BackpackFileNotFoundException ex)
            {
                _log.LogDebug(ex, "Backpack.json file support has been disabled");
                DisabledSupportFiles.Add("Backpack");
            }
            catch (ActiveBindingsNotFoundException ex)
            {
                _log.LogWarning(ex, "Keybindings support has been disabled");
                DisabledSupportFiles.Add("Bindings");
            }
            catch (BindingsNotFoundException ex)
            {
                var preset = ex.Data["Active bindings"]?.ToString();

                if (preset == null)
                {
                    DisabledSupportFiles.Add("Bindings");
                }
                
                if (lastPresetErrorname != preset)
                {
                    lastPresetErrorname = preset;

                    _log.LogWarning(ex,
                        !string.IsNullOrWhiteSpace(Bindings.Active.PresetName)
                            ? "Cannot switch to bindings preset {Bindings}"
                            : "Cannot use bindings preset {Bindings}", preset);
                }
            }

            catch (Exception ex) { _log.LogWarning(ex, "Could not set support files"); }
        }
        
        private Task CheckComputerOperatingSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) _log.LogWarning("You are not running on a Windows machine, some features may not work properly");

            return Task.CompletedTask;
        }
    }
}