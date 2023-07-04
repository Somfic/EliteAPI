namespace EliteAPI.Abstractions.Readers.Selectors;

public class StatusFileSelector : IFileSelector
{
    private readonly DirectoryInfo _directory;
    private readonly string _file;

    public StatusFileSelector(DirectoryInfo directory, string file)
    {
        _directory = directory;
        _file = file;
    }
    
    public bool IsMultiLine => false;
    
    public FileCategory Category => FileCategory.Status;
    
    public FileInfo GetFile()
    {
        var files = _directory.GetFiles(_file);
        
        if (files.Length == 0)
            throw new FileNotFoundException($"Could not find file {_file} in {_directory.FullName}");

        return files[0];
    }
}