using EliteAPI.Abstractions.Readers.Selectors;

namespace EliteAPI.Abstractions.Readers;

public record Line(FileInfo File, IFileSelector Selector, string? Value);