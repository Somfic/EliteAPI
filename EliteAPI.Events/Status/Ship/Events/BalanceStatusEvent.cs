using EliteAPI.Abstractions.Status;

namespace EliteAPI.Events.Status.Ship.Events;

public readonly struct BalanceStatusEvent : IStatusEvent<int>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Balance";
    
    public int Value { get; init; }
}