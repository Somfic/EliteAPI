using EliteAPI.Status;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Market;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Ship;
using EliteAPI.Status.Shipyard;
using EliteAPI.Utilities;
using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Service.Discord;
using EliteAPI.Service.Location;
using EliteAPI.Service.StatusExtension;
using Newtonsoft.Json;
using EventHandler = System.EventHandler;

namespace EliteAPI
{
    public partial class EliteDangerousAPI
    {
        public EliteDangerousAPI(EliteConfiguration configuration = null)
        {
            if (configuration == null) { configuration = new EliteConfiguration(); }

            Config = configuration;
            Reset();
        }

        public static string Version { get; private set; }

        public static DirectoryInfo StandardDirectory { get; private set; }

        public EliteConfiguration Config { get; }

        public bool IsRunning { get; private set; }
        private bool _shouldBeRunning;

        public bool IsReady { get; private set; }

        public Events.EventHandler Events { get; private set; }

        public ShipStatus Status { get; private set; }

        public CargoStatus Cargo { get; internal set; }

        public MarketStatus Market { get; internal set; }

        public ModulesStatus Modules { get; internal set; }

        public OutfittingStatus Outfitting { get; internal set; }

        public ShipyardStatus Shipyard { get; internal set; }

        public LocationService Location { get; private set; }

        public DiscordService Discord { get; private set; }

        private StatusExtensionService StatusExtension { get; set; }


        public void Start()
        {
            // Display information.
            Logger.Log($"EliteAPI v{Version}.");
            Logger.Debug("By CMDR Somfic and contributors.");

            // Check for a newer version.
            VersionChecker.CheckVersion();

            bool canContinue = JournalDirectory.CheckDirectory(Config.JournalDirectory);

            if (!canContinue && Config.JournalDirectory != StandardDirectory)
            {
                // Check again with the standard directory.
                canContinue = JournalDirectory.CheckDirectory(StandardDirectory);
                if (canContinue)
                {
                    Config.JournalDirectory = StandardDirectory;
                    Logger.Log($"Changed Journal directory to {StandardDirectory.FullName}.");
                }
            }

            if (!canContinue)
            {
                // If the check was not successful, do not continue.
                Logger.Special("EliteAPI cannot continue, please change the Journal directory and try again.");
                return;
            }

            // Get the last edited Journal file.
            JournalFile = Config.JournalDirectory.GetFiles("Journal.*.log").OrderByDescending(x => x.LastWriteTime).First();
            Logger.Debug($"{JournalFile.Name} selected.");

            // Mark as running.
            IsRunning = true;
            _shouldBeRunning = true;

            // Catch up with events from this session.
            Logger.Debug("Catching up on past events.");
            ProcessFiles(Config.RaiseOnCatchup);
            Logger.Debug("Catched up on past events.");

            // For as long as we're running, process the files and raise events.
            Task.Run(() =>
            {
                while (_shouldBeRunning)
                {
                    ProcessFiles(true);
                }

                IsRunning = false;
                Logger.Log("EliteAPI was stopped.");
                OnQuit?.Invoke(this, EventArgs.Empty);
            });

            // Mark that we're ready.
            IsReady = true;
            OnReady?.Invoke(this, EventArgs.Empty);

            // Start rich presence
            if(Config.UseDiscordRichPresence)
            {
                Discord.TurnOn();
            }
        }

        public void Stop()
        {
            IsReady = false;

            // Stop rich presence.
            Discord.TurnOff();

            // Send stop signal to the async while loop.
            _shouldBeRunning = false;
            Logger.Debug("Stopping EliteAPI.");

            // Wait until the async while loop has completed.
            while (IsRunning) { }
        }

        public void Reset()
        {
            // Stop first if we're running.
            if (IsRunning)
            {
                Stop();
            }

            // Reset the properties.
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            StandardDirectory = JournalDirectory.GetStandardDirectory();
            
            // Reset the events.
            Events = new Events.EventHandler();

            // Reset all the statuses.
            Status = StatusReader.Read<ShipStatus>(Config.JournalDirectory, "Status.json");
            Cargo = StatusReader.Read<CargoStatus>(Config.JournalDirectory, "Cargo.json");
            Market = StatusReader.Read<MarketStatus>(Config.JournalDirectory, "Market.json");
            Modules = StatusReader.Read<ModulesStatus>(Config.JournalDirectory, "ModulesInfo.json");
            Outfitting = StatusReader.Read<OutfittingStatus>(Config.JournalDirectory, "Outfitting.json");
            Shipyard = StatusReader.Read<ShipyardStatus>(Config.JournalDirectory, "Shipyard.json");

            // Reset all the services.
            Location = new LocationService(this);
            Discord = new DiscordService(this);
            StatusExtension = new StatusExtensionService(this);

            // Reset background stuff.
            processedLogs = new List<string>();
        }

        /// <summary>
        /// Gets triggered when EliteAPI has successfully loaded up.
        /// </summary>
        public event EventHandler OnReady;

        /// <summary>
        /// Gets triggered when EliteAPI is closing.
        /// </summary>
        public event EventHandler OnQuit;

        /// <summary>
        /// Gets triggered when EliteAPI has been reset.
        /// </summary>
        public event EventHandler OnReset;

        /// <summary>
        /// Gets triggered when EliteAPI could not successfully load up.
        /// </summary>
        public event EventHandler<Tuple<string, Exception>> OnError;
    }
}