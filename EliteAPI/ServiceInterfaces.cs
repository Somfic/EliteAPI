using EliteAPI.Bindings;
using EliteAPI.Discord;
using EliteAPI.Status;
using Somfic.Logging;
using System;
using System.IO;
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
        Logger Logger { get; }
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
        void Start(bool runRichPresence = true);
        void Stop();
        void ChangeJournal(DirectoryInfo newJournalDirectory);
    }
}