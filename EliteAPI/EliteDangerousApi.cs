using System;
using System.IO;
using System.Linq;
using System.Threading;
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
    private readonly IReader _reader;
    private Task _mainTask;

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
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Status.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Backpack.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Cargo.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "ModulesInfo.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "NavRoute.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Outfitting.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "ShipLocker.json"));
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), "Shipyard.json"));
    }

    /// <inheritdoc />
    public async Task StartAsync()
    {
        try
        {
            _log?.LogInformation("Starting EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);

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


            IsRunning = true;

            _log?.LogDebug("Hi");

            _mainTask = Task.Run(async () =>
            {
                var isFirstRun = true;
                
                while (IsRunning)
                {
                    await foreach (var line in _reader.FindNew())
                    {
                        if(string.IsNullOrEmpty(line))
                            continue;

                        var context = new EventContext()
                        {
                            IsRaisedDuringCatchup = isFirstRun
                        };
                        
                        Events.Invoke(line, context);
                    }

                    isFirstRun = false;
                    
                    await Task.Delay(100);
                }
            });
        }
        catch (Exception ex)
        {
            _log?.LogCritical(ex, "Could not start EliteAPI");
            throw;
        }
    }

    /// <inheritdoc />
    public async Task StopAsync()
    {
        IsRunning = false;
        await _mainTask;
    }

    /// <inheritdoc />
    public IEvents Events { get; }
}