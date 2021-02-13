using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class ClearSavedGameEvent : EventBase
    {
        internal ClearSavedGameEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("FID")]
        public string Fid { get; private set; }
    }

    public partial class ClearSavedGameEvent
    {
        public static ClearSavedGameEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ClearSavedGameEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;

        internal void InvokeClearSavedGameEvent(ClearSavedGameEvent arg)
        {
            ClearSavedGameEvent?.Invoke(this, arg);
        }
    }
}