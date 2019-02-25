using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteAPI;

namespace EliteCoPilot.Services
{
    public class Docking : IService
    {
        private EliteDangerousAPI EliteAPI;

        private int LandingPad;

        public void Init(EliteDangerousAPI EliteAPI)
        {
            this.EliteAPI = EliteAPI;
            EliteAPI.Events.DockingGrantedEvent += (sender, arg) => LandingPad = (int)arg.LandingPad;
        }
    }
}
