using System.IO;
using System.Windows.Forms;

using EliteAPI;
using EliteAPI.Events;

using InputManager;

using Microsoft.Extensions.DependencyInjection;

namespace Example
{
    class Program
    {
        private static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>(x => new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory));
        }

        private static void EliteAPI_DockingGrantedEvent(object sender, DockingGrantedInfo e)
        {
            //This method will be ran every time the player is allowed to dock.
            if(EliteAPI.Status.Gear != true) //If the gear is not deployed, deploy it.
            {
                Keyboard.KeyPress(Keys.G);
            }
        }
    }
}
