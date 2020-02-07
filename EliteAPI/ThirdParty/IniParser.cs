using IniParser;
using IniParser.Model;
using Somfic.Logging;
using System;
using System.IO;

namespace EliteAPI.ThirdParty
{
    internal class IniParser
    {
        private readonly string iniPath;
        private IniData iniData;
        private readonly Logger logger;

        public IniParser(Logger logger, string iniPath)
        {
            this.iniPath = iniPath;
            this.logger = logger;
        }

        public void UpdateIni()
        {
            // Parse the ini file.
            FileIniDataParser parser = new FileIniDataParser();

            // If the ini file does not exist, create a new one.
            if (!File.Exists(iniPath))
            {
                iniData = new IniData();
                iniData["ELITEAPI"]["path"] = EliteDangerousAPI.StandardDirectory.ToString();
                iniData["LOGGING"]["path"] = Directory.GetCurrentDirectory();
                iniData["DISCORD"]["richPresence"] = "on";
                logger.Log(Severity.Debug, $"Resetting ini configuration file at '{iniPath}'.");
                parser.WriteFile(iniPath, iniData);
            }
            else
            {
                logger.Log(Severity.Debug, $"Reading ini configuration file from '{iniPath}'.");
                iniData = parser.ReadFile(iniPath);
            }
        }

        public string GetLoggingPath()
        {
            try
            {
                string path = iniData["LOGGING"]["path"];
                if (Directory.Exists(path)) { logger.Log($"Using '{path}' for logging."); return path; }
                else { logger.Log(Severity.Warning, $"Found '{path}' for logging, but the path is invalid, using '{Directory.GetCurrentDirectory()}' instead."); return Directory.GetCurrentDirectory(); }
            }
            catch (Exception ex)
            {
                logger.Log(Severity.Warning, $"Could not read from '{iniPath}', using '{Directory.GetCurrentDirectory()}' for logging.", ex);
                return Directory.GetCurrentDirectory();
            }
        }

        public DirectoryInfo GetJournalDirectory()
        {
            try
            {
                string path = iniData["ELITEAPI"]["path"];
                if (path == EliteDangerousAPI.StandardDirectory.FullName)
                {
                    logger.Log(Severity.Debug, $"Using default path."); return EliteDangerousAPI.StandardDirectory;
                }

                if (Directory.Exists(path))
                {
                    logger.Log($"Found '{path}'."); return new DirectoryInfo(path);
                }
                
                logger.Log(Severity.Warning, $"Found '{path}', but the path is invalid, using default path.");
                return EliteDangerousAPI.StandardDirectory;
            }
            catch (Exception ex)
            {
                logger.Log(Severity.Warning, $"Could not read from '{iniPath}', using default Journal path.", ex);
                return EliteDangerousAPI.StandardDirectory;
            }
        }

        public bool GetRichPresenceSetting()
        {
            try
            {
                string value = iniData["DISCORD"]["richPresence"].ToLower();
                return value == "on" || value == "true" || value == "yes";
            }
            catch (Exception ex)
            {
                logger.Log(Severity.Warning, $"Could not read from '{iniPath}', rich presence set to true.", ex);
                return true;
            }
        }
    }
}
