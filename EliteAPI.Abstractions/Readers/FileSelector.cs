namespace EliteAPI.Abstractions.Readers;

public readonly struct FileSelector
{
    public DirectoryInfo Directory { get; }
    public string FilePattern { get; }
    public bool IsMultiLine { get; }

    public FileSelector(DirectoryInfo directory, string filePattern, bool isMultiLine = false)
    {
        Directory = directory;
        FilePattern = filePattern;
        IsMultiLine = isMultiLine;
    }
}