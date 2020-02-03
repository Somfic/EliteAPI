using System;
using System.Collections.Generic;
using System.IO;
using EliteAPI.Events;
using Newtonsoft.Json;
using Somfic.Logging;

namespace EliteAPI.Status
{
    public class GameStatus
    {
        internal GameStatus() { }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Flags")]
        public ShipStatusFlags Flags { get; internal set; }

        [JsonProperty("Pips")]
        public List<long> Pips { get; internal set; }

        [JsonProperty("FireGroup")]
        public long FireGroup { get; internal set; }

        [JsonProperty("GuiFocus")]
        public long GuiFocus { get; internal set; }

        [JsonProperty("Fuel")]
        public Fuel Fuel { get; internal set; }

        [JsonProperty("LegalState")]
        public string LegalState { get; internal set; }

        [JsonProperty("Cargo")]
        public long Cargo { get; internal set; }

        public bool Docked => GetFlag(0);
        public bool Landed => GetFlag(1);
        public bool Gear => GetFlag(2);
        public bool Shields => GetFlag(3);
        public bool Supercruise => GetFlag(4);
        public bool FlightAssist => !GetFlag(5);
        public bool Hardpoints => GetFlag(6);
        public bool Winging => GetFlag(7);
        public bool Lights => GetFlag(8);
        public bool CargoScoop => GetFlag(9);
        public bool SilentRunning => GetFlag(10);
        public bool Scooping => GetFlag(11);
        public bool SrvHandbreak => GetFlag(12);
        public bool SrvTurrent => GetFlag(13);
        public bool SrvNearShip => GetFlag(14);
        public bool SrvDriveAssist => GetFlag(15);
        public bool MassLocked => GetFlag(16);
        public bool FsdCharging => GetFlag(17);
        public bool FsdCooldown => GetFlag(18);
        public bool LowFuel => GetFlag(19);
        public bool Overheating => GetFlag(20);
        public bool HasLatlong => GetFlag(21);
        public bool InDanger => GetFlag(22);
        public bool InInterdiction => GetFlag(23);
        public bool InMothership => GetFlag(24);
        public bool InFighter => GetFlag(25);
        public bool InSRV => GetFlag(26);
        public bool AnalysisMode => GetFlag(27);
        public bool NightVision => GetFlag(28);
        public GameModeType GameMode { get; internal set; }
        public bool InNoFireZone { get; internal set; }
        public float JumpRange { get; internal set; }
        public bool IsRunning => Flags != 0;
        public bool InMainMenu { get; internal set; }
        public string MusicTrack { get; internal set; }

        internal static GameStatus Process(string json)
        {
            return JsonConvert.DeserializeObject<GameStatus>(json, JsonConverter.Settings);
        }

        internal static GameStatus FromFile(FileInfo file, EliteDangerousAPI api)
        {
            try
            {
                if (!File.Exists(file.FullName)) /*  api.Logger.Log(Severity.Error, "Could not find Status.json.", new FileNotFoundException("Status.json could not be found.", file.FullName)); */ return new GameStatus();

                //Create a stream from the log file.
                var fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //Create a stream from the file stream.
                var streamReader = new StreamReader(fileStream);

                //Go through the stream.
                while (!streamReader.EndOfStream)
                    try
                    {
                        //Process this string.
                        var json = streamReader.ReadLine();
                        var s = Process(json);

                        if (s.Fuel == null)
                        {
                            s.Fuel = new Fuel();
                        }

                        if (s.Pips == null)
                        {
                            s.Pips = new List<long> {0, 0, 0};
                        }

                        return s;
                    }
                    catch (Exception ex)
                    {
                        api.Logger.Log(Severity.Warning, "Could not update Status.json.", ex);
                    }

                return api.Status;
            }
            catch (Exception ex)
            {
                api.Logger.Log(Severity.Warning, "Could not update status.", ex);
            }

            return new GameStatus();
        }

        public bool GetFlag(int bit)
        {
            return Flags.HasFlag((ShipStatusFlags) (1 << bit));
        }
    }
}