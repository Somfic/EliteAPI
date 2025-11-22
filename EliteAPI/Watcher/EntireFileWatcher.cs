namespace EliteAPI.Watcher;

public class EntireFileWatcher : FileWatcher<string>
{
    private EntireFileWatcher(FileInfo file) : base(file)
    {
    }

    public static (EntireFileWatcher watcher, string initialContent) Create(FileInfo file)
    {
        var watcher = new EntireFileWatcher(file);
        var initialContent = ReadFileContent(file.FullName);
        return (watcher, initialContent);
    }

    public void OnChange(Action<string> onChange)
    {
        StartWatching(onChange, () =>
        {
            var content = ReadFileContent(File.FullName);
            onChange(content);
        });
    }

    private static string ReadFileContent(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
