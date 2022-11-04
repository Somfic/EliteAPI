using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Bindings;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Events;
using EliteAPI.Events.Status.Ship;
using EliteAPI.Events.Status.Ship.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI;

/// <inheritdoc />
public class EliteDangerousApi : IEliteDangerousApi
{
    /// <inheritdoc />
    public IEliteDangerousApiConfiguration Config { get; }

    /// <inheritdoc />
    public IEventParser EventParser { get; }

    /// <inheritdoc />
    public IBindingsParser BindingsParser { get; }

    /// <inheritdoc />
    public IBindings Bindings { get; private set; }

    /// <inheritdoc />
    public bool IsRunning { get; private set; }

    private readonly ILogger<EliteDangerousApi>? _log;

    private DirectoryInfo _journalsDirectory;
    private DirectoryInfo _optionsDirectory;
    private readonly IReader _reader;
    private Task _mainTask;
    private bool _hasInitialised;

    /// <summary>
    /// Creates a new instance of the EliteDangerousApi class using the services defined in the provided IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to use to create the instance.</param>
    public EliteDangerousApi(IServiceProvider services)
    {
        _log = services.GetService<ILogger<EliteDangerousApi>>();

        EventParser = services.GetRequiredService<IEventParser>();
        Events = services.GetRequiredService<IEvents>();

        BindingsParser = services.GetRequiredService<IBindingsParser>();
        Bindings = services.GetRequiredService<IBindings>();
        
        Config = services.GetRequiredService<IEliteDangerousApiConfiguration>();
        _reader = services.GetRequiredService<IReader>();
    }

    /// <summary>
    /// Creates a new instance of the EliteDangerousApi class.
    /// </summary>
    public static IEliteDangerousApi Create()
    {
        var host = Host.CreateDefaultBuilder()
            //.ConfigureLogging(log => log.ClearProviders())
            .ConfigureServices(services => services.AddEliteApi())
            .Build();

        return host.Services.GetRequiredService<IEliteDangerousApi>();
    }

    /// <inheritdoc />
    public async Task InitialiseAsync()
    {
        _log?.LogDebug("Initialising EliteAPI v{Version}", typeof(EliteDangerousApi).Assembly.GetName().Version);

        // Apply the configuration
        Config.Apply();

        // Use the Localised structs while parsing
        EventParser.Use<LocalisedConverter>();

        // Register all events
        Events.Register();

        Events.On<StatusEvent>(HandleStatus);

        // Register Journal files
        _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), Config.JournalPattern, FileCategory.Events, true));

        // Register status files
        foreach (var statusFile in Config.StatusFiles)
        {
            _reader.Register(new FileSelector(new DirectoryInfo(Config.JournalsPath), statusFile, FileCategory.Status));
        }
        
        // Register bindings file
        _reader.Register(new FileSelector(new DirectoryInfo(Path.Combine(Config.OptionsPath, "Bindings")), "Custom.4.0.binds", FileCategory.Bindings));

        _hasInitialised = true;
    }

    /// <inheritdoc />
    public async Task<bool> StartAsync()
    {
        if (!_hasInitialised)
            await InitialiseAsync();

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

            await DoTick(true);

            _mainTask = Task.Run(async () =>
            {
                while (IsRunning)
                {
                    await DoTick();
                    await Task.Delay(500);
                }
            });

            return true;
        }
        catch (Exception ex)
        {
            _log?.LogCritical(ex, "Could not start EliteAPI");
            OnError?.Invoke(this, ex);
            return false;
        }
    }

    private async Task DoTick(bool isFirstRun = false)
    {
        await foreach (var (info, selector, line) in _reader.FindNew())
        {
            if (string.IsNullOrEmpty(line))
                continue;

            switch (selector.Category)
            {
                case FileCategory.Events:
                case FileCategory.Status:
                {
                    var context = new EventContext
                    {
                        IsRaisedDuringCatchup = isFirstRun,
                        SourceFile = info.FullName
                    };

                    Events.Invoke(line!, context);
                    break;
                }

                case FileCategory.Bindings:
                {
                    var context = new BindingsContext
                    {
                        SourceFile = info.FullName,
                        IsRaisedDuringCatchup = isFirstRun
                    };

                    Bindings.Invoke(line!, context);
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(selector.Category));
            }
        }
    }

    /// <inheritdoc />
    public async Task StopAsync()
    {
        IsRunning = false;
        await _mainTask;
    }

    /// <inheritdoc />
    public event EventHandler<Exception>? OnError;

    /// <inheritdoc />
    public IEvents Events { get; }

    private StatusEvent? _lastStatus;

    private void HandleStatus(StatusEvent status, EventContext context)
    {
        // Check each property to see if it has changed
        var properties = typeof(StatusEvent).GetProperties();

        foreach (var property in properties)
        {
            if (property.Name is "Timestamp" or "Event" or "Flags" or "Flags2")
                continue;
            
            var oldValue = _lastStatus != null ? property.GetValue(_lastStatus) : null;
            var newValue = property.GetValue(status);

            if (JsonConvert.SerializeObject(oldValue) == JsonConvert.SerializeObject(newValue))
                continue;

            var typeName = $"EliteAPI.Events.Status.Ship.Events.{property.Name}StatusEvent";
            var statusEventType = typeof(GearStatusEvent).Assembly.GetType(typeName);
            if (statusEventType == null)
            {
                _log?.LogWarning("Could not find type {TypeName}", typeName);
                continue;
            }

            var emptyStatusEvent = new EmptyStatusEvent()
            {
                Timestamp = DateTime.Now,
                Event = $"{property.Name}Status",
                Value = newValue
            };

            var json = JsonConvert.SerializeObject(emptyStatusEvent);

            Events.Invoke(json, context);
        }

        _lastStatus = status;
    }
}