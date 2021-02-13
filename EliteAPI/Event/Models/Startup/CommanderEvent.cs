using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class CommanderEvent : EventBase
    {
        internal CommanderEvent() { }

        [JsonProperty("FID")]
        public string Fid { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

    public partial class CommanderEvent
    {
        public static CommanderEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommanderEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CommanderEvent> CommanderEvent;

        internal void InvokeCommanderEvent(CommanderEvent arg)
        {
            CommanderEvent?.Invoke(this, arg);
        }
    }
}