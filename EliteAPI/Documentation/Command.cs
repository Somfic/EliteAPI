using System;

namespace EliteAPI.Documentation;

public readonly struct Command
{
    public DateTime Timestamp { get; init; }

    public string Name { get; init; }
}
