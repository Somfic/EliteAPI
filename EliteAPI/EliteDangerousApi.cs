using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI;

/// <inheritdoc />
public class EliteDangerousApi : IEliteDangerousApi
{
    /// <inheritdoc />
    public IEliteDangerousApiConfiguration Config { get; }

    /// <inheritdoc />
    public IEventParser Parser { get; }

    public bool IsRunning { get; private set; }

    private readonly ILogger<EliteDangerousApi>? _log;

    private DirectoryInfo _journalsDirectory;
    private DirectoryInfo _optionsDirectory;
    private IReader _reader;

    /// <summary>Creates a new instance of the EliteDangerousApi class.</summary>
    public EliteDangerousApi(IServiceProvider services)
    {
        _log = services.GetService<ILogger<EliteDangerousApi>>();

        Parser = services.GetRequiredService<IEventParser>();
        Config = services.GetRequiredService<IEliteDangerousApiConfiguration>();
        Events = services.GetRequiredService<IEvents>();
        _reader = services.GetRequiredService<IReader>();
    }

    /// <inheritdoc />
    public async Task InitialiseAsync()
    {
        _log?.LogDebug("Initialising EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);

        // Apply the configuration
        Config.Apply();

        // Use the Localised structs while parsing
        Parser.Use<LocalisedConverter>();
        
        // Register all events
        Events.Register();

        // Register Journal files
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), Config.JournalPattern, true));

        // Register status files
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Status.json", true));
    }

    /// <inheritdoc />
    public async Task StartAsync()
    {
        try
        {
            _log?.LogInformation("Starting EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);

            IsRunning = true;
            
            _journalsDirectory = new DirectoryInfo(Config.JournalsPath);
            _optionsDirectory = new DirectoryInfo(Config.OptionsPath);

            var missingDirectories = new[] {_journalsDirectory, _optionsDirectory}.Where(d => !d.Exists).ToList();

            if (missingDirectories.Any())
            {
                var ex = new DirectoryNotFoundException("Could not find necessary Elite: Dangerous directories");
                ex.Data.Add("DirectoryPaths", missingDirectories.Select(d => d.FullName).ToArray());

                _log?.LogError(ex, "Could not find necessary directories. Please check your configuration");
                throw ex;
            }


            while (IsRunning)
            {
                await foreach (var line in _reader.FindNew())
                {
                    Events.Invoke(line);
                }

                await Task.Delay(100);
            }
        }
        catch (Exception ex)
        {
            _log?.LogCritical(ex, "Could not start EliteAPI");
            throw;
        }
    }

    public async Task StopAsync()
    {
        IsRunning = false;
    }

    public IEvents Events { get; }
}