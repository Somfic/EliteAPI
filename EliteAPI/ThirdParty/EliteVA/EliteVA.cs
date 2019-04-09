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
        public static Guid VA_Id() => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}");

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
            EliteAPI.Logger.Log += Logger_Log;
            EliteAPI.Logger.UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            EliteAPI.Events.AllEvent += Events_AllEvent;

            //Create new Wrapper.
            Wrapper = new ThirdPartyWrapper(EliteAPI, VA_DisplayName());

            //Set the correct journal directory.
            DirectoryInfo newDirectory = Wrapper.GetJournalFolder("EliteVA.ini");
            if (newDirectory.FullName != EliteDangerousAPI.StandardDirectory.FullName) { EliteAPI.ChangeJournal(newDirectory); }


            //Start the API.
            EliteAPI.Start();
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
            EliteAPI.Logger.LogDebug("VoiceAttack is closing.");
            EliteAPI.Stop();
        }

        private static void SetVariables(List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                switch (v.Type)
                {
                    case Variable.VarType.Bool:
                        proxy.SetBoolean("EliteAPI." + v.Name, bool.Parse(v.Value.ToString()));
                        break;

                    case Variable.VarType.Decimal:
                        proxy.SetDecimal("EliteAPI." + v.Name, decimal.Parse(v.Value.ToString()));
                        break;

                    case Variable.VarType.String:
                        proxy.SetText("EliteAPI." + v.Name, v.Value.ToString());
                        break;

                    case Variable.VarType.Int:
                        proxy.SetInt("EliteAPI." + v.Name, int.Parse(v.Value.ToString()));
                        break;
                }
            }
        }

        private static void Logger_Log(object sender, Logging.LogMessage e)
        {
            switch (e.Severity)
            {
                case Logging.Severity.Error:
                    proxy.WriteToLog("EliteVA - " + e.Message, "red");
                    break;

                case Logging.Severity.Warning:
                    proxy.WriteToLog("EliteVA - " + e.Message, "orange");
                    break;

                case Logging.Severity.Success:
                    proxy.WriteToLog("EliteVA - " + e.Message, "green");
                    break;

                case Logging.Severity.Info:
                    proxy.WriteToLog("EliteVA - " + e.Message, "blue");
                    break;
            }
        }

        private static void Events_AllEvent(object sender, dynamic e)
        {
            string commandName = $"((EliteAPI.{Wrapper.GetEventName(e)}))";

            if (commandName.Contains("Status"))
            {
                //Set status variables.
                SetVariables(Wrapper.GetVariables());
            }

            if (proxy.CommandExists(commandName))
            {
                //Set event variables.
                SetVariables(Wrapper.GetEventVariables(e));
                proxy.ExecuteCommand(commandName);
            }
        }
    }
}