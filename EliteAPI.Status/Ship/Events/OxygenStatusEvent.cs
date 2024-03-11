using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct OxygenStatusEvent : IStatusEvent<double>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Oxygen";
    
    public double Value { get; init; }
}