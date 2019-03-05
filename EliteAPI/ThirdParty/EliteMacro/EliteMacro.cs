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
                eventName = "((EliteAPI." + e.Event + "))";
                string macroName = vmCommand.CommandExists(eventName);

                if (eventName.Contains("Status"))
                {
                    try
                    {
                        var status = api.Status;
                        var commander = api.Commander;
                        var location = api.Location;

                        vmCommand.SetVariable("EliteAPI.Docked_p", status.Docked.ToString());
                        vmCommand.SetVariable("EliteAPI.Landed_p", status.Landed.ToString());
                        vmCommand.SetVariable("EliteAPI.Gear_p", status.Gear.ToString());
                        vmCommand.SetVariable("EliteAPI.Shields_p", status.Shields.ToString());
                        vmCommand.SetVariable("EliteAPI.Supercruise_p", status.Supercruise.ToString());
                        vmCommand.SetVariable("EliteAPI.FlightAssist_p", status.FlightAssist.ToString());
                        vmCommand.SetVariable("EliteAPI.MassLocked_p", status.MassLocked.ToString());
                        vmCommand.SetVariable("EliteAPI.Hardpoints_p", status.Hardpoints.ToString());
                        vmCommand.SetVariable("EliteAPI.Winging_p", status.Winging.ToString());
                        vmCommand.SetVariable("EliteAPI.Lights_p", status.Lights.ToString());
                        vmCommand.SetVariable("EliteAPI.CargoScoop_p", status.CargoScoop.ToString());
                        vmCommand.SetVariable("EliteAPI.SilentRunning_p", status.SilentRunning.ToString());
                        vmCommand.SetVariable("EliteAPI.Scooping_p", status.Scooping.ToString());
                        vmCommand.SetVariable("EliteAPI.SrvHandbreak_p", status.SrvHandbreak.ToString());
                        vmCommand.SetVariable("EliteAPI.SrvTurrent_p", status.SrvTurrent.ToString());
                        vmCommand.SetVariable("EliteAPI.SrvNearShip_p", status.SrvNearShip.ToString());
                        vmCommand.SetVariable("EliteAPI.SrvDriveAssist_p", status.SrvDriveAssist.ToString());
                        vmCommand.SetVariable("EliteAPI.SrvDriveAssist_p", status.SrvDriveAssist.ToString());
                        vmCommand.SetVariable("EliteAPI.FsdCharging_p", status.FsdCharging.ToString());
                        vmCommand.SetVariable("EliteAPI.FsdCooldown_p", status.FsdCooldown.ToString());
                        vmCommand.SetVariable("EliteAPI.LowFuel_p", status.LowFuel.ToString());
                        vmCommand.SetVariable("EliteAPI.Overheating_p", status.Overheating.ToString());
                        vmCommand.SetVariable("EliteAPI.HasLatlong_p", status.HasLatlong.ToString());
                        vmCommand.SetVariable("EliteAPI.InDanger_p", status.InDanger.ToString());
                        vmCommand.SetVariable("EliteAPI.InInterdiction_p", status.InInterdiction.ToString());
                        vmCommand.SetVariable("EliteAPI.InMothership_p", status.InMothership.ToString());
                        vmCommand.SetVariable("EliteAPI.InNoFireZone_p", status.InNoFireZone.ToString());
                        vmCommand.SetVariable("EliteAPI.InFighter_p", status.InFighter.ToString());
                        vmCommand.SetVariable("EliteAPI.InSRV_p", status.InSRV.ToString());
                        vmCommand.SetVariable("EliteAPI.AnalysisMode_p", status.AnalysisMode.ToString());
                        vmCommand.SetVariable("EliteAPI.NightVision_p", status.NightVision.ToString());
                        vmCommand.SetVariable("EliteAPI.Pips.Systems_p", status.Pips[0].ToString());
                        vmCommand.SetVariable("EliteAPI.Pips.Engines_p", status.Pips[1].ToString());
                        vmCommand.SetVariable("EliteAPI.Pips.Weapons_p", status.Pips[2].ToString());
                        vmCommand.SetVariable("EliteAPI.FireGroup_p", status.FireGroup.ToString());
                        vmCommand.SetVariable("EliteAPI.GuiFocus_p", status.GuiFocus.ToString());
                        vmCommand.SetVariable("EliteAPI.Fuel_p", status.Fuel.FuelMain.ToString());
                        vmCommand.SetVariable("EliteAPI.FuelReservoir_p", status.Fuel.FuelReservoir.ToString());
                        vmCommand.SetVariable("EliteAPI.Cargo_p", status.Cargo.ToString());

                        vmCommand.SetVariable("EliteAPI.Commander_p", commander.Commander);
                        vmCommand.SetVariable("EliteAPI.System_p", location.StarSystem);
                        vmCommand.SetVariable("EliteAPI.Body_p", location.Body);
                        vmCommand.SetVariable("EliteAPI.BodyType_p", location.BodyType);

                        vmCommand.SetVariable("EliteAPI.Rank.Combat_p", commander.CombatRankLocalised);
                        vmCommand.SetVariable("EliteAPI.Rank.Trade_p", commander.TradeRankLocalised);
                        vmCommand.SetVariable("EliteAPI.Rank.Exploration_p", commander.ExplorationRankLocalised);

                        vmCommand.SetVariable("EliteAPI.JumpRange_p", status.JumpRange.ToString());
                        vmCommand.SetVariable("EliteAPI.FuelMax_p", status.Fuel.MaxFuel.ToString());
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
    }
}
