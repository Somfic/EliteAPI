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
                    ClearSavedGameEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.ClearSavedGame>(json));
                    break;

                case "NewCommander":
                    NewCommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.NewCommander>(json));
                    break;

                case "LoadGame":
                    LoadGameEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.LoadGame>(json));
                    break;

                case "Commander":
                    CommanderEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Commander>(json));
                    break;

                case "Rank":
                    RankEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Rank>(json));
                    break;

                case "Progress":
                    ProgressEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Progress>(json));
                    break;

                case "Reputation":
                    ReputationEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Reputation>(json));
                    break;

                case "Loadout":
                    LoadoutEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Loadout>(json));
                    break;

                case "Location":
                    LocationEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Location>(json));
                    break;

                case "Statistics":
                    StatisticsEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Statistics>(json));
                    break;

                case "Docked":
                    DockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Docked>(json));
                    break;

                case "Undocked":
                    UndockedEvent?.Invoke(this, JsonConvert.DeserializeObject<Events.Undocked>(json));
                    break;
            }
        }

        public event EventHandler<Events.ClearSavedGame> ClearSavedGameEvent;
        public event EventHandler<Events.NewCommander> NewCommanderEvent;
        public event EventHandler<Events.LoadGame> LoadGameEvent;
        public event EventHandler<Events.Commander> CommanderEvent;
        public event EventHandler<Events.Rank> RankEvent;
        public event EventHandler<Events.Progress> ProgressEvent;
        public event EventHandler<Events.Reputation> ReputationEvent;
        public event EventHandler<Events.Loadout> LoadoutEvent;
        public event EventHandler<Events.Location> LocationEvent;
        public event EventHandler<Events.Statistics> StatisticsEvent;
        public event EventHandler<Events.Docked> DockedEvent;
        public event EventHandler<Events.Undocked> UndockedEvent;

    }
}
