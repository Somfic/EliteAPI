using System;
 
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace EliteAPI.EDDN.Schemas.commodity_v3_0
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Disallowed
    {


        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Note: A value of "" indicates that the commodity is not normally sold/purchased at this station, but is currently temporarily for sale/purchase
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum LevelType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"0")]
        _0 = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"1")]
        _1 = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"2")]
        _2 = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"3")]
        _3 = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"")]
        Empty = 4,


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Json
    {
        [Newtonsoft.Json.JsonProperty("$schemaRef", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SchemaRef { get; set; }

        [Newtonsoft.Json.JsonProperty("header", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Header Header { get; set; } = new Header();

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Message Message { get; set; } = new Message();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Header
    {
        [Newtonsoft.Json.JsonProperty("uploaderID", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string UploaderID { get; set; }

        /// <summary>
        /// Fileheader-&gt;gameversion, else LoadGame-&gt;gameversion, else 'CAPI-market', else ''.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gameversion", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gameversion { get; set; }

        /// <summary>
        /// Fileheader-&gt;build, else LoadGame-&gt;build, else 'CAPI-market', else ''.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gamebuild", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gamebuild { get; set; }

        [Newtonsoft.Json.JsonProperty("softwareName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SoftwareName { get; set; }

        [Newtonsoft.Json.JsonProperty("softwareVersion", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Timestamp upon receipt at the gateway. If present, this property will be overwritten by the gateway; submitters are not intended to populate this property.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gatewayTimestamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime GatewayTimestamp { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Message
    {
        [Newtonsoft.Json.JsonProperty("systemName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string SystemName { get; set; }

        [Newtonsoft.Json.JsonProperty("stationName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string StationName { get; set; }

        [Newtonsoft.Json.JsonProperty("stationType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StationType { get; set; }

        [Newtonsoft.Json.JsonProperty("carrierDockingAccess", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CarrierDockingAccess { get; set; }

        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Always)]
        public int MarketId { get; set; }

        /// <summary>
        /// Whether the sending Cmdr has a Horizons pass.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("horizons", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Horizons { get; set; }

        /// <summary>
        /// Whether the sending Cmdr has an Odyssey expansion.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("odyssey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Odyssey { get; set; }

        [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Commodities returned by the Companion API, with illegal commodities omitted
        /// </summary>
        [Newtonsoft.Json.JsonProperty("commodities", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Commodities> Commodities { get; set; } = new System.Collections.ObjectModel.Collection<Commodities>();

        [Newtonsoft.Json.JsonProperty("economies", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Economies> Economies { get; set; }

        [Newtonsoft.Json.JsonProperty("prohibited", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Prohibited { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Commodities
    {
        /// <summary>
        /// Symbolic name as returned by the Companion API
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("meanPrice", Required = Newtonsoft.Json.Required.Always)]
        public int MeanPrice { get; set; }

        /// <summary>
        /// Price to buy from the market
        /// </summary>
        [Newtonsoft.Json.JsonProperty("buyPrice", Required = Newtonsoft.Json.Required.Always)]
        public int BuyPrice { get; set; }

        [Newtonsoft.Json.JsonProperty("stock", Required = Newtonsoft.Json.Required.Always)]
        public int Stock { get; set; }

        [Newtonsoft.Json.JsonProperty("stockBracket", Required = Newtonsoft.Json.Required.Always)]
        public LevelType StockBracket { get; set; }

        /// <summary>
        /// Price to sell to the market
        /// </summary>
        [Newtonsoft.Json.JsonProperty("sellPrice", Required = Newtonsoft.Json.Required.Always)]
        public int SellPrice { get; set; }

        [Newtonsoft.Json.JsonProperty("demand", Required = Newtonsoft.Json.Required.Always)]
        public int Demand { get; set; }

        [Newtonsoft.Json.JsonProperty("demandBracket", Required = Newtonsoft.Json.Required.Always)]
        public LevelType DemandBracket { get; set; }

        [Newtonsoft.Json.JsonProperty("statusFlags", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<string> StatusFlags { get; set; }

        /// <summary>
        /// Not present in CAPI data, so removed from Journal-sourced data
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Producer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Producer { get; set; }

        /// <summary>
        /// Not present in CAPI data, so removed from Journal-sourced data
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Rare", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Rare { get; set; }

        /// <summary>
        /// Not wanted for historical reasons?
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Id { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Economies
    {
        /// <summary>
        /// Economy type as returned by the Companion API
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("proportion", Required = Newtonsoft.Json.Required.Always)]
        public double Proportion { get; set; }


    }
}