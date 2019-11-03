using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace EliteAPI.ThirdParty
{
    public class ThirdPartyWrapper
    {
        private static EliteDangerousAPI EliteAPI;
        private readonly string iniPath;
        public ThirdPartyWrapper(EliteDangerousAPI api, string name, string iniPath)
        {
            EliteAPI = api;
            EliteAPI.Logger.Debug($"Enabled third party wrapper for {name}.");
            this.iniPath = iniPath;
            try
            {
                if (File.ReadAllLines(iniPath)[0] == "//Use this to set a custom path to your Journal directory.")
                {
                    File.Delete(iniPath);
                }
            }
            catch { }
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
        public bool GetRichPresenceSetting()
        {
            try
            {
                string value = GetIni()["DISCORD"]["richPresene"].ToLower();
                return value == "on" || value == "true" || value == "yes";
            }
            catch { return true; }
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
                    else if (type.Contains("long")) { variables.Add(new Variable("Event." + name, int.Parse(value))); }
                    else if (type.Contains("string")) { variables.Add(new Variable("Event." + name, value)); }
                    else if (type.Contains("double")) { variables.Add(new Variable("Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("float")) { variables.Add(new Variable("Event." + name, decimal.Parse(value))); }
                    else if (type.Contains("bool")) { variables.Add(new Variable("Event." + name, bool.Parse(value))); }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.Error($"There was an error while trying to parse field [{name} ('{value}')] for event '{eventName}'.", ex);
                }
            }
            return variables;
        }
        public string GetEventName(dynamic e)
        {
            //Get the event name.
            string eventName = e.@event;
            if (!string.IsNullOrWhiteSpace(eventName)) { return eventName; }
            else { return e.@Event; }
        }
        public IniData GetIni()
        {
            FileIniDataParser parser = new FileIniDataParser();
            //If the ini file does not exist, create a new one.
            if (!File.Exists(iniPath))
            {
                IniData ini = new IniData();
                ini["ELITEAPI"]["path"] = EliteDangerousAPI.StandardDirectory.ToString();
                ini["LOGGING"]["path"] = Directory.GetCurrentDirectory();
                ini["DISCORD"]["richPresene"] = "on";
                parser.WriteFile(iniPath, ini);
            }
            else
            {
                EliteAPI.Logger.Debug($"Reading custom configuration from '{iniPath}'.");
            }
            return parser.ReadFile(iniPath);
        }
        public DirectoryInfo GetJournalFolder()
        {
            try
            {
                string path = GetIni()["ELITEAPI"]["path"];
                if (path == EliteDangerousAPI.StandardDirectory.FullName) { EliteAPI.Logger.Debug($"Using default path."); return EliteDangerousAPI.StandardDirectory; }
                else if (Directory.Exists(path)) { EliteAPI.Logger.Debug($"Found '{path}'."); return new DirectoryInfo(path); }
                else { EliteAPI.Logger.Warning($"Found '{path}', but the path is invalid, using default path."); return EliteDangerousAPI.StandardDirectory; }
            }
            catch (Exception ex)
            {
                EliteAPI.Logger.Warning($"Could not read from '{iniPath}', using default Journal path.", ex);
                return EliteDangerousAPI.StandardDirectory;
            }
        }
        public DirectoryInfo GetLogFolder()
        {
            try
            {
                string path = GetIni()["LOGGING"]["path"];
                if (Directory.Exists(path)) { EliteAPI.Logger.Debug($"Using '{path}' for logging."); return new DirectoryInfo(path); }
                else { EliteAPI.Logger.Warning($"Found '{path}' for logging, but the path is invalid, using '{Directory.GetCurrentDirectory()}' instead."); return new DirectoryInfo(Directory.GetCurrentDirectory()); }
            }
            catch (Exception ex)
            {
                EliteAPI.Logger.Warning($"Could not read from '{iniPath}', using '{Directory.GetCurrentDirectory()}' for logging.", ex);
                return new DirectoryInfo(Directory.GetCurrentDirectory());
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
            catch (Exception ex) { EliteAPI.Logger.Warning($"There was a problem while trying to process '{content}'.", ex); }
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
