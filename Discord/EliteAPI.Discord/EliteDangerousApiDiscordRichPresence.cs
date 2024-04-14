using System.Threading.Tasks;
using DiscordRPC;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using ILogger = DiscordRPC.Logging.ILogger;

namespace EliteAPI.Discord;

public class EliteDangerousApiDiscordRichPresence
{
	private readonly ILogger<EliteDangerousApiDiscordRichPresence> _log;
	private readonly IEliteDangerousApi _api;
	private readonly DiscordRpcClient _client;

	public EliteDangerousApiDiscordRichPresence(ILogger<EliteDangerousApiDiscordRichPresence> log, IEliteDangerousApi api)
	{
		_log = log;
		_api = api;
		_client = new DiscordRpcClient("497862888128512041");
		_client.Logger = new ExtensionLogger(_log);
	}

	public async Task StartAsync()
	{
		_log.LogDebug("Starting Discord Rich Presence...");
		_client.Initialize();
		
		_api.Events.On<DockingGrantedEvent>(OnDockingGranted);
		_api.Events.On<DockedEvent>(OnDocked);
		_api.Events.On<UndockedEvent>(OnUndocked);
		_api.Events.On<StartJumpEvent>(OnStartJump);
		_api.Events.On<FsdJumpEvent>(OnFsdJump);
		_api.Events.On<ApproachBodyEvent>(OnApproachBody);
		_api.Events.On<LeaveBodyEvent>(OnLeaveBody);
		_api.Events.On<TouchdownEvent>(OnTouchdown);
		_api.Events.On<LiftoffEvent>(OnLiftoff);
		_api.Events.On<SupercruiseEntryEvent>(OnSupercruiseEntry);
		_api.Events.On<SupercruiseExitEvent>(OnSuperCruiseExit);
	}
	
	private void OnDockingGranted(DockingGrantedEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Docking at",
			Details = @event.StationName,
			Assets = new Assets
			{
				LargeImageKey = "coriolis",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}


	private void OnDocked(DockedEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Docked at",
			Details = @event.StationName,
			Assets = new Assets
			{
				LargeImageKey = "coriolis",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnUndocked(UndockedEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Leaving",
			Details = @event.StationName,
			Assets = new Assets
			{
				LargeImageKey = "coriolis",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnStartJump(StartJumpEvent @event, EventContext context)
	{
		if (@event.JumpType != "FSDJump")
			return;
		
		_client.SetPresence(new RichPresence
		{
			State = "Jumping to",
			Details = @event.StarSystem,
			Assets = new Assets
			{
				LargeImageKey = "ed",
				LargeImageText = "EliteAPI",
			}
		});
	}

	private void OnFsdJump(FsdJumpEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Arrived in",
			Details = @event.StarSystem,
			Assets = new Assets
			{
				LargeImageKey = "route",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnApproachBody(ApproachBodyEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Approaching",
			Details = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnLeaveBody(LeaveBodyEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Leaving",
			Details = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnTouchdown(TouchdownEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Touched down on",
			Details = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnLiftoff(LiftoffEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Lifted off from",
			Details = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnSupercruiseEntry(SupercruiseEntryEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Travelling in supercruise",
			Details = $"in {@event.StarSystem}",
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}

	private void OnSuperCruiseExit(SupercruiseExitEvent @event, EventContext context)
	{
		_client.SetPresence(new RichPresence
		{
			State = "Travelling in normal space",
			Details = $"near {@event.BodyType.ToLower().Replace("planetaryring", "ring")} {@event.Body.Replace("Ring", "")}",
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			}
		});
	}
	
	private class ExtensionLogger : ILogger
	{
		private readonly ILogger<EliteDangerousApiDiscordRichPresence> _log;

		public ExtensionLogger(ILogger<EliteDangerousApiDiscordRichPresence> log)
		{
			_log = log;
		}

		public void Trace(string message, params object[] args)
		{
			_log.LogTrace(message, args);
		}

		public void Info(string message, params object[] args)
		{
			_log.LogInformation(message, args);
		}

		public void Warning(string message, params object[] args)
		{
			_log.LogWarning(message, args);
		}

		public void Error(string message, params object[] args)
		{
			_log.LogError(message, args);
		}

		public DiscordRPC.Logging.LogLevel Level { get; set; }
	}
}