using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct PipsStatusEvent : IStatusEvent<ShipPips>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Pips";
    
    public ShipPips Value { get; init; }
}