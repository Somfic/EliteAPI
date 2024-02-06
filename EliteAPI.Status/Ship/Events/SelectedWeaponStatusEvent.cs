using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct SelectedWeaponStatusEvent : IStatusEvent<Localised>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "SelectedWeapon";
    
    public Localised Value { get; init; }
}