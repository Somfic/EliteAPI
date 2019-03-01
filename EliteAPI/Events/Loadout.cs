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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("HullValue")]
        public long HullValue { get; internal set; }

        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; internal set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("Rebuy")]
        public long Rebuy { get; internal set; }

        [JsonProperty("Modules")]
        public List<Module> Modules { get; internal set; }
    }

    public partial class Module
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("On")]
        public bool On { get; internal set; }

        [JsonProperty("Priority")]
        public long Priority { get; internal set; }

        [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInClip { get; internal set; }

        [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInHopper { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; internal set; }

        [JsonProperty("Engineering", NullValueHandling = NullValueHandling.Ignore)]
        public Engineering Engineering { get; internal set; }
    }

    public partial class Engineering
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; internal set; }

        [JsonProperty("BlueprintID")]
        public long BlueprintId { get; internal set; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public double Quality { get; internal set; }

        [JsonProperty("ExperimentalEffect", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffect { get; internal set; }

        [JsonProperty("ExperimentalEffect_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffectLocalised { get; internal set; }

        [JsonProperty("Modifiers")]
        public List<LoadOutModifier> Modifiers { get; internal set; }
    }

    public partial class LoadOutModifier
    {
        [JsonProperty("Label")]
        public string Label { get; internal set; }

        [JsonProperty("Value")]
        public double Value { get; internal set; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; internal set; }

        [JsonProperty("LessIsGood")]
        public long LessIsGood { get; internal set; }
    }

    public partial class LoadoutInfo
    {
        public static LoadoutInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLoadoutEvent(JsonConvert.DeserializeObject<LoadoutInfo>(json, EliteAPI.Events.LoadoutConverter.Settings));
    }

    public static class LoadoutSerializer
    {
        public static string ToJson(this LoadoutInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LoadoutConverter.Settings);
    }

    internal static class LoadoutConverter
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
