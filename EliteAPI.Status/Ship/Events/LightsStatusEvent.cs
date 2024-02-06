﻿using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct LightsStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Lights";
    
    public bool Value { get; init; }
}