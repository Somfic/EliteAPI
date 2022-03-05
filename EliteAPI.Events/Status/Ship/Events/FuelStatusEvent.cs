using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct FuelStatusEvent : IStatusEvent<ShipFuel>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Fuel";
    
    public ShipFuel Value { get; init; }
}