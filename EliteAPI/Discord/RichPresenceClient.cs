using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using DiscordRPC;
using Newtonsoft.Json;
using Somfic.Logging;

namespace EliteAPI.Discord
{
    public class RichPresenceClient
    {
        private static string clientID = "497862888128512041";
        private DiscordRpcClient rpc;
        private readonly EliteDangerousAPI api;
        private bool justDocked = false;

        /// <summary>
        /// Whether the rich presence is running.
        /// </summary>
        public bool IsRunning { get; private set; } = false;
        /// <summary>
        /// Whether the rich presence is connected and ready.
        /// </summary>
        public bool IsReady { get; private set; } = false;
        /// <summary>
        /// Creates a new Discord Rich Presence client based on the EliteDangerousAPI object.
        /// </summary>
        /// <param name="api">EliteDangerousAPI</param>
        public RichPresenceClient(EliteDangerousAPI api)
        {
            this.api = api;
        }


        /// <summary>
        /// Creates a new Discord Rich Presence client based on the EliteDangerousAPI object, with a custom RPC ID, for when you have your own Rich Presence registered with Discord.
        /// </summary>
        /// <param name="api">EliteDangerousAPI</param>
        public RichPresenceClient(EliteDangerousAPI api, string rpcID)
        {
            this.api = api;
            clientID = rpcID;
        }
        /// <summary>
        /// Set a custom ID to be used, for when you have your own RPC registered with Discord.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RichPresenceClient WithCustomID(string id)
        {
            clientID = id;
            api.Logger.Log(Severity.Debug, $"Set custom Discord Rich Presence ID to {id}.");
            return this;
        }
        /// <summary>
        /// Update the rich presence.
        /// </summary>
        /// <param name="presence">The custom rich presence to display.</param>
        public RichPresenceClient UpdatePresence(RichPresence presence)
        {
            //If we're not running, return;
            if(!IsRunning) { return this; }
            api.Logger.Log(Severity.Debug, $"Updated Discord rich presence.", presence);
            DiscordRPC.RichPresence discordPresence = new DiscordRPC.RichPresence
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
            return this;
        }

        /// <summary>
        /// Turn the rich presence on.
        /// </summary>
        /// <param name="automatic">Whether to have EliteAPI send events to the presence.</param>
        public RichPresenceClient TurnOn(bool automatic = true)
        {
            //Create RPC client.
            rpc = new DiscordRpcClient(clientID, true);
            api.Logger.Log("Starting rich presence.");

            //Subscribe to events.
            rpc.OnConnectionEstablished += (sender, e) => api.Logger.Log(Severity.Debug, $"Attempting to connect to Discord ... ");
            rpc.OnConnectionFailed += (sender, e) => { api.Logger.Log(Severity.Error, $"There was an error while trying to connect to Discord. Make sure Discord is running.", new ExternalException("Discord is unresponsive, or might not be running on this machine.")); TurnOff(); };
            rpc.OnError += (sender, e) => api.Logger.Log(Severity.Error, $"Discord Rich Presence stumbled upon an error.", new ExternalException(e.Message, (int)e.Code));
            rpc.OnReady += (sender, e) => { api.Logger.Log(Severity.Success, $"Discord Rich Presence has connected and is running."); IsReady = true; };
            rpc.OnClose += (sender, e) => { api.Logger.Log($"Discord Rich Presence closed.", new ExternalException(e.Reason, e.Code)); TurnOff(); };
            rpc.OnJoin += (sender, e) => api.Logger.Log(Severity.Debug, $"Discord Rich Presence joined with secret '{e.Secret}'.");
            rpc.OnJoinRequested += (sender, e) => api.Logger.Log(Severity.Debug, $"Discord Rich Presence joining with '{e.User.Username}' (ID {e.User.ID})");
            api.Events.DockedEvent += (sender, e) => { justDocked = true; };
            api.Events.UndockedEvent += (sender, e) => { justDocked = false; };

            //Start the RPC.
            //Mark as running.
            IsRunning = true;
            rpc.SetSubscription(EventType.Join | EventType.JoinRequest | EventType.Spectate);
            rpc.Initialize();
            Task.Run(() => { while (!IsReady) { Thread.Sleep(1000); rpc.Invoke(); } });
            if(automatic) { DoAutomaticEvents(); }
            return this;
        }
        private void DoAutomaticEvents()
        {
            api.Events.DockingGrantedEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Docking at",
                TextTwo = $"{e.StationName}",
                Icon = "coriolis",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.DockedEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Docked at {e.StationName}",
                TextTwo = $"in {e.StarSystem}",
                Icon = "coriolis",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.UndockedEvent += (sender, e) => UpdatePresence(new RichPresence
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
                    UpdatePresence(new RichPresence
                    {
                        Text = $"Jumping to {e.StarSystem}",
                        TextTwo = $"Class {e.StarClass} star",
                        Icon = "ed",
                        IconText = "EliteAPI"
                    });
                }
            };
            api.Events.FSDJumpEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Arrived in {e.StarSystem}",
                TextTwo = $"after travelling {Math.Round(e.JumpDist, 1)} ly",
                Icon = "route",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.ApproachBodyEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Approaching planet",
                TextTwo = e.Body,
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.LeaveBodyEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Leaving planet",
                TextTwo = e.Body,
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.TouchdownEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Touched down on",
                TextTwo = api.Location.Body,
                Icon = "exploration",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.LiftoffEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Lifted off from",
                TextTwo = api.Location.Body,
                Icon = "exploration",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.SupercruiseEntryEvent += (sender, e) => UpdatePresence(new RichPresence
            {
                Text = $"Travelling in supercruise",
                TextTwo = $"in {e.StarSystem}",
                Icon = "loading",
                IconTwo = "ed",
                IconTextTwo = "EliteAPI"
            });
            api.Events.SupercruiseExitEvent += (sender, e) => UpdatePresence(new RichPresence
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
                    if (api.Status.Docked)
                    { 
                        UpdatePresence(new RichPresence
                        {
                            Text = $"Having autopilot undock",
                            TextTwo = $"them from {api.Location.Body}",
                            Icon = "coriolis",
                            IconTwo = "ed",
                            IconTextTwo = "EliteAPI"
                        });
                    }
                    else
                    {
                        UpdatePresence(new RichPresence
                        {
                            Text = $"Having autopilot dock",
                            TextTwo = $"them at {api.Location.Body}",
                            Icon = "coriolis",
                            IconTwo = "ed",
                            IconTextTwo = "EliteAPI"
                        });
                    }
                }
            };
            if (string.IsNullOrWhiteSpace(api.Location.StarSystem))
            {
                UpdatePresence(new RichPresence { Text = "Just started playing", Icon = "ed", IconText = "EliteAPI" });
            }
            else
            {
                UpdatePresence(new RichPresence { Text = "Just started playing", TextTwo = "In " + api.Location.StarSystem, Icon = "ed", IconText = "EliteAPI" });
            }
        }
        /// <summary>
        /// Turn the rich presence off.
        /// </summary>
        public RichPresenceClient TurnOff()
        {
            api.Logger.Log("Terminating rich presence.");   
            //Remove all presences from queue, and clear it.
            rpc.DequeueAll();
            rpc.ClearPresence();
            rpc.Dispose();
            //Mark as not running.
            IsRunning = false;
            return this;
        }
    }
}
