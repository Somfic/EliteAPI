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
            @event = Event;
            value = Value;
        }

        public string @event { get; set; }
        public dynamic value { get; set; }
    }
}
