using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct BalanceStatusEvent : IStatusEvent<long>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "Balance";
    
    public long Value { get; init; }
}