﻿using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct OnFootInSocialSpaceStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "OnFootInSocialSpace";
    
    public bool Value { get; init; }
}