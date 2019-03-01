using System.Collections.Generic;

using EliteAPI;

namespace EliteCoPilot.Services
{
    public class ServiceHandler
    {
        private List<IService> Services;
        private readonly EliteDangerousAPI EliteAPI;

        public ServiceHandler(EliteDangerousAPI EliteAPI)
        {
            this.EliteAPI = EliteAPI;
            Services = new List<IService>();

        }
        public ServiceHandler UseService(IService service)
        {
            Services.Add(service);
            return this;
        }

        public void StartServices() { foreach (IService service in Services) { service.Init(EliteAPI); } }
    }

    public interface IService
    {
        void Init(EliteDangerousAPI EliteAPI);
    }
}
