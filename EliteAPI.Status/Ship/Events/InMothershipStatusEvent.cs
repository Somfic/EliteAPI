using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct InMothershipStatusEvent : IStatusEvent<bool>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "InMothership";
    
    public bool Value { get; init; }
}