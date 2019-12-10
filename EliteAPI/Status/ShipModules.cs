namespace EliteAPI.Status
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class ShipModules
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Modules")]
        public List<Module> Modules { get; internal set; }
    }
    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("Item")]
        public string Item { get; internal set; }
        [JsonProperty("Power")]
        public double Power { get; internal set; }
        [JsonProperty("Priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; internal set; }
    }
    public partial class ShipModules
    {
        public static ShipModules Process(string json) => JsonConvert.DeserializeObject<ShipModules>(json, EliteAPI.Status.ShipModulesConverter.Settings);
        public static ShipModules FromFile(FileInfo file, EliteDangerousAPI api)
        {
            if (File.Exists(file.FullName)) { api.Logger.Error("Could not find ModulesInfo.json.", new Exception($"Could not find {file}.")); return new ShipModules(); }
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
            api.Logger.Warning("Could not update modules.");
            return new ShipModules();
        }
    }
    
    internal static class ShipModulesConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
