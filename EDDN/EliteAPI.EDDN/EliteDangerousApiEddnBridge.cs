using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using EliteAPI.EDDN.Schemas.commodity_v3_0;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.EDDN;

public class EliteDangerousApiEddnBridge
{
	private readonly ILogger<EliteDangerousApiEddnBridge> _log;
	private readonly HttpClient _http;
	
	private CommanderEvent _commander;
	private FileheaderEvent _fileHeader;
	private LoadGameEvent _loadGame;

	private string productName;
	private string productVersion;

	public EliteDangerousApiEddnBridge(ILogger<EliteDangerousApiEddnBridge> log, IEliteDangerousApi api, IHttpClientFactory http)
	{
		_log = log;

		_http = http.CreateClient("EDDN");
		
		api.Events.On<CommanderEvent>(e => _commander = e);
		api.Events.On<FileheaderEvent>(e => _fileHeader = e);
		api.Events.On<LoadGameEvent>(e => _loadGame = e);
		api.Events.On<MarketEvent>(OnMarketEvent);
	}

	
	public Task StartAsync(string productName, string productVersion)
	{
		this.productName = productName;
		this.productVersion = productVersion;
		return Task.CompletedTask;
	}
	
	private async Task OnMarketEvent(MarketEvent e, EventContext c)
	{
		if (!IsValidEvent(e, c))
			return;
		
		if (e.Commodities == null)
			return;
		
		var header = new Header
		{
			Gamebuild = _fileHeader.Build,
			Gameversion = _fileHeader.Gameversion,
			SoftwareName = productName,
			SoftwareVersion = productVersion,
			UploaderID = _commander.Name,
			GatewayTimestamp = DateTime.Now
		};

		var message = new Message()
		{
			Timestamp = e.Timestamp,
			SystemName = e.StarSystem,
			StationName = e.StationName,
			StationType = e.StationType,
			Horizons = _loadGame.HasHorizons,
			Odyssey = _loadGame.HasOdyssey,
			MarketId = int.Parse(e.MarketId),
			Commodities = e.Commodities
				.Where(commodity => commodity.Category.Local != "NonMarketable")
				.Select(commodity => new Commodities()
				{
					Name = commodity.Name.Symbol.Replace("$", "").Replace("_name;", ""),
					Demand = (int)commodity.Demand,
					Stock = (int)commodity.Stock,
					BuyPrice = (int)commodity.BuyPrice,
					SellPrice = (int)commodity.SellPrice,
					MeanPrice = (int)commodity.MeanPrice,
					StockBracket = (LevelType)commodity.StockBracket,
					DemandBracket = (LevelType)commodity.DemandBracket,
				})
				.ToList()
		};

		var jsonObject = new Json()
		{
			Header = header,
			Message = message,
			SchemaRef = "https://eddn.edcd.io/schemas/commodity/3"
		};

		var json = JsonConvert.SerializeObject(jsonObject);
		await SendData(json);
	}

	private async Task SendData(string json)
	{
		var response = await _http.SendAsync(new HttpRequestMessage()
		{
			RequestUri = new Uri("https://eddn.edcd.io:4430/upload/"),
			Method = HttpMethod.Post,
			Content = new StringContent(json)
		});

		var message = response.StatusCode switch 
		{
			HttpStatusCode.RequestTimeout => "The sender took too long to make/complete its request and the reverse proxy rejected it as a result",
			HttpStatusCode.ServiceUnavailable => "The EDDN Gateway process is either not running, or not responding",
			HttpStatusCode.RequestEntityTooLarge => "Payload was larger than 1mb",
			_ => response.ReasonPhrase
		};
		
		if (!response.IsSuccessStatusCode)
			_log.LogWarning("Failed to send data to EDDN. Status code: {StatusCode} ({Message})", response.StatusCode.ToString(), message);
		else
			_log.LogInformation("Data sent to EDDN successfully!");
		
		_log.LogInformation(await response.Content.ReadAsStringAsync());
	}

	private bool IsValidEvent(IEvent e, EventContext c)
	{
		if (string.IsNullOrWhiteSpace(productName))
			return false;
		
		if (string.IsNullOrWhiteSpace(productVersion))
			return false;
		
		// Filter out events that are raised during catchup
		if (c.IsRaisedDuringCatchup)
			return false;

		// Filter out events that are older than 1 minute
		if (e.Timestamp < DateTime.UtcNow.AddMinutes(-1))
			return false;

		// Filter out alpha/beta game versions
		if(_fileHeader.Gameversion.ToLower().Contains("beta") || _fileHeader.Gameversion.ToLower().Contains("alpha"))
			return false;
        
		return true;
	}
}