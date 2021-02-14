using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CrewFireEvent : EventBase<CrewFireEvent>
    {
        internal CrewFireEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CrewFireEvent> CrewFireEvent;

        internal void InvokeCrewFireEvent(CrewFireEvent arg)
        {
            CrewFireEvent?.Invoke(this, arg);
        }
    }
}