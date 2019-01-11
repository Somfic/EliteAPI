using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Events;
using EliteAPI.Status;
using EliteAPI.VoiceAttack.EliteVA;
using Newtonsoft.Json;

namespace EliteAPI
{
    public class EliteDangerousAPI
    {
        //Public fields.
        public bool IsRunning { get; private set; }
        public DirectoryInfo JournalDirectory { get; set; }
        public bool SkipCatchUp { get; set; }

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
            
        }

        public void Start()
        {
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
                string thisEvent = streamReader.ReadLine();
                if (!processedLogs.Contains(thisEvent))
                {
                    if (!doNotTrigger) { Process(thisEvent); } //Only process it if it's marked true.
                    processedLogs.Add(thisEvent);
                }
            }
        }

        private void Process(string json)
        {
            //Turn the json into an object to find out which event it is.
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            string eventName = obj.@event;

            Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name == eventName).First().GetMethod("FromJson").Invoke(this, new object[] { json });
        }

        public void Stop()
        {
            //Mark the API as not running.
            IsRunning = false;
        }
    }
}
