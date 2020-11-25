
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MaterialCollectedEvent : EventBase
    {
        internal MaterialCollectedEvent() { }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }
    }

    public partial class MaterialCollectedEvent
    {
        public static MaterialCollectedEvent FromJson(string json) => JsonConvert.DeserializeObject<MaterialCollectedEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MaterialCollectedEvent> MaterialCollectedEvent;
        internal void InvokeMaterialCollectedEvent(MaterialCollectedEvent arg) => MaterialCollectedEvent?.Invoke(this, arg);
    }
}
