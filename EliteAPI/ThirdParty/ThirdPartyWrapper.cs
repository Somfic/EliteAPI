using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Somfic.Logging;

namespace EliteAPI.ThirdParty
{

    /// <summary>
    /// Class that functions as a wrapper for third party plugins.
    /// </summary>
    public class ThirdPartyWrapper
    {
        private static EliteDangerousAPI EliteAPI;
        private readonly string iniPath;
        public IniParser Ini;

        /// <summary>
        /// Creates a new ThirdPartyWrapper object.
        /// </summary>
        /// <param name="api">The EliteDangerousAPI api</param>
        /// <param name="name">The name of the plugin</param>
        /// <param name="iniPath">The path to the configuration file</param>
        public ThirdPartyWrapper(EliteDangerousAPI api, string name, string iniPath)
        {
            EliteAPI = api;
            EliteAPI.Logger.Log(Severity.Debug, $"Enabled third party wrapper for {name}.");
            this.iniPath = iniPath;
            Ini = new IniParser(EliteAPI.Logger, iniPath);
        }

        /// <summary>
        /// Returns all the variables to be set.
        /// </summary>
        /// <returns>A list of variables</returns>
        public List<Variable> GetVariables()
        {
            List<Variable> variables = new List<Variable>
            {
                //Add version variable.
                new Variable("Version", EliteDangerousAPI.Version)
            };
            variables.AddRange(from f in EliteAPI.Commander.GetType().GetProperties() where f.Name != "Statistics" select new Variable(f.Name, f.GetValue(EliteAPI.Commander)));
            //Add commander variables.
            //Add location variables.
            variables.AddRange(EliteAPI.Location.GetType().GetProperties().Select(f => new Variable(f.Name, f.GetValue(EliteAPI.Location))));
            //Add status variables.
            foreach (PropertyInfo f in EliteAPI.Status.GetType().GetProperties())
            {
                //Do not add Timestamp and Event variables.
                if (f.Name == "Timestamp" || f.Name == "Event") { continue; }
                //Do not try to output an array for pips, rather output the pips separate.
                if (f.Name == "Pips")
                {
                    variables.Add(new Variable("Pips.Systems", EliteAPI.Status.Pips[0]));
                    variables.Add(new Variable("Pips.Engines", EliteAPI.Status.Pips[1]));
                    variables.Add(new Variable("Pips.Weapons", EliteAPI.Status.Pips[2]));
                    continue;
                }
                //Do not try to output an object for fuel, rather output the fields separate.
                else if (f.Name == "Fuel")
                {
                    variables.Add(new Variable("Fuel.Main", EliteAPI.Status.Fuel.FuelMain));
                    variables.Add(new Variable("Fuel.Reservoir", EliteAPI.Status.Fuel.FuelReservoir));
                    variables.Add(new Variable("Fuel.Max", EliteAPI.Status.Fuel.MaxFuel));
                    continue;
                }
                else
                {
                    variables.Add(new Variable(f.Name, f.GetValue(EliteAPI.Status)));
                }
            }
            return variables;
        }

        /// <summary>
        /// Gets all the variables to be set from an event.
        /// </summary>
        /// <param name="e">A list of variables</param>
        /// <returns></returns>
        public List<Variable> GetEventVariables(dynamic e)
        {
            List<Variable> variables = new List<Variable>();
            //Change to a dictionary of variables.
            JObject attributesAsJObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(e));
            Dictionary<string, object> values = attributesAsJObject.ToObject<Dictionary<string, object>>();
            //Get the event name.
            string eventName = GetEventName(e);
            foreach (KeyValuePair<string, object> key in values)
            {
                string type = key.Value.GetType().ToString().Replace("System.", "").Replace("Collections.Generic.", "").ToLower();
                string name = key.Key;
                string value = key.Value.ToString();
                try
                {
                    if (type.Contains("int")) { variables.Add(new Variable("Event." + name, int.Parse(value))); }
                    else if (type.Contains("long")) { variables.Add(new Variable("Event." + name, int.Parse(value))); }
                    else if (type.Contains("string")) { variables.Add(new Variable("Event." + name, value)); }
                    else if (type.Contains("double")) { variables.Add(new Variable("Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("float")) { variables.Add(new Variable("Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("bool")) { variables.Add(new Variable("Event." + name, bool.Parse(value))); }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.Log(Severity.Error, $"There was an error while trying to parse field [{name} ('{value}')] for event '{eventName}'.", ex);
                }
            }
            return variables;
        }

        /// <summary>
        /// Gets the name from an event.
        /// </summary>
        /// <param name="e">The name of the event.</param>
        /// <returns></returns>
        public string GetEventName(dynamic e)
        {
            //Get the event name.
            string eventName = e.@event;
            return !string.IsNullOrWhiteSpace(eventName) ? eventName : (string) e.Event;
        }

        /// <summary>
        /// Processes third party plugin functions
        /// </summary>
        /// <param name="content"></param>
        public void ProcessCall(string content)
        {
            try
            {
                switch (content)
                {
                    case "drp on":
                        EliteAPI.DiscordRichPresence.TurnOn();
                        return;
                    case "drp off":
                        EliteAPI.DiscordRichPresence.TurnOff();
                        return;
                }
            }
            catch (Exception ex) { EliteAPI.Logger.Log(Severity.Warning, $"There was a problem while trying to process '{content}'.", ex); }
        }
    }
}
