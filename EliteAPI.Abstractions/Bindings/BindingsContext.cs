namespace EliteAPI.Abstractions.Bindings;

public readonly struct BindingsContext
{
    /// <summary>
    /// The source file from where the bindings were loaded.
    /// </summary>
    public string SourceFile { get; init; }

    public bool IsRaisedDuringCatchup { get; init; }
}