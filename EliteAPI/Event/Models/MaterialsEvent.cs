using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MaterialsEvent : EventBase
    {
        internal MaterialsEvent() { }

        [JsonProperty("RawInfo")]
        public IReadOnlyList<RawInfo> Raw { get; private set; }

        [JsonProperty("Manufactured")]
        public IReadOnlyList<EncodedInfo> Manufactured { get; private set; }

        [JsonProperty("EncodedInfo")]
        public IReadOnlyList<EncodedInfo> Encoded { get; private set; }


        public class EncodedInfo
        {
            internal EncodedInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; private set; }

            [JsonProperty("Count")]
            public long Count { get; private set; }
        }

        public class RawInfo
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
        public static MaterialsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialsEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MaterialsEvent> MaterialsEvent;

        internal void InvokeMaterialsEvent(MaterialsEvent arg)
        {
            MaterialsEvent?.Invoke(this, arg);
        }
    }
}