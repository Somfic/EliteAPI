using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        private DirectoryInfo _playerJournalDirectory;
        private FileSystemWatcher fileSystemWatcher;

        /// <summary>
        /// Whether the class is processing logs.
        /// </summary>
        public bool isRunning { get; private set; } 

        private List<string> processedLogs;

        /// <summary>
        /// Creates a new API class.
        /// </summary>
        /// <param name="playerJournalDirectory">The folder where the Player Journal is located in.</param>
        public EliteDangerousAPI(DirectoryInfo playerJournalDirectory)
        {
            _playerJournalDirectory = playerJournalDirectory;

            Reset();
        }

        /// <summary>
        /// Resets everything.
        /// </summary>
        public void Reset()
        {
            processedLogs = new List<string>();
        }

        /// <summary>
        /// Starts the processing of the log file, async.
        /// </summary>
        public void RunAsync()
        {
            isRunning = true;
            Task.Run(() => { InitProcessLog(); });
        }

        /// <summary>
        /// Stops the processing of the log file.
        /// </summary>
        public void Stop()
        {
            isRunning = false;
            fileSystemWatcher.Changed -= FileSystemWatcher_Changed;
        }

        /// <summary>
        /// Initializes the processing of the log.
        /// </summary>
        private void InitProcessLog()
        {
            FileInfo logFile = _playerJournalDirectory
                .GetFiles("#.log") //Get all files that end with .log.
                .OrderByDescending(x => x.LastWriteTime) //Order them by last written.
                .First(); //Get the first one of the ordered list.

            fileSystemWatcher = new FileSystemWatcher(logFile.FullName)
            {
                Filter = logFile.Name,
                NotifyFilter = NotifyFilters.LastWrite                
            };

            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            ProcessLog(new FileInfo(e.FullPath));
        }

        /// <summary>
        /// Process the log file once.
        /// </summary>
        /// <param name="logFile">The log file to process.</param>
        private void ProcessLog(FileInfo logFile)
        {
            //Create a stream from the log file.
            FileStream fileStream = logFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //If this string hasn't been processed yet, process it and mark it as processed.
                string thisLog = streamReader.ReadLine();
                if (!processedLogs.Contains(thisLog)) {
                    Process(thisLog);
                    processedLogs.Add(thisLog);
                }
            }
        }

        private void Process(string json)
        {
            dynamic dynamicLog = JsonConvert.DeserializeObject(json);
            string eventName = dynamicLog.@event;

            switch (eventName)
            {
                case "ClearSavedGame":
                    ClearSavedGameEvent?.Invoke(this, JsonConvert.DeserializeObject<ClearSavedGame>(json));
                    break;

                case "NewCommander":
                    NewCommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<NewCommander>(json));
                    break;

                case "LoadGame":
                    LoadGameEvent?.Invoke(this, JsonConvert.DeserializeObject<LoadGame>(json));
                    break;

                case "Commander":
                    CommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<Commander>(json));
                    break;

                case "Rank":
                    RankEvent?.Invoke(this, JsonConvert.DeserializeObject<Rank>(json));
                    break;

                case "Progress":
                    ProgressEvent?.Invoke(this, JsonConvert.DeserializeObject<Progress>(json));
                    break;

                case "Reputation":
                    ReputationEvent?.Invoke(this, JsonConvert.DeserializeObject<Reputation>(json));
                    break;

                case "Loadout":
                    LoadoutEvent?.Invoke(this, JsonConvert.DeserializeObject<Loadout>(json));
                    break;

                case "Location":
                    LocationEvent?.Invoke(this, JsonConvert.DeserializeObject<Location>(json));
                    break;

                case "Statistics":
                    StatisticsEvent?.Invoke(this, JsonConvert.DeserializeObject<Statistics>(json));
                    break;

                case "Docked":
                    DockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Docked>(json));
                    break;

                case "Undocked":
                    UndockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Undocked>(json));
                    break;

                case "ShipTargeted":
                    ShipTargetedEvent?.Invoke(this, JsonConvert.DeserializeObject<ShipTargeted>(json));
                    break;

                case "DockingDenied":
                    DockingDeniedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingDenied>(json));
                    break;

                case "DockingGranted":
                    DockingGrantedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingGranted>(json));
                    break;

                case "DockingRequested":
                    DockingRequestedEvent?.Invoke(this, JsonConvert.DeserializeObject<DockingRequested>(json));
                    break;

                case "StartJump":
                    StartJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<StartJump>(json));
                    break;

                case "SupercruiseEntry":
                    SupercruiseEntryEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseEntry>(json));
                    break;

                case "SupercruiseExit":
                    SupercruiseExitEvent?.Invoke(this, JsonConvert.DeserializeObject<SupercruiseExit>(json));
                    break;

                case "FSDJump":
                    FSDJumpEvent?.Invoke(this, JsonConvert.DeserializeObject<FSDJump>(json));
                    break;
            }
        }

        public event EventHandler<ClearSavedGame> ClearSavedGameEvent;
        public event EventHandler<NewCommander> NewCommanderEvent;
        public event EventHandler<LoadGame> LoadGameEvent;
        public event EventHandler<Commander> CommanderEvent;
        public event EventHandler<Rank> RankEvent;
        public event EventHandler<Progress> ProgressEvent;
        public event EventHandler<Reputation> ReputationEvent;
        public event EventHandler<Loadout> LoadoutEvent;
        public event EventHandler<Location> LocationEvent;
        public event EventHandler<Statistics> StatisticsEvent;
        public event EventHandler<Docked> DockedEvent;
        public event EventHandler<Undocked> UndockedEvent;
        public event EventHandler<ShipTargeted> ShipTargetedEvent;
        public event EventHandler<DockingDenied> DockingDeniedEvent;
        public event EventHandler<DockingGranted> DockingGrantedEvent;
        public event EventHandler<DockingRequested> DockingRequestedEvent;
        public event EventHandler<StartJump> StartJumpEvent;
        public event EventHandler<SupercruiseEntry> SupercruiseEntryEvent;
        public event EventHandler<SupercruiseExit> SupercruiseExitEvent;
        public event EventHandler<FSDJump> FSDJumpEvent;
    }
}
