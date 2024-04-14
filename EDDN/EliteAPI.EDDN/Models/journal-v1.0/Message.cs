using System;
 
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace EliteAPI.EDDN.Schemas.journal_v1_0
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Json
    {
        [Newtonsoft.Json.JsonProperty("$schemaRef", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SchemaRef { get; set; }

        [Newtonsoft.Json.JsonProperty("header", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Header Header { get; set; } = new Header();

        /// <summary>
        /// Contains all properties from the listed events in the client's journal minus Localised strings and the properties marked below as 'disallowed'
        /// </summary>
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
        /// From Fileheader event if available, else LoadGame if available there.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gameversion", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gameversion { get; set; }

        /// <summary>
        /// The `build` value from a Fileheader event if available, else LoadGame if available there.
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
        [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public DateTime Timestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("event", Required = Newtonsoft.Json.Required.Always)]
        public MessageEvent Event { get; set; }

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

        /// <summary>
        /// Must be added by the sender if not present in the journal event
        /// </summary>
        [Newtonsoft.Json.JsonProperty("StarSystem", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string StarSystem { get; set; }

        /// <summary>
        /// Must be added by the sender if not present in the journal event
        /// </summary>
        [Newtonsoft.Json.JsonProperty("StarPos", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(3)]
        [System.ComponentModel.DataAnnotations.MaxLength(3)]
        public System.Collections.Generic.ICollection<double> StarPos { get; set; } = new System.Collections.ObjectModel.Collection<double>();

        /// <summary>
        /// Should be added by the sender if not present in the journal event
        /// </summary>
        [Newtonsoft.Json.JsonProperty("SystemAddress", Required = Newtonsoft.Json.Required.Always)]
        public int SystemAddress { get; set; }

        /// <summary>
        /// Present in Location, FSDJump and CarrierJump messages
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Factions", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Factions> Factions { get; set; }

        [Newtonsoft.Json.JsonProperty("ActiveFine", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed ActiveFine { get; set; }

        [Newtonsoft.Json.JsonProperty("CockpitBreach", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed CockpitBreach { get; set; }

        [Newtonsoft.Json.JsonProperty("BoostUsed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed BoostUsed { get; set; }

        [Newtonsoft.Json.JsonProperty("FuelLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed FuelLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("FuelUsed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed FuelUsed { get; set; }

        [Newtonsoft.Json.JsonProperty("JumpDist", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed JumpDist { get; set; }

        [Newtonsoft.Json.JsonProperty("Latitude", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Latitude { get; set; }

        [Newtonsoft.Json.JsonProperty("Longitude", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Longitude { get; set; }

        [Newtonsoft.Json.JsonProperty("Wanted", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Wanted { get; set; }

        [Newtonsoft.Json.JsonProperty("IsNewEntry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed IsNewEntry { get; set; }

        [Newtonsoft.Json.JsonProperty("NewTraitsDiscovered", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed NewTraitsDiscovered { get; set; }

        [Newtonsoft.Json.JsonProperty("Traits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed Traits { get; set; }

        [Newtonsoft.Json.JsonProperty("VoucherAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed VoucherAmount { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum MessageEvent
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Docked")]
        Docked = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"FSDJump")]
        FSDJump = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"Scan")]
        Scan = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"Location")]
        Location = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"SAASignalsFound")]
        SAASignalsFound = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"CarrierJump")]
        CarrierJump = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"CodexEntry")]
        CodexEntry = 6,


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Factions
    {
        [Newtonsoft.Json.JsonProperty("HappiestSystem", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed HappiestSystem { get; set; }

        [Newtonsoft.Json.JsonProperty("HomeSystem", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed HomeSystem { get; set; }

        [Newtonsoft.Json.JsonProperty("MyReputation", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed MyReputation { get; set; }

        [Newtonsoft.Json.JsonProperty("SquadronFaction", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Disallowed SquadronFaction { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }
}