using System;
using System.IO;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard
{
    public class UserProfile
    {
        private static string SaveFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EliteAPI");
        private static string SaveFilePath = Path.Combine(SaveFolderPath, "userprofile.json");

        public void Save()
        {
            Directory.CreateDirectory(SaveFolderPath);
            File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(this));
        }

        public static UserProfile Load()
        {
            return File.Exists(SaveFilePath) ? JsonConvert.DeserializeObject<UserProfile>(File.ReadAllText(SaveFilePath)) : new UserProfile();
        }

        public EliteVaProfile EliteVA { get; init; }
    }

    public class EliteVaProfile
    {
        public bool IsInstalled { get; set; }
        
        public string InstalledVersion { get; set; }
        
        public string InstallationFolderPath { get; set; }
    }
}