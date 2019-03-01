namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerCraftInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("ApplyExperimentalEffect")]
        public string ApplyExperimentalEffect { get; internal set; }

        [JsonProperty("Ingredients")]
        public List<Ingredient> Ingredients { get; internal set; }

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

        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; internal set; }

        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; internal set; }

        [JsonProperty("Modifiers")]
        public List<Modifier> Modifiers { get; internal set; }
    }

    public partial class Ingredient
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class Modifier
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

    public partial class EngineerCraftInfo
    {
        public static EngineerCraftInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerCraftEvent(JsonConvert.DeserializeObject<EngineerCraftInfo>(json, EliteAPI.Events.EngineerCraftConverter.Settings));
    }

    public static class EngineerCraftSerializer
    {
        public static string ToJson(this EngineerCraftInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EngineerCraftConverter.Settings);
    }

    internal static class EngineerCraftConverter
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
