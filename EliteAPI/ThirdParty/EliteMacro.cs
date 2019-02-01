using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using EliteAPI.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using vmAPI;

namespace EliteAPI.ThirdParty
{
    public class EliteMacro : vmInterface
    {
        private static DirectoryInfo playerJournalDirectory;
        private static EliteDangerousAPI api;

        private static void SetJournalFolder()
        {
            if (!File.Exists("EliteMacro.ini"))
            {
                File.WriteAllText("EliteMacro.ini", "//Example" + Environment.NewLine);
                File.AppendAllText("EliteMacro.ini", @"//path=D:\Saved Games\Frontier Developments");
                playerJournalDirectory = EliteDangerousAPI.StandardDirectory;
            }
            else
            {
                try
                {
                    playerJournalDirectory = new DirectoryInfo(File.ReadAllLines("EliteMacro" +
                        ".ini").Where(x => !x.StartsWith("/")).First().Split(new string[] { "path=" }, StringSplitOptions.None)[1]);
                }
                catch { playerJournalDirectory = EliteDangerousAPI.StandardDirectory; }
            }
        }

        public string DisplayName => "EliteMacro";

        public string Description => "The EliteAPI plugin for VoiceMacro.";

        public string ID => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}").ToString();

        void vmInterface.Init()
        {
            SetJournalFolder();

            api = new EliteDangerousAPI(playerJournalDirectory, true);
            api.Logger.Log += Logger_Log;
            api.Events.AllEvent += EliteAPI_AllEvent;
            api.Start();
        }

        private void Logger_Log(object sender, LogMessage e)
        {
            switch (e.Severity)
            {
                case Logging.Severity.Error:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Red, ID);
                    break;

                case Logging.Severity.Warning:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Orange, ID);
                    break;

                case Logging.Severity.Success:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Green, ID);
                    break;

                default:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Blue, ID);
                    break;
            }
        }

        private void EliteAPI_AllEvent(object sender, dynamic e)
        {
            string eventName = "";

            try
            {
                eventName = "((EliteMarco." + e.@event + "))";

                if (vmCommand.CommandExists(eventName) == null)
                {
                    JObject attributesAsJObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(e));
                    Dictionary<string, object> values = attributesAsJObject.ToObject<Dictionary<string, object>>();

                    foreach (var key in values)
                    {
                        string type = key.Value.GetType().ToString().Replace("System.", "").Replace("Collections.Generic.", "").ToLower();
                        string name = key.Key;
                        string value = key.Value.ToString();

                        try
                        {
                            if (type.Contains("int")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("long")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("string")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("decimal")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("double")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("float")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("bool")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                        }
                        catch (Exception ex)
                        {
                            api.Logger.LogError($"There was an error while trying to parse field ['{name}' ({value})] for '{eventName}'. ({ex.Message})");
                        }
                    }
                    vmCommand.ExecuteMacro(eventName);
                }
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while invoking the event '{eventName}'. ({ex.Message})");
            }
        }

        void vmInterface.Dispose()
        {
            api.Logger.LogSuccess("Stopping EliteMacro.");
            api.Stop();
        }

        void vmInterface.ProfileSwitched(string ProfileGUID, string ProfileName)
        {
            //throw new NotImplementedException();
        }

        void vmInterface.ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {
            try
            {
                string command = Param1.ToLower();

                if (command == "updatejournal")
                {
                    SetJournalFolder();
                    api = new EliteDangerousAPI(playerJournalDirectory);
                }
                else if (command == "drp on")
                {
                    api.DiscordRichPresence.TurnOn();
                }
                else if (command == "drp off")
                {
                    api.DiscordRichPresence.TurnOn();
                }
            }
            catch { }

            try
            {
                var status = api.Status;
                var commander = api.Commander;
                var location = api.Location;

                vmCommand.SetVariable("EliteAPI.DOCKED_p", status.Docked.ToString().ToString());
                vmCommand.SetVariable("EliteAPI.LANDED_p", status.Landed.ToString());
                vmCommand.SetVariable("EliteAPI.GEAR_p", status.Gear.ToString());
                vmCommand.SetVariable("EliteAPI.SHIELDS_p", status.Shields.ToString());
                vmCommand.SetVariable("EliteAPI.SUPERCRUISE_p", status.Supercruise.ToString());
                vmCommand.SetVariable("EliteAPI.FLIGHTASSIST_p", status.FlightAssist.ToString());
                vmCommand.SetVariable("EliteAPI.HARDPOINTS_p", status.Hardpoints.ToString());
                vmCommand.SetVariable("EliteAPI.WINGING_p", status.Winging.ToString());
                vmCommand.SetVariable("EliteAPI.LIGHTS_p", status.Lights.ToString());
                vmCommand.SetVariable("EliteAPI.CARGOSCOOP_p", status.CargoScoop.ToString());
                vmCommand.SetVariable("EliteAPI.SILENTRUNNING_p", status.SilentRunning.ToString());
                vmCommand.SetVariable("EliteAPI.SCOOPING_p", status.Scooping.ToString());
                vmCommand.SetVariable("EliteAPI.SRVHANDBREAK_p", status.SrvHandbreak.ToString());
                vmCommand.SetVariable("EliteAPI.SRVTURRENT_p", status.SrvTurrent.ToString());
                vmCommand.SetVariable("EliteAPI.SRVNEARSHIP_p", status.SrvNearShip.ToString());
                vmCommand.SetVariable("EliteAPI.SRVDRIVEASSIST_p", status.SrvDriveAssist.ToString());
                vmCommand.SetVariable("EliteAPI.MASSLOCKED_p", status.MassLocked.ToString());
                vmCommand.SetVariable("EliteAPI.FSDCHARGING_p", status.FsdCooldown.ToString());
                vmCommand.SetVariable("EliteAPI.FSDCOOLDOWN_p", status.FsdCooldown.ToString());
                vmCommand.SetVariable("EliteAPI.LOWFUEL_p", status.LowFuel.ToString());
                vmCommand.SetVariable("EliteAPI.OVERHEATING_p", status.Overheating.ToString());
                vmCommand.SetVariable("EliteAPI.HASLATLONG_p", status.HasLatlong.ToString());
                vmCommand.SetVariable("EliteAPI.INDANGER_p", status.InDanger.ToString());
                vmCommand.SetVariable("EliteAPI.ININTERDICTION_p", status.InInterdiction.ToString());
                vmCommand.SetVariable("EliteAPI.INMOTHERSHIP_p", status.InMothership.ToString());
                vmCommand.SetVariable("EliteAPI.INNOFIREZONE_p", status.InNoFireZone.ToString());
                vmCommand.SetVariable("EliteAPI.INFIGHTER_p", status.InFighter.ToString());
                vmCommand.SetVariable("EliteAPI.INSRV_p", status.InSRV.ToString());
                vmCommand.SetVariable("EliteAPI.ANALYSISMODE_p", status.AnalysisMode.ToString());
                vmCommand.SetVariable("EliteAPI.NIGHTVISION_p", status.NightVision.ToString());
                vmCommand.SetVariable("EliteAPI.Pips.SYSTEMS_p", status.Pips[0].ToString());
                vmCommand.SetVariable("EliteAPI.Pips.ENGINES_p", status.Pips[1].ToString());
                vmCommand.SetVariable("EliteAPI.Pips.WEAPONS_p", status.Pips[2].ToString());
                vmCommand.SetVariable("EliteAPI.FIREGROUP_p", status.FireGroup.ToString());
                vmCommand.SetVariable("EliteAPI.GUIFOCUS_p", status.GuiFocus.ToString());
                vmCommand.SetVariable("EliteAPI.FUEL_p", status.Fuel.FuelMain.ToString());
                vmCommand.SetVariable("EliteAPI.FUELRESERVOIR_p", status.Fuel.FuelReservoir.ToString());
                vmCommand.SetVariable("EliteAPI.CARGO_p", status.Cargo.ToString());

                vmCommand.SetVariable("EliteAPI.Commander_p", commander.Commander);
                vmCommand.SetVariable("EliteAPI.System_p", location.StarSystem);
                vmCommand.SetVariable("EliteAPI.Body_p", location.Body);
                vmCommand.SetVariable("EliteAPI.BodyType_p", location.BodyType);

                vmCommand.SetVariable("EliteAPI.Rank.Combat_p", commander.CombatRankLocalised);
                vmCommand.SetVariable("EliteAPI.Rank.Trade_p", commander.TradeRankLocalised);
                vmCommand.SetVariable("EliteAPI.Rank.Exploration_p", commander.ExplorationRankLocalised);
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while setting some of the status variables. ({ex.Message}) (Make sure the game is running.)");
            }
        }
    }
}
