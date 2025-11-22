namespace EliteAPI.Watcher;

public class EntireFileWatcher : FileWatcher<string>
{
    private EntireFileWatcher(FileInfo file) : base(file)
    {
    }

    public static (EntireFileWatcher watcher, string initialContent) Create(FileInfo file)
    {
        var watcher = new EntireFileWatcher(file);
        var initialContent = System.IO.File.ReadAllText(file.FullName);
        return (watcher, initialContent);
    }

    public void OnChange(Action<string> onChange)
    {
        StartWatching(onChange, () =>
        {
            var content = System.IO.File.ReadAllText(File.FullName);
            onChange(content);
        });
    }
}
