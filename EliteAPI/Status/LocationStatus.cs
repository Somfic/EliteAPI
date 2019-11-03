namespace EliteAPI.Status
{
    public class LocationStatus
    {
        internal LocationStatus(EliteDangerousAPI api)
        {
            api.Events.LocationEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = e.BodyType; };
            api.Events.ApproachBodyEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = "Planet"; };
            api.Events.ApproachSettlementEvent += (sender, e) => { Station = e.Name; BodyType = "Planet"; };
            api.Events.LeaveBodyEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = "Planet"; };
            api.Events.DockedEvent += (sender, e) => { Station = e.StationName; };
            api.Events.DockingRequestedEvent += (sender, e) => { Station = e.StationName; };
            api.Events.FSDJumpEvent += (sender, e) => { StarSystem = e.StarSystem; };
        }
        public string StarSystem { get; private set; } = "";
        public string Body { get; private set; } = "";
        public string BodyType { get; private set; } = "";
        public string Station { get; private set; } = "";
    }
}