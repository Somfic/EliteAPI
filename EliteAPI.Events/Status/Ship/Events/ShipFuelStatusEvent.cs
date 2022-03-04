using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct ShipFuelStatusEvent : IStatusEvent<ShipFuel>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "ShipFuel";
    
    public ShipFuel Value { get; init; }
}