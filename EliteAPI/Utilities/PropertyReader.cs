using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Somfic.Logging;

namespace EliteAPI.Utilities
{
    public static class PropertyReader
    {
        public static string[] GetAllChildren(JObject obj, string prefix = "")
        {
            List<string> items = new List<string>();

            obj.Properties().ToList().ForEach(prop =>
            {
                string name = prop.Name.Replace("_", "");

                switch (prop.Value.Type)
                {
                    case JTokenType.Object:
                        items.Add($"{prefix}.{name}.*");
                        GetAllChildren(JObject.FromObject(prop.Value), $"{prefix}.{name}").ToList()
                            .ForEach(x => items.Add(x));
                        break;
                    case JTokenType.Array:
                        items.Add($"{prefix}.{name}.#");

                        // If the array isn't empty, expand the array.
                        if (prop.Value.HasValues && (prop.Value.First.Type == JTokenType.Array || prop.Value.First.Type == JTokenType.Object))
                        {
                            GetAllChildren(JObject.FromObject(prop.Value.First), $"{prefix}.{name}").ToList()
                                .ForEach(x => items.Add(x));
                        }

                        break;
                    default:
                        items.Add($"{prefix}.{name}");
                        break;
                }
            });

            return items.ToArray();
        }
    }
}
