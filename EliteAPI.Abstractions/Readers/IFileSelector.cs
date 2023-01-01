namespace EliteAPI.Abstractions.Readers;

public interface IFileSelector
{ 
    public bool IsMultiLine { get; }
    
    public FileCategory Category { get; }
    
    public FileInfo GetFile();
}