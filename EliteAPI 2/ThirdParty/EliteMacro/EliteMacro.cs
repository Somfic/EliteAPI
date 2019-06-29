using EliteAPI.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using vmAPI;

namespace EliteAPI.ThirdParty.EliteMacro
{
    public class EliteMacro : vmInterface
    {
        //VoiceMacro fields.
        public string DisplayName => "EliteMacro";
        public string Description => "EliteMacro by Somfic.";
        public string ID => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}").ToString();

        //EliteAPI fields.
        private static EliteDangerousAPI EliteAPI;
        private static ThirdPartyWrapper Wrapper;

        void vmInterface.Init()
        {
            //Create new EliteAPI.
            EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);

            //Create new Wrapper.
            Wrapper = new ThirdPartyWrapper(EliteAPI, DisplayName, $@"{vmCommand.GetDataDirectory()}\EliteMacro.ini");

            //Setup EliteAPI.
            EliteAPI.Logger.Log += Logger_Log;
            EliteAPI.Logger.UseLogFile(Wrapper.GetLogFolder().ToString());
            EliteAPI.ChangeJournal(Wrapper.GetJournalFolder());

            //Start the API.
            EliteAPI.Start();

            //Listen for events.
            EliteAPI.Events.AllEvent += Events_AllEvent;
        }

        void vmInterface.ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {
            Wrapper.ProcessCall(Param1);
        }

        void vmInterface.ProfileSwitched(string ProfileGUID, string ProfileName)
        {
        }

        void vmInterface.Dispose()
        {
            EliteAPI.Logger.LogDebug("VoiceMacro is closing.");
            EliteAPI.Stop();
        }

        private static void SetVariables(List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                try
                {
                    //Check if the variable isn't type unknown.
                    if (v.Type == Variable.VarType.Unknown) { EliteAPI.Logger.LogDebug($"Could not set VoiceMacro variable 'EliteAPI.{v.Name}_p' to {v.Value}.", new Exception("Type is unknown")); continue; }

                    //Check if the variable has actually changed.
                    if (vmCommand.GetVariable($"EliteAPI.{v.Name}_p") == v.Value.ToString()) { continue; }

                    //Change variable.
                    EliteAPI.Logger.LogDebug($"Set VoiceMacro variable 'EliteAPI.{v.Name}_p' to '{v.Value}'.");
                    vmCommand.SetVariable($"EliteAPI.{v.Name}_p", v.Value.ToString());
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.LogDebug($"Could not set variable {v.Name}.", ex);
                }
            }
        }

        private void Logger_Log(object sender, LogMessage e)
        {
            switch (e.Severity)
            {
                case Severity.Error:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Red, ID);
                    break;

                case Severity.Warning:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Orange, ID);
                    break;

                case Severity.Success:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Green, ID);
                    break;

                case Severity.Info:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Blue, ID);
                    break;
            }
        }

        private void Events_AllEvent(object sender, dynamic e)
        {
            if (!EliteAPI.IsReady) { return; }

            string commandName = $"((EliteAPI.{Wrapper.GetEventName(e)}))";

            if (commandName.Contains("Status"))
            {
                //Set status variables.
                SetVariables(Wrapper.GetVariables());
            }

            string macroGUID = vmCommand.CommandExists(commandName);
            if (macroGUID != null)
            {
                //Set event variables.
                EliteAPI.Logger.LogDebug($"Executing VoiceMacro command '{commandName}'.");
                SetVariables(Wrapper.GetEventVariables(e));
                vmCommand.ExecuteMacro(macroGUID);
            } else
            {
                EliteAPI.Logger.LogDebug($"VoiceMacro command '{commandName}' was not found, continuing.");
            }
        }
    }
}
