using System;
using System.Collections.Generic;
using System.IO;
using Somfic.Logging;
using Somfic.Logging.Handlers;

namespace EliteAPI.ThirdParty.EliteVA
{
    public class VAPlugin
    {
        private static VoiceAttackHandler vaHandler;

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
            EliteAPI.Logger.AddHandler(new LogFileHandler(Wrapper.Ini.GetLoggingPath(), "EliteAPI"));
            vaHandler = new VoiceAttackHandler("EliteVA");
            EliteAPI.Logger.AddHandler(vaHandler);
            EliteAPI.ChangeJournal(Wrapper.Ini.GetJournalDirectory());
            //Start the API.
            EliteAPI.Start(Wrapper.Ini.GetRichPresenceSetting());
            SetVariables(Wrapper.GetVariables());
            //Listen for events.
            EliteAPI.Events.AllEvent += Events_AllEvent;
        }
        public static void VA_Invoke1(dynamic vaProxy)
        {
            proxy = vaProxy;
            vaHandler.UpdateProxy(vaProxy);
            Wrapper.ProcessCall(proxy.Context.ToString());
        }
        public static void VA_StopCommand()
        {
        }
        public static void VA_Exit1(dynamic vaProxy)
        {
            proxy = vaProxy;
            vaHandler.UpdateProxy(vaProxy);
            EliteAPI.Logger.Log(Severity.Debug, "VoiceAttack is closing.");
            EliteAPI.Stop();
        }
        private static void SetVariables(List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                try
                {
                    //Check if the variable isn't type unknown.
                    if (v.Type == VarType.Unknown) { EliteAPI.Logger.Log(Severity.Debug, $"Could not set VoiceAttack variable 'EliteAPI.{v.Name}' to {v.Value}.", new ArgumentException("Type is unknown.", v.Name)); continue; }
                    switch (v.Type)
                    {
                        case VarType.Bool:
                            if (proxy.GetBoolean("EliteAPI." + v.Name) == bool.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Log(Severity.Debug, $"Set VoiceAttack bool 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetBoolean("EliteAPI." + v.Name, bool.Parse(v.Value.ToString()));
                            break;
                        case VarType.Decimal:
                            if (proxy.GetDecimal("EliteAPI." + v.Name) == decimal.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Log(Severity.Debug, $"Set VoiceAttack decimal 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetDecimal("EliteAPI." + v.Name, decimal.Parse(v.Value.ToString()));
                            break;
                        case VarType.String:
                            if (proxy.GetText("EliteAPI." + v.Name) == v.Value.ToString()) { continue; }
                            EliteAPI.Logger.Log(Severity.Debug, $"Set VoiceAttack text 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetText("EliteAPI." + v.Name, v.Value.ToString());
                            break;
                        case VarType.Int:
                            if (proxy.GetInt("EliteAPI." + v.Name) == int.Parse(v.Value.ToString())) { continue; }
                            EliteAPI.Logger.Log(Severity.Debug, $"Set VoiceAttack int 'EliteAPI.{v.Name}' to '{v.Value}'.");
                            proxy.SetInt("EliteAPI." + v.Name, int.Parse(v.Value.ToString()));
                            break;
                    }
                }
                catch(Exception ex)
                {
                    EliteAPI.Logger.Log(Severity.Debug, $"Could not set variable {v.Name}.", ex);
                }
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
                EliteAPI.Logger.Log(Severity.Debug, $"Executing VoiceAttack command '{commandName}'.");
                SetVariables(Wrapper.GetEventVariables(e));
                proxy.ExecuteCommand(commandName);
            } else
            {
                EliteAPI.Logger.Log(Severity.Debug, $"VoiceAttack command '{commandName}' was not found, continuing.");
            }
        }
    }
}