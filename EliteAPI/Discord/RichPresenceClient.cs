using System;
using System.Threading;
using System.Threading.Tasks;
using DiscordRPC;

namespace EliteAPI.Discord
{
    public class RichPresenceClient
    {
        private static readonly string clientID = "497862888128512041";

        private DiscordRpcClient rpc;
        private EliteDangerousAPI api;
        public bool IsRunning { get; private set; } = false;

        public RichPresenceClient(EliteDangerousAPI api)
        {
            this.api = api;
        }

        public void UpdatePresence(RichPresence presence)
        {
            //If we're not running, return;
            //if(!IsRunning) { return; }

            DiscordRPC.RichPresence discordPresence = new DiscordRPC.RichPresence()
            {
                Details = presence.Text,
                State = presence.TextTwo,
                Assets = new Assets()
                {
                    LargeImageKey = presence.Icon,
                    LargeImageText = presence.IconText,
                    SmallImageKey = presence.IconTwo,
                    SmallImageText = presence.IconTextTwo
                }
            };

            rpc.SetPresence(discordPresence);
        }

        public void TurnOn()
        {
            //Create RPC client.
            rpc = new DiscordRpcClient(clientID, true);
            api.Logger.LogInfo("Starting rich presence. ");

            //Subscribe to events.
            rpc.OnConnectionFailed += (sender, e) => api.Logger.LogError("There was an error while trying to connect to the rich presence.");
            rpc.OnConnectionEstablished += (sender, e) => api.Logger.LogInfo("Rich presence connected.");
            rpc.OnError += (sender, e) => api.Logger.LogError("Rich presence error: " + e.Message);
            rpc.OnReady += (sender, e) => api.Logger.LogInfo("Rich presence ready.");


            //Start the RPC.
            //Mark as running.
            IsRunning = true;
            rpc.SetSubscription(EventType.Join | EventType.JoinRequest | EventType.Spectate);
            rpc.Initialize();
            Task.Run(() => { while (IsRunning) { Thread.Sleep(1000); rpc.Invoke(); } });

            api.Events.DockingGrantedEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Attemping to dock",
                TextTwo = $"at {e.StationName}",
                Icon = "coriolis",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.DockedEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Docked at {e.StationName}",
                TextTwo = $"in {e.StarSystem}",
                Icon = "coriolis",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.UndockedEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Leaving {e.StationName}",
                TextTwo = $"in {api.Location.StarSystem}",
                Icon = "coriolis",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.StartJumpEvent += (sender, e) =>
            {
                if (e.JumpType == "FSDJump")
                {
                    UpdatePresence(new RichPresence()
                    {
                        Text = $"Jumping to {e.StarSystem}",
                        TextTwo = $"Class {e.StarClass} star",
                        Icon = "ed",
                        IconText = "EliteAPI"
                    });
                }
            };
            api.Events.FSDJumpEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Arrived in {e.StarSystem}",
                TextTwo = $"after travelling {Math.Round(e.JumpDist, 1)} ly",
                Icon = "route",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.ApproachBodyEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Approaching planet",
                TextTwo = e.Body,
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.LeaveBodyEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Leaving planet",
                TextTwo = e.Body,
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.TouchdownEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Touched down on",
                TextTwo = api.Location.Body,
                Icon = "exploration",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.LiftoffEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Lifted off from",
                TextTwo = api.Location.Body,
                Icon = "exploration",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.SupercruiseEntryEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Travelling in supercruise",
                TextTwo = $"in {e.StarSystem}",
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.SupercruiseExitEvent += (sender, e) => UpdatePresence(new RichPresence()
            {
                Text = $"Travelling in normal space",
                TextTwo = $"near {e.BodyType.ToLower().Replace("planetaryring", "ring")} {e.Body.Replace("Ring", "")}",
                Icon = "exploration",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.MusicEvent += (sender, e) =>
            {
                if (e.MusicTrack == "DockingComputer")
                {
                    UpdatePresence(new RichPresence()
                    {
                        Text = $"Having autopilot dock",
                        TextTwo = $"them at {api.Location.Body}",
                        Icon = "coriolis",
                        IconTwo = "ed",
                        IconTextTwo = "EliteAPI"
                    });
                }
            };

            UpdatePresence(new RichPresence() { Text = "Just started playing", Icon = "ed", IconText = "EliteAPI" });
        }

        public void TurnOff()
        {
            //Remove all presences from queue, and clear it.
            rpc.DequeueAll();
            rpc.ClearPresence();
            rpc.Dispose();

            //Mark as not running.
            IsRunning = false;
        }
    }

    public class RichPresence
    {
        public string Text { get; set; }
        public string TextTwo { get; set; }
        public string Icon { get; set; }
        public string IconText { get; set; }
        public string IconTwo { get; set; }
        public string IconTextTwo { get; set; }
    }
}
