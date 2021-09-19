using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.Controllers.EliteVA
{
    public class GithubVersioningResponse
    {
        [JsonProperty("author")] public AuthorInfo Author { get; set; }
    
        [JsonProperty("tag_name")] public string TagName { get; set; }

        [JsonProperty("target_commitish")] public string TargetCommitish { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("draft")] public bool Draft { get; set; }

        [JsonProperty("prerelease")] public bool Prerelease { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("published_at")] public DateTime PublishedAt { get; set; }

        [JsonProperty("assets")] public IReadOnlyList<AssetInfo> Assets { get; set; }
    
        [JsonProperty("body")] public string Body { get; set; }
    
        public class AssetInfo
        {
            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("label")] public object Label { get; set; }

            [JsonProperty("uploader")] public AuthorInfo Uploader { get; set; }

            [JsonProperty("content_type")] public string ContentType { get; set; }

            [JsonProperty("state")] public string State { get; set; }

            [JsonProperty("size")] public long Size { get; set; }

            [JsonProperty("download_count")] public long DownloadCount { get; set; }

            [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

            [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }

            [JsonProperty("browser_download_url")] public Uri BrowserDownloadUrl { get; set; }
        }

        public class AuthorInfo
        {
            [JsonProperty("login")] public string Name { get; set; }
        
            [JsonProperty("avatar_url")] public Uri AvatarUrl { get; set; }
        
            [JsonProperty("type")] public string Type { get; set; }

            [JsonProperty("site_admin")] public bool SiteAdmin { get; set; }
        }
    }
}