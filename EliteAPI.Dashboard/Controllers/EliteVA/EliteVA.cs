using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.Controllers.EliteVA
{
    [ApiController]
    public class EliteVA
    {
        private readonly HttpClient _httpClient;

        public EliteVA(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("eliteva/latest")]
        public async Task<ActionResult<GithubVersioningResponse>> GetLatestVersion()
        {
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("EliteAPI", "1.0.0"));
            
            var result = await _httpClient.GetAsync("https://api.github.com/repos/EliteAPI/Plugins/releases/latest");
            result.EnsureSuccessStatusCode();
            
            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GithubVersioningResponse>(responseJson);
        }

        [HttpGet("eliteva/installed")]
        public ActionResult<EliteVaProfile> GetEliteVa()
        {
            return UserProfile.Load().EliteVA;
        }
    }
}