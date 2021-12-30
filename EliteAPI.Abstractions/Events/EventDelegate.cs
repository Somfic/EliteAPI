namespace EliteAPI.Abstractions.Events;

public delegate void EventDelegate<in TEvent>(TEvent e) where TEvent : IEvent;