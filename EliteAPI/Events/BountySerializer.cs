using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public static class BountySerializer    
    {
        public static string ToJson(this BountyInfo self) => JsonConvert.SerializeObject(self, JsonSettings.Settings);
    }
}