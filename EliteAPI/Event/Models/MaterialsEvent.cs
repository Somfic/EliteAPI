
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MaterialsEvent : EventBase
    {
        internal MaterialsEvent() { }

        [JsonProperty("RawInfo")]
        public IReadOnlyList<RawInfo> Raw { get; private set; }

        [JsonProperty("Manufactured")]
        public IReadOnlyList<EncodedInfo> Manufactured { get; private set; }

        [JsonProperty("EncodedInfo")]
        public IReadOnlyList<EncodedInfo> Encoded { get; private set; }
    

    public partial class EncodedInfo
    {
        internal EncodedInfo() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class RawInfo
    {
        internal RawInfo() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

}

    public partial class MaterialsEvent
    {
        public static MaterialsEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MaterialsEvent> MaterialsEvent;
        internal void InvokeMaterialsEvent(MaterialsEvent arg) => MaterialsEvent?.Invoke(this, arg);
    }
}
