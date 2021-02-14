using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ClearSavedGameEvent : EventBase<ClearSavedGameEvent>
    {
        internal ClearSavedGameEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("FID")]
        public string Fid { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;

    }
}