using System.Net;
using System.Net.Sockets;
using EliteAPI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using EliteAPI.Abstractions.Configuration;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProtoBuf;

namespace EliteAPI.Server;

public class EliteDangerousApiServer
{
    private readonly IServiceProvider _services;
    private readonly ILogger<EliteDangerousApiServer>? _log;
    private readonly IEliteDangerousApi _api;
    private readonly IConfiguration _config;
    public bool IsRunning { get; private set; }

    public EliteDangerousApiServer(IServiceProvider services)
    {
        _services = services;
        _log = services.GetService<ILogger<EliteDangerousApiServer>>();
        _api = services.GetRequiredService<IEliteDangerousApi>();
        _config = services.GetRequiredService<IConfiguration>();

        _api.Events.OnAny(OnAny);
    }

    private void OnAny(IEvent e, EventContext context)
    {
       Task.Run(async () =>
       {
           var paths = _api.Parser.ToPaths(e);
           var payload = new EventPaths(paths);

           var bytes = _api.Parser.ToProto(payload);
          
           foreach (var client in _clients.Where(x => x.IsOpen && x.IsAccepted))
           {
               await client.WriteAsync(bytes);
           }  
       }).GetAwaiter().GetResult();
    }

    private readonly List<Client> _clients = new();
    private readonly List<Task> _clientTasks = new();
    private Task _mainTask;

    public Task StartAsync()
    {
        _log?.LogInformation("Starting EliteAPI Server v{Version}",
            typeof(EliteDangerousApiServer).Assembly.GetName().Version);

        var port = _config.GetValue("EliteAPI:Server:Port", 51550);

        var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        listener.Start();

        var ip = listener.LocalEndpoint as IPEndPoint;

        _log?.LogInformation("EliteAPI Server listening on port {Ip}:{Port}", ip.Address, ip.Port);

        _mainTask = Task.Run(async () =>
        {
            IsRunning = true;

            while (IsRunning)
            {
                var tcp = await listener.AcceptTcpClientAsync();
                var client = ActivatorUtilities.CreateInstance<Client>(_services, tcp);
                _clients.Add(client);
                _clientTasks.Add(Task.Run(async () => await client.Handle()));
            }
        });

        return _mainTask;
    }

    public async Task StopAsync()
    {
        _log?.LogDebug("Stopping EliteAPI Server");

        IsRunning = false;

        foreach (var client in _clients.Where(x => x.IsOpen))
        {
            await client.CloseAsync();
        }

        await _mainTask;

        _log?.LogInformation("Stopped EliteAPI Server");
    }
}