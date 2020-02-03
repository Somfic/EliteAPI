namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class MassModuleStoreInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }
        [JsonProperty("Items")]
        public List<Item> Items { get; internal set; }
    }
    public partial class Item
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }
        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }
        [JsonProperty("Level")]
        public long Level { get; internal set; }
        [JsonProperty("Quality")]
        public double Quality { get; internal set; }
    }
    public partial class MassModuleStoreInfo
    {
        internal static MassModuleStoreInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMassModuleStoreEvent(JsonConvert.DeserializeObject<MassModuleStoreInfo>(json, EliteAPI.Events.MassModuleStoreConverter.Settings));
    }
    
    internal static class MassModuleStoreConverter
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
