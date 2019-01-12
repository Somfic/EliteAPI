namespace EliteAPI.Status
{
    public class LocationStatus
    {
        public LocationStatus(EliteDangerousAPI api)
        {
            api.Events.LocationEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = e.BodyType; };
            api.Events.ApproachBodyEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = "Planet"; };
            api.Events.LeaveBodyEvent += (sender, e) => { StarSystem = e.StarSystem; Body = e.Body; BodyType = "Planet"; };
        }

        public string StarSystem { get; private set; }
        public string Body { get; private set; }
        public string BodyType { get; private set; }
    }
}
