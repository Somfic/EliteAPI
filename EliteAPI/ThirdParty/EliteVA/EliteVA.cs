using System;
using System.Collections.Generic;
using System.IO;
namespace EliteAPI.ThirdParty.EliteVA
{
    public class VAPlugin
    {
        //VoiceAttack fields.
        public static string VA_DisplayName() => "EliteVA";
        public static string VA_DisplayInfo() => "EliteVA by Somfic.";
        public static Guid VA_Id() => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB66}");
        //Private VoiceAttack fields.
        private static dynamic proxy;
        //EliteAPI fields.
        private static EliteDangerousAPI EliteAPI;
        private static ThirdPartyWrapper Wrapper;
        public static void VA_Init1(dynamic vaProxy)
        {
            proxy = vaProxy;
            //Create new EliteAPI.
            EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            //Create new Wrapper.
            Wrapper = new ThirdPartyWrapper(EliteAPI, VA_DisplayName(), $@"{Directory.GetCurrentDirectory()}\EliteVA.ini");
            //Setup EliteAPI.
            EliteAPI.Logger.LogEvent += Logger_Log;
            EliteAPI.Logger.UseLogFile(Wrapper.GetLogFolder().ToString(), "EliteAPI");
            EliteAPI.ChangeJournal(Wrapper.GetJournalFolder());
            //Start the API.
            EliteAPI.Start(Wrapper.GetRichPresenceSetting());
            //Listen for events.
            EliteAPI.Events.AllEvent += Events_AllEvent;
        }
        public static void VA_Invoke1(dynamic vaProxy)
        {
            proxy = vaProxy;
            Wrapper.ProcessCall(proxy.Context.ToString());
        }
        public static void VA_StopCommand()
        {
        }
        public static void VA_Exit1(dynamic vaProxy)
        {
            proxy = vaProxy;
            EliteAPI.Logger.Debug("VoiceAttack is closing.");
            EliteAPI.Stop();
        }
        private static void SetVariables(List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                try
                {
                    //Check if the variable isn't type unknown.
                    if (v.Type == Variable.VarType.Unknown) { EliteAPI.Logger.Debug($"Could not set VoiceAttack variable 'EliteAPI.{v.Name}' to {v.Value}.", new Exception("Type is unknown")); continue; }
                    switch (v.Type)
                    {
                        case Variable.VarType.Bool:
                            if (proxy.GetBoolean("EliteAPI." + v.Name) == bool.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Debug($"Set VoiceAttack bool 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetBoolean("EliteAPI." + v.Name, bool.Parse(v.Value.ToString()));
                            break;
                        case Variable.VarType.Decimal:
                            if (proxy.GetDecimal("EliteAPI." + v.Name) == decimal.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Debug($"Set VoiceAttack decimal 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetDecimal("EliteAPI." + v.Name, decimal.Parse(v.Value.ToString()));
                            break;
                        case Variable.VarType.String:
                            if (proxy.GetText("EliteAPI." + v.Name) == v.Value.ToString()) { continue; }
                            EliteAPI.Logger.Debug($"Set VoiceAttack text 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetText("EliteAPI." + v.Name, v.Value.ToString());
                            break;
                        case Variable.VarType.Int:
                            if (proxy.GetInt("EliteAPI." + v.Name) == int.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Debug($"Set VoiceAttack int 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetInt("EliteAPI." + v.Name, int.Parse(v.Value.ToString()));
                            break;
                    }
                }
                catch(Exception ex)
                {
                    EliteAPI.Logger.Debug($"Could not set variable {v.Name}.", ex);
                }
            }
        }
        private static void Logger_Log(object sender, Somfic.Logging.LogMessage e)
        {
            switch (e.Severity)
            {
                case Somfic.Logging.Severity.Error:
                    proxy.WriteToLog("EliteVA - " + e.Message, "red");
                    break;
                case Somfic.Logging.Severity.Warning:
                    proxy.WriteToLog("EliteVA - " + e.Message, "orange");
                    break;
                case Somfic.Logging.Severity.Success:
                    proxy.WriteToLog("EliteVA - " + e.Message, "green");
                    break;
                case Somfic.Logging.Severity.Info:
                    proxy.WriteToLog("EliteVA - " + e.Message, "blue");
                    break;
            }
        }
        private static void Events_AllEvent(object sender, dynamic e)
        {
            if(!EliteAPI.IsReady) { return; }
            string commandName = $"((EliteAPI.{Wrapper.GetEventName(e)}))";
            if (commandName.Contains("Status"))
            {
                //Set status variables.
                SetVariables(Wrapper.GetVariables());
            }
            if (proxy.CommandExists(commandName))
            {
                //Set event variables.
                EliteAPI.Logger.Debug($"Executing VoiceAttack command '{commandName}'.");
                SetVariables(Wrapper.GetEventVariables(e));
                proxy.ExecuteCommand(commandName);
            } else
            {
                EliteAPI.Logger.Debug($"VoiceAttack command '{commandName}' was not found, continuing.");
            }
        }
    }
}