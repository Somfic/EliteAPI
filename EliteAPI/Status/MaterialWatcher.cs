using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EliteAPI.Status
{
    internal class MaterialWatcher
    {
        private EliteDangerousAPI EliteAPI;
        internal MaterialWatcher(EliteDangerousAPI api)
        {
            EliteAPI = api;
            EliteAPI.Events.MaterialsEvent += (sender, e) => EliteAPI.Materials = e;
            EliteAPI.Events.MaterialCollectedEvent += Events_MaterialCollectedEvent;
            EliteAPI.Events.MaterialDiscardedEvent += Events_MaterialDiscardedEvent;
            EliteAPI.Events.MaterialTradeEvent += Events_MaterialTradeEvent;
            EliteAPI.Events.SynthesisEvent += Events_SynthesisEvent;
        }
        private void Events_SynthesisEvent(object sender, Events.SynthesisInfo e)
        {
            foreach (var m in e.Materials)
            {
                Events_MaterialDiscardedEvent(this, new Events.MaterialDiscardedInfo { Category = "Raw", Name = m.NameLocalised, Count = m.Count });
            }
        }
        private void Events_MaterialTradeEvent(object sender, Events.MaterialTradeInfo e)
        {
            Events_MaterialDiscardedEvent(this, new Events.MaterialDiscardedInfo() { Category = e.Paid.CategoryLocalised, Count = e.Paid.Quantity, Name = e.Paid.MaterialLocalised });
            Events_MaterialCollectedEvent(this, new Events.MaterialCollectedInfo() { Category = e.Received.CategoryLocalised, Count = e.Received.Quantity, Name = e.Received.MaterialLocalised });
        }
        private void Events_MaterialDiscardedEvent(object sender, Events.MaterialDiscardedInfo e)
        {
            if (EliteAPI.Materials.Raw.Count(x => x.Name == e.Name) != 0) { EliteAPI.Materials.Raw.Where(x => x.Name == e.Name).First().Count -= e.Count; }
            else if (EliteAPI.Materials.Encoded.Count(x => x.Name == e.Name) != 0) { EliteAPI.Materials.Encoded.Where(x => x.Name == e.Name).First().Count -= e.Count; }
        }
        private void Events_MaterialCollectedEvent(object sender, Events.MaterialCollectedInfo e)
        {
            if(EliteAPI.Materials.Raw.Count(x => x.Name == e.NameLocalised) != 0) { EliteAPI.Materials.Raw.Where(x => x.Name == e.Name).First().Count += e.Count; }
            else if(EliteAPI.Materials.Encoded.Count(x => x.Name == e.NameLocalised) != 0) { EliteAPI.Materials.Encoded.Where(x => x.Name == e.Name).First().Count += e.Count; }
            if(e.Category == "Raw") { EliteAPI.Materials.Raw.Add(new Events.Raw() { Name = e.NameLocalised, Count = e.Count }); }
            else if(e.Category == "Encoded") { EliteAPI.Materials.Encoded.Add(new Events.Encoded() { Name = e.NameLocalised, Count = e.Count }); }
        }
    }
}
