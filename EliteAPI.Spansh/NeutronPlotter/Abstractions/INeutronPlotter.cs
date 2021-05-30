using System.Threading.Tasks;
using EliteAPI.Spansh.NeutronPlotter.Models;

namespace EliteAPI.Spansh.NeutronPlotter.Abstractions
{
    public interface INeutronPlotter
    {
        Task<NeutronPlotterResponse> Plot(string sourceSystem, string destinationSystem, int range, int efficiency = 60);
    }
}