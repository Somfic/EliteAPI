namespace EliteAPI.Status
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipCargo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Inventory")]
        public List<Item> Inventory { get; internal set; }
    }

    public partial class Item
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Stolen")]
        public long Stolen { get; internal set; }
    }

    public partial class ShipCargo
    {
        public static ShipCargo Process(string json) => JsonConvert.DeserializeObject<ShipCargo>(json, EliteAPI.Status.ShipCargoConverter.Settings);
        public static ShipCargo FromFile(FileInfo file, EliteDangerousAPI api)
        {
            if (!File.Exists(file.FullName)) { api.Logger.Error("Could not find Cargo.json.", new Exception($"Could not find {file.FullName}")); return new ShipCargo(); }

            //Create a stream from the log file.
            FileStream fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Create a stream from the file stream.
            StreamReader streamReader = new StreamReader(fileStream);

            string json = "";

            //Go through the stream.
            while (!streamReader.EndOfStream) { json = json + streamReader.ReadLine(); }

            //Process this string.
            try { return Process(json); } catch (Exception ex) { api.Logger.Warning("Could not update Cargo.json.", ex); }

            return new ShipCargo();
        }
    }

    

    public static class ShipCargoConverter
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
