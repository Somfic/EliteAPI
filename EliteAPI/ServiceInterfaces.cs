using System;
using System.Diagnostics;
using System.IO;

using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;

namespace EliteAPI
{
    public interface IEliteDangerousAPI
    {
        //Version info.
        string Version { get; }

        //Public fields.
        bool IsRunning { get; }
        DirectoryInfo JournalDirectory { get; }
        bool SkipCatchUp { get; }
        EliteAPI.Events.EventHandler Events { get; }
        EliteAPI.Logging.Logger Logger { get; }
        GameStatus Status { get; }
        ShipCargo Cargo { get; }
        ShipModules Modules { get; }
        UserBindings Bindings { get; }
        CommanderStatus Commander { get; }
        LocationStatus Location { get; }

        event EventHandler<Tuple<string, Exception>> OnError;
        event EventHandler OnQuit;
        event EventHandler OnReady;

        //Services.
        RichPresenceClient DiscordRichPresence { get; }

        //Methods.
        void Reset();
        void Start();
        void Stop();
        void ChangeJournal(DirectoryInfo newJournalDirectory);
    }
}