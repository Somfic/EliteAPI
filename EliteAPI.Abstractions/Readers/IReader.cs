using EliteAPI.Abstractions.Readers.Selectors;

namespace EliteAPI.Abstractions.Readers;

public interface IReader
{
    IReadOnlyCollection<IFileSelector> Selectors { get; }

    /// <summary>
    /// Registers a file to be watched by the reader.
    /// </summary>
    /// <param name="selector">File selection options</param>
    void Register(IFileSelector selector);
    
    /// <summary>
    /// Finds all the new changes in the registered files.
    /// </summary>
    IAsyncEnumerable<Line> FindNew();
}