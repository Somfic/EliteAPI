using System;
using System.Collections.Generic;
using System.Linq;
using EliteAPI.Dashboard.Controllers.EliteVA;
using EliteAPI.Dashboard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Dashboard.Services
{
    public class VariableService
    {
        private readonly ILogger<VariableService> _log;

        public VariableService(ILogger<VariableService> log)
        {
            _log = log;
        }

        public List<Variable> GetVariables(object value)
        {
            var jToken = JToken.Parse(JsonConvert.SerializeObject(value, new JsonSerializerSettings {ContractResolver = new JsonContractResolver()}));
            return jToken.Type == JTokenType.Array ? GetPaths(jToken as JArray) : GetPaths(jToken as JObject);
        }

        private List<Variable> GetPaths(JObject jObject)
        {
            try
            {
                return jObject.Properties().SelectMany(GetPaths).ToList();
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Cannot get event variable paths (object)");
                return new List<Variable>();
            }
        }

        private List<Variable> GetPaths(JArray jArray)
        {
            try
            {
                return jArray.Values<JObject>().SelectMany(x => x.Properties().SelectMany(GetPaths)).ToList();
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Cannot get event variable paths (array)");
                return new List<Variable>();
            }
        }

        private List<Variable> GetPaths(JProperty property)
        {
            try
            {
                switch (property.Value.Type)
                {
                    case JTokenType.Object:
                        return property.Value.Children<JProperty>().SelectMany(GetPaths).ToList();

                    case JTokenType.Array:
                        return property.Value.Values<JObject>().SelectMany(GetPaths).ToList();

                    case JTokenType.Boolean:
                        return new List<Variable>
                            {new(property.Value.Path, property.Value.ToObject<bool>())};

                    case JTokenType.String:
                        return new List<Variable>
                            {new(property.Value.Path, property.Value.ToObject<string>())};

                    case JTokenType.Date:
                        return new List<Variable>
                            {new(property.Value.Path, property.Value.ToObject<DateTime>())};

                    case JTokenType.Integer:
                        try
                        {
                            return new List<Variable>
                                {new(property.Value.Path, property.Value.ToObject<int>())};
                        }
                        catch (OverflowException)
                        {
                            return new List<Variable>
                                {new(property.Value.Path, property.Value.ToObject<long>())};
                        }

                    case JTokenType.Float:
                        return new List<Variable>
                            {new(property.Value.Path, property.Value.ToObject<decimal>())};

                    default:
                        return new List<Variable>();
                }
            }
            catch (InvalidCastException ex)
            {
                _log.LogDebug(ex, "Could not process {Path}", property.Value.Path);
                return new List<Variable>();
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not process {Path}", property.Value.Path);
                return new List<Variable>();
            }
        }
    }
}