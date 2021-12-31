namespace EliteAPI.Abstractions.Readers;

public readonly struct FileSelector
{
    public DirectoryInfo Directory { get; }
    public string FilePattern { get; }
    public bool ContainsMultipleEntries { get; }

    public FileSelector(DirectoryInfo directory, string filePattern, bool containsMultipleEntries = false)
    {
        Directory = directory;
        FilePattern = filePattern;
        ContainsMultipleEntries = containsMultipleEntries;
    }
}