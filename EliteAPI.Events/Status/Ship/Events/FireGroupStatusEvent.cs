using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct FireGroupStatusEvent : IStatusEvent<int>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "FireGroup";
    
    public int Value { get; init; }
}