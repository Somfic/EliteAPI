using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class CrewFireEvent : EventBase
    {
        internal CrewFireEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class CrewFireEvent
    {
        public static CrewFireEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewFireEvent>(json);
        }
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