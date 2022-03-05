using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct GuiFocusStatusEvent : IStatusEvent<GuiFocus>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "GuiFocus";
    
    public GuiFocus Value { get; init; }
}