using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct TemperatureStatusEvent : IStatusEvent<float>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Temperature";
    
    public float Value { get; init; }
}