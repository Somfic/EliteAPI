using System;
using System.Threading.Tasks;
using DiscordRPC;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using EliteAPI.Abstractions.Status;
using EliteAPI.Events;
using EliteAPI.Status.Ship.Events;
using Microsoft.Extensions.Logging;
using ILogger = DiscordRPC.Logging.ILogger;

namespace EliteAPI.Discord;

public class EliteDangerousApiDiscordRichPresence
{
	private readonly ILogger<EliteDangerousApiDiscordRichPresence> _log;
	private readonly IEliteDangerousApi _api;
	private DiscordRpcClient _client;
	
	private string _currentSystem = "";
	private string _currentBody = "";
	private DateTime _playingSince;

	public EliteDangerousApiDiscordRichPresence(ILogger<EliteDangerousApiDiscordRichPresence> log, IEliteDangerousApi api)
	{
		_log = log;
		_api = api;
	}

	public async Task StartAsync()
	{
		_log.LogDebug("Starting Discord Rich Presence...");
		
		_client = new DiscordRpcClient("497862888128512041");
		_client.Logger = new ExtensionLogger(_log);
		
		_client.Initialize();

		_api.Events.On<FileheaderEvent>(OnFileheader);
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
		_api.Events.On<ProspectedAsteroidEvent>(OnProspectedAsteroid);
		_api.Events.On<MarketBuyEvent>(OnMarketBuy);
		_api.Events.On<MarketSellEvent>(OnMarketSell);
		_api.Events.On<DestinationStatusEvent>(OnDestinationStatus);
		_api.Events.On<UnderAttackEvent>(OnUnderAttack);
		_api.Events.On<ShutdownEvent>(OnShutdown);

		_api.Events.On<LocationEvent>(e =>
		{
			_currentSystem = e.StarSystem;
			_currentBody = e.Body;
		});
		
		_api.Events.On<ApproachBodyEvent>(e =>
		{
			_currentSystem = e.StarSystem;
			_currentBody = e.Body;
		});
		
		_api.Events.On<LeaveBodyEvent>(e =>
		{
			_currentSystem = e.StarSystem;
			_currentBody = e.Body;
		});
		
		_api.Events.On<SupercruiseExitEvent>(e =>
		{
			_currentSystem = e.StarSystem;
			_currentBody = e.Body;
		});
		
		_api.Events.On<FsdJumpEvent>(e => _currentSystem = e.StarSystem);
		
		_api.Events.On<DockedEvent>(e => _currentBody = e.StationName);
		
		_api.Events.On<FileheaderEvent>(e => _playingSince = e.Timestamp);
	}

	private void OnFileheader(FileheaderEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.SetPresence(new RichPresence
		{
			State = "Just started playing",
			Assets = new Assets
			{
				LargeImageKey = "ed",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnDockingGranted(DockingGrantedEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		var stationImage = @event.StationType.ToLower() switch
		{
			"coriolis" => "coriolis",
			"orbis" => "orbis",
			"outpost" => "outpost",
			_ => "coriolis"
		};
		
		_client.SetPresence(new RichPresence
		{
			Details = "Docking at space station",
			State = $"{@event.StationName} in {_currentSystem}",
			Assets = new Assets
			{
				LargeImageKey = stationImage,
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}


	private void OnDocked(DockedEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		var stationImage = @event.StationType.ToLower() switch
		{
			"coriolis" => "coriolis",
			"orbis" => "orbis",
			"outpost" => "outpost",
			_ => "coriolis"
		};

		_client.SetPresence(new RichPresence
		{
			Details = "Docked at space station",
			State = $"{@event.StationName} in {_currentSystem}",
			Assets = new Assets
			{
				LargeImageKey = stationImage,
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnUndocked(UndockedEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		var stationImage = @event.StationType.ToLower() switch
		{
			"coriolis" => "coriolis",
			"orbis" => "orbis",
			"outpost" => "outpost",
			_ => "coriolis"
		};
		
		_client.SetPresence(new RichPresence
		{
			Details = "Leaving space station",
			State = $"{@event.StationName} in {_currentSystem}",
			Assets = new Assets
			{
				LargeImageKey = stationImage,
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnStartJump(StartJumpEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		var type = @event.JumpType switch 
		{
			"Hyperspace" => "hyperspace",
			_ => "supercruise"
		};
		
		var details = type == "hyperspace" ? "Travelling in hyperspace" : "Accelerating to supercruise";
		var state = type == "hyperspace" ? $"to {@event.StarSystem}" : $"in {_currentSystem}";
		var image = type == "hyperspace" ? "route" : "loading";
		
		if (type == "hyperspace")
		{
			_client.SetPresence(new RichPresence
			{
				Details = details,
				State = state,
				Assets = new Assets
				{
					LargeImageKey = image,
					SmallImageKey = "ed",
					SmallImageText = "EliteAPI"
				},
				Timestamps = new Timestamps { Start = _playingSince }
			});
		}
		
		
	}

	private void OnFsdJump(FsdJumpEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Arrived in star system",
			State = @event.StarSystem,
			Assets = new Assets
			{
				LargeImageKey = "route",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnApproachBody(ApproachBodyEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Approaching celestial body",
			State = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnLeaveBody(LeaveBodyEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Leaving celestial body",
			State = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnTouchdown(TouchdownEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Landed on celestial body",
			State = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnLiftoff(LiftoffEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Lifting off from celestial body",
			State = @event.Body,
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnSupercruiseEntry(SupercruiseEntryEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Travelling in supercruise",
			State = $"in {@event.StarSystem}",
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}

	private void OnSuperCruiseExit(SupercruiseExitEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;

		_client.SetPresence(new RichPresence
		{
			Details = "Travelling in space",
			State = $"near {@event.BodyType.ToLower().Replace("planetaryring", "ring")} {@event.Body.Replace("Ring", "")}",
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnProspectedAsteroid(ProspectedAsteroidEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.SetPresence(new RichPresence
		{
			Details = "Mining asteroids",
			State = $"around {_currentBody.Replace("Ring", "")}",
			Assets = new Assets
			{
				LargeImageKey = "exploration",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnMarketBuy(MarketBuyEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.SetPresence(new RichPresence
		{
			Details = "Buying at space station",
			State = $"{@event.TotalCost:n0} CR of {@event.Type.Local}",
			Assets = new Assets
			{
				LargeImageKey = "trading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnMarketSell(MarketSellEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.SetPresence(new RichPresence
		{
			Details = "Selling at space station",
			State = $"{@event.TotalSale:n0} CR of {@event.Type.Local}",
			Assets = new Assets
			{
				LargeImageKey = "trading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnDestinationStatus(DestinationStatusEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		// Plotting a course to another star system
		if (@event.Value.BodyId == "0")
			return;
		
		var state = string.IsNullOrEmpty(@event.Value.Name) ? $"in {_currentSystem}" : $"to {@event.Value.Name}";
		
		_client.SetPresence(new RichPresence
		{
			Details = "Travelling in supercruise",
			State = state,
			Assets = new Assets
			{
				LargeImageKey = "loading",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnUnderAttack(UnderAttackEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.SetPresence(new RichPresence
		{
			Details = "In active combat",
			State = $"near {_currentBody}",
			Assets = new Assets
			{
				LargeImageKey = "combat",
				SmallImageKey = "ed",
				SmallImageText = "EliteAPI"
			},
			Timestamps = new Timestamps { Start = _playingSince }
		});
	}
	
	private void OnShutdown(ShutdownEvent @event, EventContext context)
	{
		if (context.IsRaisedDuringCatchup)
			return;
		
		_client.ClearPresence();
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
			_log.LogDebug(message, args);
		}

		public void Warning(string message, params object[] args)
		{
			_log.LogDebug(message, args);
		}

		public void Error(string message, params object[] args)
		{
			_log.LogDebug(message, args);
		}

		public DiscordRPC.Logging.LogLevel Level { get; set; }
	}
}