using System;

using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<IEvent> AllEvent;

        internal void InvokeAllEvent(IEvent gameEvent)
        {
            AllEvent?.Invoke(this, gameEvent);
        }
    }
}