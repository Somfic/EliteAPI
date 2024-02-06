using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct DestinationStatusEvent : IStatusEvent<ShipDestination>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Destination";
    
    public ShipDestination Value { get; init; }
}