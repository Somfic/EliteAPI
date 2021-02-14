using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MaterialsEvent : EventBase<MaterialsEvent>
    {
        internal MaterialsEvent() { }

        [JsonProperty("Raw")]
        public IReadOnlyList<RawInfo> Raw { get; private set; }

        [JsonProperty("Manufactured")]
        public IReadOnlyList<EncodedInfo> Manufactured { get; private set; }

        [JsonProperty("Encoded")]
        public IReadOnlyList<EncodedInfo> Encoded { get; private set; }


        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
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

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class RawInfo
        {
            internal RawInfo() { }

            [JsonProperty("Name")]
            public string Name { get; private set; }

            [JsonProperty("Count")]
            public long Count { get; private set; }
        }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MaterialsEvent> MaterialsEvent;

    }
}