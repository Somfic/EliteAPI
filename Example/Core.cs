using System.Text.RegularExpressions;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Events;
using EliteAPI.Readers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Example;

public class Core
{
    private readonly IEliteDangerousApi _api;
    private readonly ILogger<Core> _log;

    public Core(ILogger<Core> log, IEliteDangerousApi api)
    {
        _log = log;
        _api = api;
    }

    public async Task Run()
    {
        await _api.InitialiseAsync();
        
        _api.Events.Register<FileheaderEvent>();
        _api.Events.On<FileheaderEvent>(x =>
        {
            _log.LogInformation("Paths: {Path}", _api.Parser.ToPaths(x));
        });
        
        
        _api.Events.OnAny(x =>
        {
            _log.LogInformation("Any: {x}", x);
        });
        
        
        await _api.StartAsync();

        await Task.Delay(-1);
    }
}

internal readonly struct FileheaderEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("message")]
    public Localised Message { get; init; }
}