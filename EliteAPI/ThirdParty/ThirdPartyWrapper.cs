using IniParser;
using IniParser.Model;
using Somfic.Logging;
using System.IO;
using Somfic.Logging.Handlers;

namespace EliteAPI.ThirdParty
{
    public static class ThirdPartyWrapper
    {
        private static EliteDangerousAPI api;
        private static bool useRichPresence = false;

        public static void Init()
        {
            api = new EliteDangerousAPI();
        }

        public static void AddHandler(LoggerHandler handler)
        {
            Logger.AddHandler(handler);
        }

        public static void SetupFromIni(string path)
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = new IniData();

            // Get data

            if (File.Exists(path))
            {
                data = parser.ReadFile(path);
            }
            else
            {
                Logger.Log("Creating new ini file.",
                    new FileNotFoundException("Could not find custom ini configuration.", path));

                data["ELITEAPI"]["path"] = EliteDangerousAPI.StandardDirectory.ToString();
                data["LOGGING"]["path"] = Directory.GetCurrentDirectory();
                data["DISCORD"]["richPresence"] = "on";

                parser.WriteFile(path, data);
            }

            // Check data

            if (!Directory.Exists(data["LOGGING"]["path"]))
            {
                Directory.CreateDirectory(data["LOGGING"]["path"]);
            }
            LogFileHandler logFileHandler = new LogFileHandler(data["LOGGING"]["path"], "EliteAPI");
            AddHandler(logFileHandler);
            Logger.Log(Severity.Info,$"Using '{logFileHandler.LogFile.FullName}' for logging.");

            if (!Directory.Exists(data["ELITEAPI"]["path"]))
            {
                if (!Directory.Exists(path))
                {
                    Logger.Log(Severity.Warning, $"Custom '{path}' Journal path is invalid, resetting to default Journal path.");
                    data["ELITEAPI"]["path"] = EliteDangerousAPI.StandardDirectory.FullName;
                    parser.WriteFile(path, data);
                }
                else
                {
                    if (data["ELITEAPI"]["path"] != EliteDangerousAPI.StandardDirectory.FullName)
                    {
                        Logger.Log(Severity.Info, $"Using custom Journal path '{data["ELITEAPI"]["path"]}'.");
                        api.Config.JournalDirectory = new DirectoryInfo(data["ELITEAPI"]["path"]);
                    }
                }
            }

            switch (data["DISCORD"]["richPresence"].ToLower())
            {
                case "on":
                case "yes": 
                case "true":
                    useRichPresence = true;
                    break;
            }
        }

        public static void Start()
        {
            api.Start();

            //todo: Set status events
            //todo: Set event parameters
            //todo: Trigger event command
            //todo: Process custom commands
        }
    }
}
