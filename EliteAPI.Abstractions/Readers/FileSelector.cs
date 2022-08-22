namespace EliteAPI.Abstractions.Readers;

public readonly struct FileSelector
{
    public DirectoryInfo Directory { get; }
    public string FilePattern { get; }
    public bool IsMultiLine { get; }
    
    public FileCategory Category { get; }

    public FileSelector(DirectoryInfo directory, string filePattern, FileCategory category, bool isMultiLine = false)
    {
        Directory = directory;
        FilePattern = filePattern;
        Category = category;
        IsMultiLine = isMultiLine;
    }
}