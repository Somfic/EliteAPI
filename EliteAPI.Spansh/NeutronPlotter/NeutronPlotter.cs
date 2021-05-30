using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EliteAPI.Spansh.NeutronPlotter.Abstractions;
using EliteAPI.Spansh.NeutronPlotter.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Spansh.NeutronPlotter
{
    public class NeutronPlotter : INeutronPlotter
    {
        private readonly ILogger<NeutronPlotter> _log;
        private readonly IHttpClientFactory _httpClientFactory;

        public NeutronPlotter(ILogger<NeutronPlotter> log, IHttpClientFactory httpClientFactory)
        {
            _log = log;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<NeutronPlotterResponse> Plot(string sourceSystem, string destinationSystem, int range,
            int efficiency = 60)
        {
            _log.LogDebug("Calculating neutron route from {Source} to {Destination} with a range of {Range}ly ({Efficiency}%)", sourceSystem, destinationSystem, range, efficiency);
            
            var client = _httpClientFactory.CreateClient();

            var pairs = new List<KeyValuePair<string, string>>
            {
                new("efficiency", efficiency.ToString()),
                new("range", range.ToString()),
                new("from", sourceSystem),
                new("to", destinationSystem)
            };
            
            var httpRouteResult = await client.PostAsync("https://www.spansh.co.uk/api/route", new FormUrlEncodedContent(pairs));
            if (!httpRouteResult.IsSuccessStatusCode)
            {
                return await HandleError(httpRouteResult);
            }

            var routeResult = JsonConvert.DeserializeObject<RouteResult>(await httpRouteResult.Content.ReadAsStringAsync());

            while (routeResult.Status != "ok")
            {
                await Task.Delay(1000);
                httpRouteResult = await client.GetAsync($"https://www.spansh.co.uk/api/results/{routeResult.Job}");
                if (!httpRouteResult.IsSuccessStatusCode)
                {
                    return await HandleError(httpRouteResult);
                }
                
                routeResult = JsonConvert.DeserializeObject<RouteResult>(await httpRouteResult.Content.ReadAsStringAsync());
            }
            
            return JsonConvert.DeserializeObject<NeutronPlotterResponse>(
                await httpRouteResult.Content.ReadAsStringAsync());
        }

        private async Task<NeutronPlotterResponse> HandleError(HttpResponseMessage httpResponseMessage)
        {
            var error = JsonConvert.DeserializeObject<ErrorResult>(
                await httpResponseMessage.Content.ReadAsStringAsync());
            
            _log.LogWarning("Invalid neutron route request: {Message}", error.Error);

            return await Task.FromResult(new NeutronPlotterResponse());
        }
    }
}