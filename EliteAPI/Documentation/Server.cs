using System.Net;
using System.Text;
using Newtonsoft.Json;
using WatsonWebsocket;
using System.Threading;
using EliteAPI.Utils;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace EliteAPI.Documentation;

public class Server
{
	private readonly EliteDangerousApi _api;
	private readonly WatsonWsServer _server;
	// private readonly Timer _countdown;
	private List<Command> _commands = [];
	private List<Variable> _variables = [];
	// private VariableDocumentation[] _variables;

	public Server(EliteDangerousApi api)
	{
		_api = api;
		_server = new WatsonWsServer(IPAddress.Loopback.ToString(), 51555);
	}

	public async Task Initialize()
	{
		// send all recorded stuff... 
		Log.Debug("Starting socket server");

		_server.Logger += message => Log.Debug(message);

		_server.ClientConnected += async (_, c) =>
		{
			Log.Debug("Client connected");

			await SendToClient(c.IpPort, "commands", JsonConvert.SerializeObject(_commands));
			await SendToClient(c.IpPort, "variables", JsonConvert.SerializeObject(_variables));
		};

		// send updated
		_api.OnAllJson(async handler =>
			{
				_commands.Add(new Command
				{
					Name = handler.eventName,
					Timestamp = DateTime.Now,
				});

				_variables.Add(new Variable
				{
					Name = handler.eventName,
					Value = handler.json,
					Category = handler.eventContext.SourceFile,
				});

				await SendToClients("commands", JsonConvert.SerializeObject(_commands));
				await SendToClients("variables", JsonConvert.SerializeObject(_variables));
			});

		// _server.MessageReceived += (_, e) =>
		// {
		// 	var json = Encoding.UTF8.GetString(e.Data.ToArray());
		// 	Log.Info($"Invoking custom JSON: {JsonConvert.SerializeObject(json)}");
		// 	_api.Events.Invoke(json, new EventContext()
		// 	{
		// 		IsImplemented = true,
		// 		IsRaisedDuringCatchup = false,
		// 		SourceFile = "Invoked JSON"
		// 	});
		// };


		await _server.StartAsync();
	}

	private async Task SendToClients(string type, string json)
	{
		foreach (var ipPort in _server.ListClients())
		{
			await SendToClient(ipPort, type, json);
		}
	}

	private async Task SendToClient(string ipPort, string type, string json)
	{
		await _server.SendAsync(ipPort, type.ToUpper());
		await _server.SendAsync(ipPort, json);
	}
}
