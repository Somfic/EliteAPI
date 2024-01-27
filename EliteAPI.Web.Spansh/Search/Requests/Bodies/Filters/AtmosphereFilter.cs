using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Web.Spansh.Search.Requests;

public class AtmosphereFilter
{
    public AtmosphereFilter()
    {
        
    }
    
    public AtmosphereFilter(ICollection<Atmosphere> atmospheres)
    {
        Atmospheres = atmospheres;
    }
    
    public AtmosphereFilter(params Atmosphere[] atmospheres)
    {
        Atmospheres = atmospheres;
    }
    
    [JsonProperty("value")]
    public ICollection<Atmosphere> Atmospheres { get; init; } = new List<Atmosphere>();
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Atmosphere
    {
        [EnumMember(Value = "Ammonia")]
        Ammonia,

        [EnumMember(Value = "Ammonia and Oxygen")]
        AmmoniaAndOxygen,

        [EnumMember(Value = "Ammonia-rich")]
        AmmoniaRich,

        [EnumMember(Value = "Argon")]
        Argon,

        [EnumMember(Value = "Argon-rich")]
        ArgonRich,

        [EnumMember(Value = "Carbon dioxide")]
        CarbonDioxide,

        [EnumMember(Value = "Carbon dioxide-rich")]
        CarbonDioxideRich,

        [EnumMember(Value = "Helium")]
        Helium,

        [EnumMember(Value = "Hot Argon")]
        HotArgon,

        [EnumMember(Value = "Hot Argon-rich")]
        HotArgonRich,

        [EnumMember(Value = "Hot Carbon dioxide")]
        HotCarbonDioxide,

        [EnumMember(Value = "Hot Carbon dioxide-rich")]
        HotCarbonDioxideRich,

        [EnumMember(Value = "Hot Metallic vapour")]
        HotMetallicVapour,

        [EnumMember(Value = "Hot Silicate vapour")]
        HotSilicateVapour,

        [EnumMember(Value = "Hot Sulphur dioxide")]
        HotSulphurDioxide,

        [EnumMember(Value = "Hot Water")]
        HotWater,

        [EnumMember(Value = "Hot Water-rich")]
        HotWaterRich,

        [EnumMember(Value = "Hot thick Ammonia")]
        HotThickAmmonia,

        [EnumMember(Value = "Hot thick Ammonia-rich")]
        HotThickAmmoniaRich,

        [EnumMember(Value = "Hot thick Argon")]
        HotThickArgon,

        [EnumMember(Value = "Hot thick Argon-rich")]
        HotThickArgonRich,

        [EnumMember(Value = "Hot thick Carbon dioxide")]
        HotThickCarbonDioxide,

        [EnumMember(Value = "Hot thick Carbon dioxide-rich")]
        HotThickCarbonDioxideRich,

        [EnumMember(Value = "Hot thick Metallic vapour")]
        HotThickMetallicVapour,

        [EnumMember(Value = "Hot thick Methane")]
        HotThickMethane,

        [EnumMember(Value = "Hot thick Methane-rich")]
        HotThickMethaneRich,

        [EnumMember(Value = "Hot thick Nitrogen")]
        HotThickNitrogen,

        [EnumMember(Value = "Hot thick Silicate vapour")]
        HotThickSilicateVapour,

        [EnumMember(Value = "Hot thick Sulphur dioxide")]
        HotThickSulphurDioxide,

        [EnumMember(Value = "Hot thick Water")]
        HotThickWater,

        [EnumMember(Value = "Hot thick Water-rich")]
        HotThickWaterRich,

        [EnumMember(Value = "Hot thin Carbon dioxide")]
        HotThinCarbonDioxide,

        [EnumMember(Value = "Hot thin Metallic vapour")]
        HotThinMetallicVapour,

        [EnumMember(Value = "Hot thin Silicate vapour")]
        HotThinSilicateVapour,

        [EnumMember(Value = "Hot thin Sulphur dioxide")]
        HotThinSulphurDioxide,

        [EnumMember(Value = "Methane")]
        Methane,

        [EnumMember(Value = "Methane-rich")]
        MethaneRich,

        [EnumMember(Value = "Neon-rich")]
        NeonRich,

        [EnumMember(Value = "Nitrogen")]
        Nitrogen,

        [EnumMember(Value = "No atmosphere")]
        NoAtmosphere,

        [EnumMember(Value = "Oxygen")]
        Oxygen,

        [EnumMember(Value = "Suitable for water-based life")]
        SuitableForWaterBasedLife,

        [EnumMember(Value = "Sulphur dioxide")]
        SulphurDioxide,

        [EnumMember(Value = "Thick Ammonia")]
        ThickAmmonia,

        [EnumMember(Value = "Thick Ammonia and Oxygen")]
        ThickAmmoniaAndOxygen,

        [EnumMember(Value = "Thick Ammonia-rich")]
        ThickAmmoniaRich,

        [EnumMember(Value = "Thick Argon")]
        ThickArgon,

        [EnumMember(Value = "Thick Argon-rich")]
        ThickArgonRich,

        [EnumMember(Value = "Thick Carbon dioxide")]
        ThickCarbonDioxide,

        [EnumMember(Value = "Thick Carbon dioxide-rich")]
        ThickCarbonDioxideRich,

        [EnumMember(Value = "Thick Helium")]
        ThickHelium,

        [EnumMember(Value = "Thick Methane")]
        ThickMethane,

        [EnumMember(Value = "Thick Methane-rich")]
        ThickMethaneRich,

        [EnumMember(Value = "Thick Nitrogen")]
        ThickNitrogen,

        [EnumMember(Value = "Thick No atmosphere")]
        ThickNoAtmosphere,

        [EnumMember(Value = "Thick Suitable for water-based life")]
        ThickSuitableForWaterBasedLife,

        [EnumMember(Value = "Thick Sulphur dioxide")]
        ThickSulphurDioxide,

        [EnumMember(Value = "Thick Water")]
        ThickWater,

        [EnumMember(Value = "Thick Water-rich")]
        ThickWaterRich,

        [EnumMember(Value = "Thin Ammonia")]
        ThinAmmonia,

        [EnumMember(Value = "Thin Ammonia and Oxygen")]
        ThinAmmoniaAndOxygen,

        [EnumMember(Value = "Thin Ammonia-rich")]
        ThinAmmoniaRich,

        [EnumMember(Value = "Thin Argon")]
        ThinArgon,

        [EnumMember(Value = "Thin Argon-rich")]
        ThinArgonRich,

        [EnumMember(Value = "Thin Carbon dioxide")]
        ThinCarbonDioxide,

        [EnumMember(Value = "Thin Carbon dioxide-rich")]
        ThinCarbonDioxideRich,

        [EnumMember(Value = "Thin Helium")]
        ThinHelium,

        [EnumMember(Value = "Thin Methane")]
        ThinMethane,

        [EnumMember(Value = "Thin Methane-rich")]
        ThinMethaneRich,

        [EnumMember(Value = "Thin Neon")]
        ThinNeon,

        [EnumMember(Value = "Thin Neon-rich")]
        ThinNeonRich,

        [EnumMember(Value = "Thin Nitrogen")]
        ThinNitrogen,

        [EnumMember(Value = "Thin Oxygen")]
        ThinOxygen,

        [EnumMember(Value = "Thin Sulphur dioxide")]
        ThinSulphurDioxide,

        [EnumMember(Value = "Thin Water")]
        ThinWater,

        [EnumMember(Value = "Thin Water-rich")]
        ThinWaterRich,

        [EnumMember(Value = "Water")]
        Water,

        [EnumMember(Value = "Water-rich")]
        WaterRich
    }
}