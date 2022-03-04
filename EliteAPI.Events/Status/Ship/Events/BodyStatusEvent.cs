using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct BodyStatusEvent : IStatusEvent<string>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Body";
    
    public string Value { get; init; }
}