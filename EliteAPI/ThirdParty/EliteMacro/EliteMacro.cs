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

            api = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, true);
            api.Logger.UseLogFile(new DirectoryInfo(vmCommand.GetDataDirectory()));
            api.Logger.Log += Logger_Log;
            api.Events.AllEvent += EliteAPI_AllEvent;
            api.Start();
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

        private void EliteAPI_AllEvent(object sender, dynamic e)
        {
            string eventName = "";

            try
            {
                eventName = "((EliteAPI." + e.@event + "))";
                string macroName = vmCommand.CommandExists(eventName);

                if (eventName.Contains("Status"))
                {
                    try
                    {
                        var status = api.Status;
                        var commander = api.Commander;
                        var location = api.Location;

                        SetVar("EliteAPI.Docked_p", status.Docked.ToString());
                        SetVar("EliteAPI.Landed_p", status.Landed.ToString());
                        SetVar("EliteAPI.Gear_p", status.Gear.ToString());
                        SetVar("EliteAPI.Shields_p", status.Shields.ToString());
                        SetVar("EliteAPI.Supercruise_p", status.Supercruise.ToString());
                        SetVar("EliteAPI.FlightAssist_p", status.FlightAssist.ToString());
                        SetVar("EliteAPI.Hardpoints_p", status.Hardpoints.ToString());
                        SetVar("EliteAPI.Winging_p", status.Winging.ToString());
                        SetVar("EliteAPI.Lights_p", status.Lights.ToString());
                        SetVar("EliteAPI.CargoScoop_p", status.CargoScoop.ToString());
                        SetVar("EliteAPI.SilentRunning_p", status.SilentRunning.ToString());
                        SetVar("EliteAPI.Scooping_p", status.Scooping.ToString());
                        SetVar("EliteAPI.SrvHandbreak_p", status.SrvHandbreak.ToString());
                        SetVar("EliteAPI.SrvTurrent_p", status.SrvTurrent.ToString());
                        SetVar("EliteAPI.SrvNearShip_p", status.SrvNearShip.ToString());
                        SetVar("EliteAPI.SrvDriveAssist_p", status.SrvDriveAssist.ToString());
                        SetVar("EliteAPI.SrvDriveAssist_p", status.SrvDriveAssist.ToString());
                        SetVar("EliteAPI.FsdCharging_p", status.FsdCharging.ToString());
                        SetVar("EliteAPI.FsdCooldown_p", status.FsdCooldown.ToString());
                        SetVar("EliteAPI.LowFuel_p", status.LowFuel.ToString());
                        SetVar("EliteAPI.Overheating_p", status.Overheating.ToString());
                        SetVar("EliteAPI.HasLatlong_p", status.HasLatlong.ToString());
                        SetVar("EliteAPI.InDanger_p", status.InDanger.ToString());
                        SetVar("EliteAPI.InInterdiction_p", status.InInterdiction.ToString());
                        SetVar("EliteAPI.InMothership_p", status.InMothership.ToString());
                        SetVar("EliteAPI.InNoFireZone_p", status.InNoFireZone.ToString());
                        SetVar("EliteAPI.InFighter_p", status.InFighter.ToString());
                        SetVar("EliteAPI.InSRV_p", status.InSRV.ToString());
                        SetVar("EliteAPI.AnalysisMode_p", status.AnalysisMode.ToString());
                        SetVar("EliteAPI.NightVision_p", status.NightVision.ToString());
                        SetVar("EliteAPI.Pips.Systems_p", status.Pips[0].ToString());
                        SetVar("EliteAPI.Pips.Engines_p", status.Pips[1].ToString());
                        SetVar("EliteAPI.Pips.Weapons_p", status.Pips[2].ToString());
                        SetVar("EliteAPI.FireGroup_p", status.FireGroup.ToString());
                        SetVar("EliteAPI.GuiFocus_p", status.GuiFocus.ToString());
                        SetVar("EliteAPI.Fuel_p", status.Fuel.FuelMain.ToString());
                        SetVar("EliteAPI.FuelReservoir_p", status.Fuel.FuelReservoir.ToString());
                        SetVar("EliteAPI.Cargo_p", status.Cargo.ToString());

                        SetVar("EliteAPI.Commander_p", commander.Commander);
                        SetVar("EliteAPI.System_p", location.StarSystem);
                        SetVar("EliteAPI.Body_p", location.Body);
                        SetVar("EliteAPI.BodyType_p", location.BodyType);

                        SetVar("EliteAPI.Rank.Combat_p", commander.CombatRankLocalised);
                        SetVar("EliteAPI.Rank.Trade_p", commander.TradeRankLocalised);
                        SetVar("EliteAPI.Rank.Exploration_p", commander.ExplorationRankLocalised);
                    }
                    catch (Exception ex)
                    {
                        api.Logger.LogError($"There was an error while setting some of the status variables. (Make sure the game is running.)", ex);
                    }
                }

                if (macroName != null)
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
                            if (type.Contains("int")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("long")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("string")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("decimal")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("double")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("float")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("bool")) { SetVar("EliteAPI.Event." + name + "_p", value); }
                        }
                        catch (Exception ex)
                        {
                            api.Logger.LogError($"There was an error while trying to parse field ['{name}' ({value})] for '{eventName}'.", ex);
                        }
                    }
                    vmCommand.ExecuteMacro(macroName);
                }
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while invoking the event '{eventName}'.", ex);
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
                    return;
                }
                else if (command == "drp on")
                {
                    api.DiscordRichPresence.TurnOn();
                    return;
                }
                else if (command == "drp off")
                {
                    api.DiscordRichPresence.TurnOff();
                    return;
                }
            }
            catch { }
        }

        private void SetVar(string name, object value)
        {
            vmCommand.SetVariable(name, value.ToString());
        }
    }
}
