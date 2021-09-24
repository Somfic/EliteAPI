using System;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard
{
    public class UserProfile
    {
        public static string SaveFolderPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EliteAPI");

        private static string SaveFilePath = Path.Combine(SaveFolderPath, "userprofile.json");

        public void Save()
        {
            Directory.CreateDirectory(SaveFolderPath);
            File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(this));
        }

        public static UserProfile Get()
        {
            return File.Exists(SaveFilePath)
                ? JsonConvert.DeserializeObject<UserProfile>(File.ReadAllText(SaveFilePath))
                : new UserProfile();
        }

        public static void Set(UserProfile userProfile)
        {
            Directory.CreateDirectory(SaveFolderPath);
            File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(userProfile));
        }

        public static void Set(string json)
        {
            Directory.CreateDirectory(SaveFolderPath);
            File.WriteAllText(SaveFilePath,
                JsonConvert.SerializeObject(JsonConvert.DeserializeObject<UserProfile>(json)));
        }

        public EliteVaProfile EliteVA { get; init; } = new();

        public bool FirstRun { get; init; } = true;
    }

    public class EliteVaProfile
    {
        public bool IsInstalled { get; set; }

        public string InstalledVersion { get; set; } = "0.0.0";

        public string InstallationDirectory { get; init; } = (string) Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\VoiceAttack.com\VoiceAttack\LastRun", "AppsFolder", "C:\\Program Files (x86)\\VoiceAttack\\Apps");
    }
}