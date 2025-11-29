using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct MarketEvent : IEvent
{
	[JsonProperty("timestamp")]
	public DateTime Timestamp { get; init; }

	[JsonProperty("event")]
	public string Event { get; init; }

	[JsonProperty("MarketID")]
	public string MarketId { get; init; }

	[JsonProperty("StationName")]
	public string StationName { get; init; }

	[JsonProperty("StationType")]
	public string StationType { get; init; }

	[JsonProperty("StarSystem")]
	public string StarSystem { get; init; }

	[JsonProperty("Items")]
	public IReadOnlyCollection<Commodity> Commodities { get; init; }

	public class Commodity
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("Name")]
		public LocalisedField Name { get; set; }

		[JsonProperty("Category")]
		public LocalisedField Category { get; set; }

		[JsonProperty("BuyPrice")]
		public long BuyPrice { get; set; }

		[JsonProperty("SellPrice")]
		public long SellPrice { get; set; }

		[JsonProperty("MeanPrice")]
		public long MeanPrice { get; set; }

		[JsonProperty("StockBracket")]
		public long StockBracket { get; set; }

		[JsonProperty("DemandBracket")]
		public long DemandBracket { get; set; }

		[JsonProperty("Stock")]
		public long Stock { get; set; }

		[JsonProperty("Demand")]
		public long Demand { get; set; }

		[JsonProperty("Consumer")]
		public bool IsConsumer { get; set; }

		[JsonProperty("Producer")]
		public bool IsProducer { get; set; }

		[JsonProperty("Rare")]
		public bool IsRare { get; set; }
	}
}
