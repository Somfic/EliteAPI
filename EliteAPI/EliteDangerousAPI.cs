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

        public static string Version { get; private set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static DirectoryInfo StandardDirectory { get; private set; } = JournalDirectory.GetStandardDirectory();

        public EliteConfiguration Config { get; }

        public bool IsRunning { get; private set; }

        public bool IsReady { get; private set; }

        public Events.EventHandler Events { get; private set; } = new Events.EventHandler();

        public ShipStatus Status { get; private set; }

        public CargoStatus Cargo { get; internal set; }

        public MarketStatus Market { get; internal set; }

        public ModulesStatus Modules { get; internal set; }

        public OutfittingStatus Outfitting { get; internal set; }

        public ShipyardStatus Shipyard { get; internal set; }

        public LocationService Location { get; private set; }

        public DiscordService Discord { get; private set; }

        internal static IEnumerable<string> SupportFiles { get; } = new[] { "Status.json", "Cargo.json", "Market.json", "ModulesInfo.json", "Outfitting.json", "Shipyard.json" };

        private StatusExtensionService StatusExtension { get; set; }

        public void Start()
        {
            // Display information.
            Logger.Log($"EliteAPI v{Version}.");
            Logger.Debug("By CMDR Somfic and contributors.");

            // Check for a newer version.
            //VersionChecker.CheckVersion();

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

            // Mark as running.
            IsRunning = true;

            JournalReader.LogEntry += (sender, e) =>
            {
                // Don't raise while catching up if the user doesn't want to.
                if (!JournalReader.HasCatchedUp && !Config.CatchupOnPastEvents) { return; }

                LogProcessor.TriggerEvents(e, this);
            };

            JournalReader.StartWatching(Config.JournalDirectory, Config.CatchupOnPastEvents);

            // Mark that we're ready.
            IsReady = true;
            OnReady?.Invoke(this, EventArgs.Empty);

            // Start rich presence
            if(Config.UseDiscordRichPresence) { Discord.TurnOn(); }
        }

        public void Stop()
        {
            IsReady = false;

            // Stop rich presence.
            Discord.TurnOff();

            // Send stop signal to the async while loop.
            IsRunning = false;
            JournalReader.StopWatching();

            Logger.Debug("Stopping EliteAPI.");
        }

        public void Reset()
        {
            // Stop first if we're running.
            if (IsRunning)
            {
                Stop();
            }

            // Reset all the statuses.
            Status = StatusReader.Read(Config.JournalDirectory, "Status.json", new ShipStatus());
            Cargo = StatusReader.Read(Config.JournalDirectory, "Cargo.json", new CargoStatus());
            Market = StatusReader.Read(Config.JournalDirectory, "Market.json", new MarketStatus());
            Modules = StatusReader.Read(Config.JournalDirectory, "ModulesInfo.json", new ModulesStatus());
            Outfitting = StatusReader.Read(Config.JournalDirectory, "Outfitting.json", new OutfittingStatus());
            Shipyard = StatusReader.Read(Config.JournalDirectory, "Shipyard.json", new ShipyardStatus());

            // Reset all the services.
            Location = new LocationService(this);
            Discord = new DiscordService(this);
            StatusExtension = new StatusExtensionService(this);
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