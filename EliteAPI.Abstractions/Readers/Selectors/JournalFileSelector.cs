namespace EliteAPI.Abstractions.Readers.Selectors;

public class JournalFileSelector : IFileSelector
{
    private readonly DirectoryInfo _directory;
    private readonly string _pattern;

    public JournalFileSelector(DirectoryInfo directory, string pattern)
    {
        _directory = directory;
        _pattern = pattern;
    }

    public bool IsApplicable => true;
    public bool IsMultiLine => true;
    
    public FileCategory Category => FileCategory.Events;
    
    public FileInfo GetFile()
    {
        var file = _directory.GetFiles(_pattern).OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
        
        if (file == null)
            throw new FileNotFoundException($"Could not find any files matching the pattern {_pattern} in {_directory.FullName}");
        
        return file;
    }
}