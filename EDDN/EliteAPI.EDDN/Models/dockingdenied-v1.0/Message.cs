using System;
 
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace EliteAPI.EDDN.Schemas.dockingdenied_v1_0
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
        /// Contains all properties from the listed events in the client's journal minus the Localised strings and the properties marked below as 'disallowed'
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

        [Newtonsoft.Json.JsonProperty("MarketID", Required = Newtonsoft.Json.Required.Always)]
        public int MarketID { get; set; }

        /// <summary>
        /// Name of station
        /// </summary>
        [Newtonsoft.Json.JsonProperty("StationName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string StationName { get; set; }

        /// <summary>
        /// Type of station
        /// </summary>
        [Newtonsoft.Json.JsonProperty("StationType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StationType { get; set; }

        /// <summary>
        /// Reason docking was denied
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Reason", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Reason { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum MessageEvent
    {

        [System.Runtime.Serialization.EnumMember(Value = @"DockingDenied")]
        DockingDenied = 0,


    }
}