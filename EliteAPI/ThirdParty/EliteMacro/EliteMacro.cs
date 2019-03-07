using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using EliteAPI.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            EliteAPI.Logger.UseLogFile(new DirectoryInfo(vmCommand.GetDataDirectory()));
            EliteAPI.Logger.Log += Logger_Log;
            EliteAPI.Events.AllEvent += Events_AllEvent;

            //Create new Wrapper.
            Wrapper = new ThirdPartyWrapper(EliteAPI, DisplayName);

            //Set the correct journal directory.
            EliteAPI.ChangeJournal(Wrapper.GetJournalFolder("EliteMacro.ini"));

            //Start the API.
            EliteAPI.Start();
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
            EliteAPI.Logger.LogSuccess("Stopping VoiceMacro");
            EliteAPI.Stop();
        }

        private static void SetVariables(List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                if(v.Type == Variable.VarType.Unknown) { continue; }
                vmCommand.SetVariable($"EliteAPI.{v.Name}_p", v.Value.ToString());
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
                SetVariables(Wrapper.GetEventVariables(e));
                vmCommand.ExecuteMacro(macroGUID);
            }
        }
    }
}
