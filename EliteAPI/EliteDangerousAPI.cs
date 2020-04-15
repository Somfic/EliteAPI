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

        public CargoStatus Cargo { get; private set; }

        public MarketStatus Market { get; private set; }

        public ModulesStatus Modules { get; private set; }

        public OutfittingStatus Outfitting { get; private set; }

        public ShipyardStatus Shipyard { get; private set; }

        public LocationService Location { get; private set; }


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
        }

        public void Stop()
        {
            IsReady = false;

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
            Status = new ShipStatus();
            Cargo = new CargoStatus();
            Market = new MarketStatus();
            Modules = new ModulesStatus();
            Outfitting = new OutfittingStatus();
            Shipyard = new ShipyardStatus();

            // Reset all the services.
            Location = new LocationService(this);

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