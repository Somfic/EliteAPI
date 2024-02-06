using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct FireGroupStatusEvent : IStatusEvent<long>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "FireGroup";
    
    public long Value { get; init; }
}