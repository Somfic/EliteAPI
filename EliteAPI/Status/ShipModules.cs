using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Somfic.Logging;

namespace EliteAPI.Status
{
    public class ShipModules
    {
        public static ShipModules Process(string json) =>
            JsonConvert.DeserializeObject<ShipModules>(json, JsonConverter.Settings);

        public static ShipModules FromFile(FileInfo file, EliteDangerousAPI api)
        {
            if (!File.Exists(file.FullName))
            {
                api.Logger.Log(Severity.Error, "Could not find ModulesInfo.json.", new FileNotFoundException("ModulesInfo.json could not be found.", file.FullName));
                return new ShipModules();
            }

            try
            {
                return Process(File.ReadAllText(file.FullName));
            }
            catch (Exception e)
            {
                api.Logger.Log(Severity.Warning, "Could not update modules.");
                return new ShipModules();
            }
            

        }

        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; internal set; }
        [JsonProperty("event")] public string Event { get; internal set; }
        [JsonProperty("Modules")] public List<Module> Modules { get; internal set; }
    }
}