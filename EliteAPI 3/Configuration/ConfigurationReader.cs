using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using IniParser;
using IniParser.Model;

namespace EliteAPI.Configuration
{
    /// <summary>
    /// Class that's able to read configuration files for EliteAPI.
    /// </summary>
    public class ConfigurationReader
    {
        private IniData configuration;
        private string iniFile;

        /// <summary>
        /// Constructor for the ConfgurationReader class. Takes in the path of the ini file.
        /// </summary>
        /// <param name="iniFile">The full path of the ini configuration file.</param>
        public ConfigurationReader(string iniFile)
        {
            //Save the parameter.
            this.iniFile = Path.GetFullPath(iniFile);

            //Update the ini.
            UpdateIni( );
        }

        private void UpdateIni( )
        {
            //Check if the file actually exists.
            if ( !File.Exists(iniFile) )
            {
                //If it does not exist, create a new ini file.
                File.WriteAllText(iniFile, ";EliteAPI" + Environment.NewLine);
                configuration = new FileIniDataParser( ).ReadFile(iniFile);
                SetEntry("Startup", "DirectoryPath", DefaultPaths.JournalDirectory);
                SetEntry("Startup", "CheckForUpdates", "true");
            }

            //If it does exist, read its content.
            configuration = new FileIniDataParser( ).ReadFile(iniFile);
        }

        /// <summary>
        /// Get data from the ini configuration file.
        /// </summary>
        /// <param name="category">The category of the entry within the ini file.</param>
        /// <param name="name">The name within the catagory in the ini file.</param>
        /// <returns></returns>
        public string GetEntry(string category, string name)
        {
            return configuration[category][name];
        }

        /// <summary>
        /// Set data in the ini configuration file.
        /// </summary>
        /// <param name="category">The category of the entry within the ini file.</param>
        /// <param name="name">The name within the catagory in the ini file.</param>
        /// <param name="value">the value of the entry as a string.</param>
        public void SetEntry(string category, string name, string value)
        {
            configuration[category][name] = value;
        }
    }
}
