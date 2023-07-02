using System.Globalization;
using EliteAPI.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Web.EDDB.System.Responses;

[Obsolete("EDDB has shut down their API. This API will be removed in a future version of EliteAPI.", true)]
public class SystemResponse : IWebApiResponse
{
     [JsonProperty("id")]
        public string Id { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }

        [JsonProperty("stations")]
        public IReadOnlyList<Station> Stations { get; init; }
    }

    public class Station
    {
        [JsonProperty("id")]
        public string Id { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }

        [JsonProperty("system_id")]
        public string SystemId { get; init; }

        [JsonProperty("max_landing_pad_size")]
        [JsonConverter(typeof(MaxLandingPadSizeConverter))]
        public MaxLandingPadSize MaxLandingPadSize { get; init; }

        [JsonProperty("distance_to_star")]
        public long DistanceToStar { get; init; }

        [JsonProperty("faction")]
        public string Faction { get; init; }

        [JsonProperty("type_id")]
        public string TypeId { get; init; }

        [JsonProperty("has_blackmarket")]
        public bool HasBlackmarket { get; init; }

        [JsonProperty("has_refuel")]
        public bool HasRefuel { get; init; }

        [JsonProperty("has_repair")]
        public bool HasRepair { get; init; }

        [JsonProperty("has_rearm")]
        public bool HasRearm { get; init; }

        [JsonProperty("has_outfitting")]
        public bool HasOutfitting { get; init; }

        [JsonProperty("has_shipyard")]
        public bool HasShipyard { get; init; }

        [JsonProperty("has_docking")]
        public bool HasDocking { get; init; }

        [JsonProperty("has_commodities")]
        public bool HasCommodities { get; init; }

        [JsonProperty("has_material_trader")]
        public bool HasMaterialTrader { get; init; }

        [JsonProperty("has_technology_broker")]
        public bool HasTechnologyBroker { get; init; }

        [JsonProperty("has_carrier_vendor")]
        public bool HasCarrierVendor { get; init; }

        [JsonProperty("has_carrier_administration")]
        public bool HasCarrierAdministration { get; init; }

        [JsonProperty("has_interstellar_factors")]
        public bool HasInterstellarFactors { get; init; }

        [JsonProperty("has_universal_cartographics")]
        public bool HasUniversalCartographics { get; init; }

        [JsonProperty("has_social_space")]
        public bool HasSocialSpace { get; init; }

        [JsonProperty("updated_at")]
        public long UpdatedAt { get; init; }

        [JsonProperty("shipyard_updated_at")]
        public long? ShipyardUpdatedAt { get; init; }

        [JsonProperty("outfitting_updated_at")]
        public long? OutfittingUpdatedAt { get; init; }

        [JsonProperty("market_updated_at")]
        public long MarketUpdatedAt { get; init; }
    }

    public enum MaxLandingPadSize { L, M, S };

internal class MaxLandingPadSizeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(MaxLandingPadSize) || t == typeof(MaxLandingPadSize?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "L":
                return MaxLandingPadSize.L;
            case "M":
                return MaxLandingPadSize.M;
            case "S":
                return MaxLandingPadSize.S;
        }

        throw new Exception("Cannot unmarshal type MaxLandingPadSize");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (MaxLandingPadSize)untypedValue;
        switch (value)
        {
            case MaxLandingPadSize.L:
                serializer.Serialize(writer, "L");
                return;
            case MaxLandingPadSize.M:
                serializer.Serialize(writer, "M");
                return;
            case MaxLandingPadSize.S:
                serializer.Serialize(writer, "S");
                return;
        }

        throw new Exception("Cannot marshal type MaxLandingPadSize");
    }
}