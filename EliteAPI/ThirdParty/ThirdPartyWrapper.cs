using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EliteAPI.ThirdParty
{
    public class ThirdPartyWrapper
    {
        private static EliteDangerousAPI EliteAPI;

        public ThirdPartyWrapper(EliteDangerousAPI api, string name)
        {
            EliteAPI = api;
        }

        public List<Variable> GetVariables()
        {
            List<Variable> variables = new List<Variable>
            {

                //Add version variable.
                new Variable("Version", EliteAPI.Version)
            };

            //Add commander variables.
            foreach (PropertyInfo f in EliteAPI.Commander.GetType().GetProperties())
            {
                //Do not add statistics variables.
                if (f.Name == "Statistics") { continue; }

                variables.Add(new Variable(f.Name, f.GetValue(EliteAPI.Commander)));
            }

            //Add location variables.
            foreach (PropertyInfo f in EliteAPI.Location.GetType().GetProperties())
            {
                variables.Add(new Variable(f.Name, f.GetValue(EliteAPI.Location)));
            }

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
                if (f.Name == "Fuel")
                {
                    variables.Add(new Variable("Fuel.Main", EliteAPI.Status.Fuel.FuelMain));
                    variables.Add(new Variable("Fuel.Reservoir", EliteAPI.Status.Fuel.FuelReservoir));
                    variables.Add(new Variable("Fuel.Max", EliteAPI.Status.Fuel.MaxFuel));
                    continue;
                }

                variables.Add(new Variable(f.Name, f.GetValue(EliteAPI.Status)));
            }

            return variables;
        }

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
                    else if (type.Contains("long")) { variables.Add(new Variable("EliteAPI.Event." + name, int.Parse(value))); }
                    else if (type.Contains("string")) { variables.Add(new Variable("EliteAPI.Event." + name, value)); }
                    else if (type.Contains("decimal")) { variables.Add(new Variable("EliteAPI.Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("double")) { variables.Add(new Variable("EliteAPI.Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("float")) { variables.Add(new Variable("EliteAPI.Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("bool")) { variables.Add(new Variable("EliteAPI.Event." + name, bool.Parse(value))); }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.LogError($"There was an error while trying to parse field ['{name}' ({value})] for '{eventName}'.", ex);
                }
            }

            return variables;
        }

        public string GetEventName(dynamic e)
        {
            //Set the event name.
            return e.@Event;
        }

        public DirectoryInfo GetJournalFolder(string iniFilePath)
        {
            EliteAPI.Logger.LogDebug($"Looking for '{iniFilePath}'.");
            if (!File.Exists(iniFilePath))
            {
                EliteAPI.Logger.LogDebug($"Could not find '{iniFilePath}'.");
                File.WriteAllText(iniFilePath, "//Use this to set a custom path to your Journal directory." + Environment.NewLine);
                File.AppendAllText(iniFilePath, $"path={EliteDangerousAPI.StandardDirectory}");
                return EliteDangerousAPI.StandardDirectory;
            }
            else
            {
                try
                {
                    if (File.ReadAllLines(iniFilePath).Count(x => !x.StartsWith("/")) == 0) { EliteAPI.Logger.LogDebug($"Found '{iniFilePath}', but no custom directory has been set."); return EliteDangerousAPI.StandardDirectory; }
                    string path = File.ReadAllLines(iniFilePath).Where(x => !x.StartsWith("/")).First().Split(new string[] { "path=" }, StringSplitOptions.None)[1];
                    if (path == EliteDangerousAPI.StandardDirectory.FullName) { EliteAPI.Logger.LogDebug($"Found '{iniFilePath}', but it doesn't contain a custom directory."); return EliteDangerousAPI.StandardDirectory; }
                    if (Directory.Exists(path)) { EliteAPI.Logger.LogDebug($"Found '{iniFilePath}'."); return new DirectoryInfo(path); }
                    else { EliteAPI.Logger.LogWarning($"Found '{iniFilePath}', but the path is invalid ('{path}')."); return EliteDangerousAPI.StandardDirectory; }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.LogWarning($"Could not read from '{iniFilePath}'.", ex);
                    return EliteDangerousAPI.StandardDirectory;
                }
            }
        }

        public void ProcessCall(string content)
        {
            try
            {
                content = content.ToString();

                if (content == "drp on")
                {
                    EliteAPI.DiscordRichPresence.TurnOn();
                    return;
                }
                else if (content == "drp off")
                {
                    EliteAPI.DiscordRichPresence.TurnOff();
                    return;
                }
            }
            catch (Exception ex) { EliteAPI.Logger.LogWarning($"There was a problem while trying to process '{content}'.", ex); }
        }
    }
    public class Variable
    {
        public Variable(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public enum VarType { String, Bool, Int, Decimal, Unknown }

        public string Name { get; }
        public object Value { get; }
        public VarType Type => GetVarType(Value);

        private VarType GetVarType(object s)
        {
            try
            {
                string type = s.GetType().ToString().Replace("System.", "").Replace("Collections.Generic.", "").ToLower();
                if (type.Contains("int")) { return VarType.Int; }
                else if (type.Contains("long")) { return VarType.Int; }
                else if (type.Contains("string")) { return VarType.String; }
                else if (type.Contains("decimal")) { return VarType.Decimal; }
                else if (type.Contains("double")) { return VarType.Decimal; }
                else if (type.Contains("float")) { return VarType.Decimal; }
                else if (type.Contains("bool")) { return VarType.Bool; }
                else { return VarType.Unknown; }
            }
            catch { return VarType.Unknown; }
        }
    }
}
