namespace EliteAPI.Server;

public readonly struct WebSocketMessage
{
    public WebSocketMessage(Opcode type, string? payload = null)
    {
        Type = type;
        Payload = payload ?? string.Empty;
    }

    public Opcode Type { get; }

    public string Payload { get; }
}