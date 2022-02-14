using System.Text.RegularExpressions;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Events;
using EliteAPI.Readers;
using EliteAPI.Server;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Example;

public class Core
{
    private readonly IEliteDangerousApi _api;
    private readonly EliteDangerousApiServer _server;
    private readonly ILogger<Core> _log;

    public Core(ILogger<Core> log, IEliteDangerousApi api, EliteDangerousApiServer server)
    {
        _log = log;
        _api = api;
        _server = server;
    }

    public async Task Run()
    {
        await _api.InitialiseAsync();
        
        _api.Events.OnAny(ImplementedEventHandler);
        _api.Events.OnAny(NotImplementedEventHandler);

        await _api.StartAsync();
        
        await _server.StartAsync();

        await Task.Delay(-1);
    }

    private void ImplementedEventHandler(IEvent @event, EventContext context)
    {
        if (!context.IsImplemented)
            return;
    }
    
    private void NotImplementedEventHandler(string json, EventContext context)
    {
        if (context.IsImplemented)
            return;
        
        _log.LogDebug(string.Join(", ", _api.Parser.ToPaths(json).Select(x => $"{x.Path}: {x.Value}")));
    }
}