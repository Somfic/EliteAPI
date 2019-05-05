using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Events
{
    public class StatusEvent : IEvent
    {
        public StatusEvent(string Event, dynamic Value)
        {
            this.Event = Event;
            this.@event = Event;
            this.Value = Value;
            this.value = Value;
        }

        public string Event { get; set; }

        public string @event { get => Event; set => Event = value; }

        public dynamic Value { get; set; }

        public dynamic value { get => Value; set => Value = value; }
    }
}
