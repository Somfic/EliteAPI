using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;

using Newtonsoft.Json;

using static EliteAPI.ServiceInterfaces;

namespace EliteAPI
{
    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        //Standard directory
        public static DirectoryInfo StandardDirectory { get => new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"); }

        //Version info.
        public FileVersionInfo Version { get { return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location); } }
        public long MajorVersion { get { return Version.FileMajorPart; } }
        public long MinorVersion { get { return Version.FileMinorPart; } }
        public string BuildVersion { get { return Version.FileVersion; } }

        //Public fields.
        public bool IsRunning { get; private set; }
        public DirectoryInfo JournalDirectory { get; private set; }
        public bool SkipCatchUp { get; private set; }
        public EliteAPI.Events.EventHandler Events { get; private set; }
        public EliteAPI.Logging.Logger Logger { get; private set; }
        public ShipStatus Status { get; private set; }
        public ShipCargo Cargo { get { return ShipCargo.FromFile(new FileInfo(JournalDirectory.FullName + "\\Cargo.json"), this); } }
        public ShipModules Modules { get { return ShipModules.FromFile(new FileInfo(JournalDirectory.FullName + "\\ModulesInfo.json"), this); } }
        public UserBindings Bindings
        {
            get
            {
                try
                {
                    string wantedFile = File.ReadAllText($@"C:\Users\{Environment.UserName}\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\StartPreset.start") + ".binds";
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(wantedFile);
                    return JsonConvert.DeserializeObject<UserBindings>(JsonConvert.SerializeXmlNode(xml));
                }
                catch { return new UserBindings(); }
            }
        }
        public CommanderStatus Commander { get; private set; }
        public LocationStatus Location { get; private set; }
        public StatusWatcher Watcher { get; private set; }

        //Services.
        public RichPresenceClient DiscordRichPresence { get; private set; }

        public EliteDangerousAPI(DirectoryInfo JournalDirectory, bool SkipCatchUp = true)
        {
            //Set the fields to the parameters.
            this.JournalDirectory = JournalDirectory;
            this.SkipCatchUp = SkipCatchUp;

            //Reset the API.
            Reset();
        }

        public void Reset()
        {
            //Reset services.
            this.Events = new Events.EventHandler();
            this.Logger = new Logging.Logger();
            this.Commander = new CommanderStatus(this);
            this.Location = new LocationStatus(this);
            this.DiscordRichPresence = new RichPresenceClient(this);
            this.Watcher = new StatusWatcher(this);
            this.Status = ShipStatus.FromFile(new FileInfo(JournalDirectory + "//Status.json"), this);
        }

        public void Start()
        {
            Logger.LogInfo("Starting EliteAPI.");

            //Check if said JournalDirectory has all the files.
            long errorCount = 0;
            bool errorIsCritical = false;
            if (JournalDirectory.GetFiles("Journal.*").Count() == 0) { Logger.LogWarning("Could not find Journal files."); errorCount++; errorIsCritical = true; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "Status.json") == 0) { Logger.LogWarning("Could not find Status.json."); errorCount++; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "Cargo.json") == 0) { Logger.LogWarning("Could not find Cargo.json."); errorCount++; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "ModulesInfo.json") == 0) { Logger.LogWarning("Could not find ModulesInfo.json."); errorCount++; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "Shipyard.json") == 0) { Logger.LogWarning("Could not find Shipyard.json."); errorCount++; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "Outfitting.json") == 0) { Logger.LogWarning("Could not find Outfitting.json."); errorCount++; }
            if (JournalDirectory.GetFiles().Count(x => x.Name == "Market.json") == 0) { Logger.LogWarning("Could not find Market.json."); errorCount++; }

            if (errorCount == 0)
            {
                Logger.LogInfo("All files were found.");
                Events.InvokeAllEvent(new StatusEvent("OnReady", ""));
            }

            if (errorIsCritical)
            {
                Logger.LogError("Could not start EliteAPI.");
                Events.InvokeAllEvent(new StatusEvent("OnError", $"Could not find game files at '{JournalDirectory.FullName}'."));
                return;
            }

            //Mark the API as running.
            IsRunning = true;

            //Go async.
            Task.Run(() =>
            {
                //We'll process the journal one time first, to catch up.
                //Select the last edited Journal file.
                FileInfo journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();

                //Process the journal file.
                ProcessJournal(journalFile, SkipCatchUp);

                Logger.LogInfo("EliteAPI is ready.");

                //Run for as long as we're running.
                while (IsRunning)
                {
                    //Select the last edited Journal file.
                    journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).First();

                    //Process the journal file.
                    ProcessJournal(journalFile, false);

                    //Wait half a second to avoid overusing the CPU.
                    Thread.Sleep(500);
                }
            });
        }

        private List<string> processedLogs = new List<string>();

        private void ProcessJournal(FileInfo logFile, bool doNotTrigger = true)
        {
            //Create a stream from the log file.
            FileStream fileStream = logFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //If this string hasn't been processed yet, process it and mark it as processed.
                string json = streamReader.ReadLine();
                dynamic thisEvent = JsonConvert.DeserializeObject<dynamic>(json);
                if (!processedLogs.Contains(json))
                {
                    if (!doNotTrigger) { Process(json); } //Only process it if it's marked true.
                    processedLogs.Add(json);
                }
            }
        }

        private void Process(string json)
        {
            //Turn the json into an object to find out which event it is.
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            string eventName = obj.@event;

            //Invoke the matching event.
            try { Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == $"{eventName}Info").First().GetMethod("Process").Invoke(null, new object[] { json, this }); }
            catch(Exception ex) { Logger.LogError($"Could not invoke event {eventName}, it might not have been added yet. {Environment.NewLine}Error: {ex.Message}"); }

            //Invoke the AllEvent.
            Events.InvokeAllEvent(obj);
        }

        public void Stop()
        {
            //Mark the API as not running.
            IsRunning = false;

            Logger.LogInfo("Stopping EliteAPI.");
        }
    }
}
