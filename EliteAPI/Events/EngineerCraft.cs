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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("Module")]
        public string Module { get; set; }

        [JsonProperty("ApplyExperimentalEffect")]
        public string ApplyExperimentalEffect { get; set; }

        [JsonProperty("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }

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

        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; set; }

        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; set; }

        [JsonProperty("Modifiers")]
        public List<Modifier> Modifiers { get; set; }
    }

    public partial class Ingredient
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
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
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
