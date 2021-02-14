using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class UssDropEvent : EventBase<UssDropEvent>
    {
        internal UssDropEvent() { }

        [JsonProperty("USSType")]
        public string UssType { get; private set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; private set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UssDropEvent> UssDropEvent;

    }
}