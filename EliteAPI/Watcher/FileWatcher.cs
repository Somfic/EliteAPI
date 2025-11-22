namespace EliteAPI.Watcher;

public abstract class FileWatcher<T>(FileInfo file)
{
    protected FileInfo File { get; set; } = file;

    protected void StartWatching(Action<string> onChange, Action onFileChanged)
    {
        var watcher = new FileSystemWatcher(File.DirectoryName ?? string.Empty, File.Name)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        watcher.Changed += (sender, args) =>
        {
            Thread.Sleep(50);
            onFileChanged();
        };

        watcher.EnableRaisingEvents = true;
    }
}
