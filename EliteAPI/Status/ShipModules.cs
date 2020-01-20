using Somfic.Logging;

namespace EliteAPI.Status
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public partial class ShipModules
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Modules")]
        public List<Module> Modules { get; internal set; }
    }

    public partial class ShipModules
    {
        public static ShipModules Process(string json) => JsonConvert.DeserializeObject<ShipModules>(json, EliteAPI.Status.ShipModulesConverter.Settings);
        public static ShipModules FromFile(FileInfo file, EliteDangerousAPI api)
        {
            if (File.Exists(file.FullName)) { api.Logger.Log(Severity.Error, "Could not find ModulesInfo.json.", new FileNotFoundException("ModulesInfo.json could not be found.", file.FullName)); return new ShipModules(); }
            //Create a stream from the log file.
            FileStream fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);
            //Go through the stream.
            while (!streamReader.EndOfStream)
            {
                //Process this string.
                return Process(streamReader.ReadLine());
            }
            api.Logger.Log(Severity.Warning, "Could not update modules.");
            return new ShipModules();
        }
    }
}
