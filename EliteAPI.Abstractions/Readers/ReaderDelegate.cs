namespace EliteAPI.Abstractions.Readers;

public delegate void ReaderDelegate<in T>(T entry) where T : IReadable;