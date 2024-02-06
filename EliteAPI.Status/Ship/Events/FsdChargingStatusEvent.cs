﻿using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct FsdChargingStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "FSDCharging";
    
    public bool Value { get; init; }
}