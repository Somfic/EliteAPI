using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI;

/// <inheritdoc />
public class EliteDangerousApi : IEliteDangerousApi
{
    private readonly IEliteDangerousApiConfiguration _config;
    private readonly ILogger<EliteDangerousApi>? _log;

    private DirectoryInfo _journalsDirectory;
    private DirectoryInfo _optionsDirectory;

    /// <summary>Creates a new instance of the EliteDangerousApi class.</summary>
    public EliteDangerousApi(IServiceProvider services)
    {
        _log = services.GetService<ILogger<EliteDangerousApi>>();
        _config = services.GetRequiredService<IEliteDangerousApiConfiguration>();
        Events = services.GetRequiredService<IEvents>();
    }

    public async Task InitialiseAsync()
    {
        _log?.LogDebug("Initialising EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);
        Events.Register();
    }

    /// <inheritdoc />
    public async Task StartAsync()
    {
        try
        {
            _log?.LogInformation("Starting EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);

            _config.Apply();

            _journalsDirectory = new DirectoryInfo(_config.JournalsPath);
            _optionsDirectory = new DirectoryInfo(_config.OptionsPath);

            var missingDirectories = new[] {_journalsDirectory, _optionsDirectory}.Where(d => !d.Exists).ToList();

            if (missingDirectories.Any())
            {
                var ex = new DirectoryNotFoundException("Could not find necessary Elite: Dangerous directories");
                ex.Data.Add("DirectoryPaths", missingDirectories.Select(d => d.FullName).ToArray());

                _log?.LogError(ex, "Could not find necessary directories. Please check your configuration");
                return;
            }

            // Select the latest journal file
            var journalFiles = _journalsDirectory.GetFiles(_config.JournalPattern);
            var latestJournal = journalFiles.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

            if (latestJournal == null)
            {
                var ex = new FileNotFoundException("Could not find any journal files with the specified pattern");
                ex.Data.Add("Pattern", _config.JournalPattern);

                _log?.LogError(ex, "Could not find any journal files. Please check your configuration");
                return;
            }

            _log?.LogInformation("Using {JournalFile}", latestJournal.Name);

            // Get the latest journal file.
            // Hook into the journal file.
            // Start the journal file watcher.
            // On each edit, parse the new JSON events.   
        }
        catch (Exception ex)
        {
            _log?.LogCritical(ex, "Could not start EliteAPI");
            throw;
        }
    }

    public async Task StopAsync()
    {
    }

    public IEvents Events { get; }
}