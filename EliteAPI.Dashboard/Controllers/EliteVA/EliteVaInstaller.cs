using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.Controllers.EliteVA
{
    public class EliteVaInstaller
    {
        private readonly ILogger<EliteVaInstaller> _log;
        private readonly HttpClient _httpClient;
        private WebClient _webClient;

        private static string SaveFolderPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EliteAPI");

        public EliteVaInstaller(ILogger<EliteVaInstaller> log, HttpClient httpClient)
        {
            _log = log;
            _httpClient = httpClient;
        }
        

        public event EventHandler<DownloadProgressChangedEventArgs> OnProgress; 
        public event EventHandler OnFinished; 
        public event EventHandler OnStart; 

        public void DownloadLatestVersion()
        {
            OnStart?.Invoke(this, EventArgs.Empty);
            
            _webClient = new WebClient();
            
            _webClient.DownloadProgressChanged += (sender, e) => OnProgress?.Invoke(this, e);
            
            var release = GetLatestVersion("EliteAPI", "EliteVA").GetAwaiter().GetResult();
            var userprofile = UserProfile.Get();
            var downloadPath = Path.Combine(Path.Combine(SaveFolderPath, "EliteVA"), release.TagName);

            Directory.CreateDirectory(downloadPath);

            userprofile.EliteVA.IsInstalled = true;
            userprofile.EliteVA.InstalledVersion = release.TagName;
            userprofile.Save();
            
            release.Assets.ToList().ForEach(x =>
            {
                var path = Path.Combine(downloadPath, x.Name);
                _webClient.DownloadFileTaskAsync(x.BrowserDownloadUrl, path).GetAwaiter().GetResult();
                ZipFile.ExtractToDirectory(path, userprofile.EliteVA.InstallationDirectory, true);
                OnFinished?.Invoke(this, EventArgs.Empty);
            });
            
            _webClient.Dispose();
        }

        private async Task<GithubVersioningResponse> GetLatestVersion(string author, string repo)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("EliteAPI", "1.0.0"));
            var result = await _httpClient.GetAsync($"https://api.github.com/repos/{author}/{repo}/releases/latest");
            result.EnsureSuccessStatusCode();

            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GithubVersioningResponse>(responseJson);
        }
    }
}