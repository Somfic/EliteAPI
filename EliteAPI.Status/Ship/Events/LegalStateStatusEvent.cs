using EliteAPI.Abstractions.Status;

namespace EliteAPI.Status.Ship.Events;

public readonly struct LegalStateStatusEvent : IStatusEvent<LegalState>
{
    public DateTime Timestamp => DateTime.Now;
    
    public string Event => "LegalState";
    
    public LegalState Value { get; init; }
}