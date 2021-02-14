using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CommanderEvent : EventBase<CommanderEvent>
    {
        internal CommanderEvent() { }

        [JsonProperty("FID")]
        public string Fid { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }
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