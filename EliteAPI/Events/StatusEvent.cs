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
            this.Value = Value;
        }

        public string Event { get; set; }
        public dynamic Value { get; set; }
    }
}
