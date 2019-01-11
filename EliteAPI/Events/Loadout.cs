namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LoadoutInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; set; }

        [JsonProperty("HullValue")]
        public long HullValue { get; set; }

        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("Rebuy")]
        public long Rebuy { get; set; }

        [JsonProperty("Modules")]
        public List<Module> Modules { get; set; }
    }

    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("Item")]
        public string Item { get; set; }

        [JsonProperty("On")]
        public bool On { get; set; }

        [JsonProperty("Priority")]
        public long Priority { get; set; }

        [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInClip { get; set; }

        [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInHopper { get; set; }

        [JsonProperty("Health")]
        public double Health { get; set; }

        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("Engineering", NullValueHandling = NullValueHandling.Ignore)]
        public Engineering Engineering { get; set; }
    }

    public partial class Engineering
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; set; }

        [JsonProperty("BlueprintID")]
        public long BlueprintId { get; set; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; set; }

        [JsonProperty("Level")]
        public long Level { get; set; }

        [JsonProperty("Quality")]
        public double Quality { get; set; }

        [JsonProperty("ExperimentalEffect", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffect { get; set; }

        [JsonProperty("ExperimentalEffect_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffectLocalised { get; set; }

        [JsonProperty("Modifiers")]
        public List<Modifier> Modifiers { get; set; }
    }

    public partial class Modifier
    {
        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; set; }

        [JsonProperty("LessIsGood")]
        public long LessIsGood { get; set; }
    }

    public partial class LoadoutInfo
    {
        public static LoadoutInfo Process(string json) => EventHandler.InvokeLoadoutEvent(JsonConvert.DeserializeObject<LoadoutInfo>(json, EliteAPI.Events.LoadoutConverter.Settings));
    }

    public static class LoadoutSerializer
    {
        public static string ToJson(this LoadoutInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LoadoutConverter.Settings);
    }

    internal static class LoadoutConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
