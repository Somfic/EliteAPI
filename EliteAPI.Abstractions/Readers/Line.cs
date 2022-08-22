namespace EliteAPI.Abstractions.Readers;

public record Line(FileInfo File, FileSelector Selector, string? Value);