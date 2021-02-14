using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class WonATrophyForSquadronEvent : EventBase<WonATrophyForSquadronEvent>
    {
        internal WonATrophyForSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<WonATrophyForSquadronEvent> WonATrophyForSquadronEvent;
        
        internal void InvokeWonATrophyForSquadronEvent(WonATrophyForSquadronEvent arg)
        {
            WonATrophyForSquadronEvent?.Invoke(this, arg);
        }
    }
}