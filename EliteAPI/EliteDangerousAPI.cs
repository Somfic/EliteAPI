using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

using DiscordRPC;

using EliteAPI.Bindings;
using EliteAPI.Status;
using EliteAPI.Discord;

using Newtonsoft.Json;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        //Public fields.
        public bool IsRunning { get; private set; }
        public DirectoryInfo JournalDirectory { get; set; }
        public bool SkipCatchUp { get; set; }
        public EliteAPI.Events.EventHandler Events { get; set; }
        public EliteAPI.Logging.Logger Logger { get; set; }

        //Status fields.
        public ShipStatus Status { get { return ShipStatus.FromFile(new FileInfo(JournalDirectory.FullName + "\\Status.json"), this); } }
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
        public CommanderStatus Commander;
        public LocationStatus Location;

        //Servies.
        public RichPresenceClient DiscordRichPresence;

        public EliteDangerousAPI(DirectoryInfo JournalDirectory, bool SkipCatchUp = true)
        {
            //Set the fields to the parameters.
            this.JournalDirectory = JournalDirectory;
            this.SkipCatchUp = SkipCatchUp;

            //Init services.
            this.Events = new Events.EventHandler();
            this.Logger = new Logging.Logger();
            this.Commander = new CommanderStatus(this);
            this.Location = new LocationStatus(this);
            this.DiscordRichPresence = new RichPresenceClient(this);

            //Reset the API.
            Reset();
        }

        public void Reset()
        {
            Events = new Events.EventHandler();
        }

        public void Start()
        {
            Logger.LogInfo("Starting EliteAPI.");

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
            catch(Exception ex) { Logger.LogError($"Could not invoke event {eventName}. {Environment.NewLine}Error: {ex.Message}"); }

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
